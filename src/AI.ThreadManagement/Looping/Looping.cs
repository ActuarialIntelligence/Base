using AI.ThreadManagement.Interfaces;
using System;
using System.Threading.Tasks;

namespace AI.ThreadManagement.Looping
{
    public class Looping
    {
        private readonly IDecide decider;
        public Looping(IDecide decider)
        {
            this.decider = decider;
        }

        public void Loop(decimal initialValue, decimal increment,
            decimal finalValue, Func<decimal, decimal> function)
        {
            var tasks = decider.TaskCapacity;
            int remainder;
            int temp;
            var noOfIncrements = (int)(((finalValue - initialValue) / increment));
            var breaks = Math.DivRem(noOfIncrements, tasks, out temp);
            var divisible = IsDivisible(noOfIncrements, tasks, out remainder);
            for (int i = 0; i < tasks - 1; i++)
            {
                Task sendTask = new Task(() => LoopInternal(initialValue + (i * breaks),
                    increment, initialValue + ((i + 1) * breaks * increment), function));
            }
            Task sendFinalTask = new Task(() => LoopInternal
            (initialValue + ((tasks - 1) * breaks * increment),
            increment, initialValue + ((tasks * breaks * increment) + (remainder * increment)), function));
        }

        private static bool IsDivisible(int value, int tasks, out int remainder)
        {
            remainder = 0;
            Math.DivRem(value, tasks, out remainder);


            if (remainder != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void LoopInternal(decimal initialVlaue, decimal increment,
            decimal finalValue, Func<decimal, decimal> function)
        {
            var increments = (finalValue - initialVlaue) / increment;
            for (int i = 0; (i * increment) < increments; i++)
            {
                function((i * increment) + initialVlaue);
            }
        }
    }
}
