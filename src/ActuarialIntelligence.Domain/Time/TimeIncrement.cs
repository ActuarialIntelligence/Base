using ActuarialIntelligence.Domain.Date;
using ActuarialIntelligence.Domain.Enums;

namespace ActuarialIntelligence.Domain.Time
{
    public class TimeIncrement
    {
        public TimeIncrementTypes type { get; private set; }
        public int increments { get; private set; }
        public TimeIncrement(TimeIncrementTypes type, int increments)
        {
            this.type = type;
            this.increments = increments;
        }

        public static string GetTimeIDGivenIncrementsOnInputTimeId(string timeId, TimeIncrement increment)
        {
            var hour = int.Parse(timeId.ToString().Substring(0, 2));
            var minute = int.Parse(timeId.ToString().Substring(2, 2));
            var second = int.Parse(timeId.ToString().Substring(4, 2));
            var milliSecond = int.Parse(timeId.ToString().Substring(6, 4));
            if (increment.type == TimeIncrementTypes.Hour)
            {
                hour = hour + increment.increments > 24 ? hour + increment.increments - 24 : hour + increment.increments;
            }
            if (increment.type == TimeIncrementTypes.Minute)
            {
                minute = minute + increment.increments > 60 ? minute + increment.increments - 60 : minute + increment.increments;
            }
            if (increment.type == TimeIncrementTypes.Second)
            {
                second = second + increment.increments > 60 ? second + increment.increments - 60 : second + increment.increments;
            }
            if (increment.type == TimeIncrementTypes.MilliSecond)
            {
                milliSecond = milliSecond + increment.increments > 1000 ? milliSecond + increment.increments - 1000 : milliSecond + increment.increments;
            }

            return (DoubleCharacterOut(hour.ToString()) + DoubleCharacterOut(minute.ToString()) + DoubleCharacterOut(second.ToString()));
        }

        public static decimal GetTotalTimeUnitsInHours(TimeIncrement increment)
        {
            var hours = 0m;

            if (increment.type == TimeIncrementTypes.Hour)
            {
                hours = increment.increments;
            }
            if (increment.type == TimeIncrementTypes.Minute)
            {
                hours = increment.increments / (60m);
            }
            if (increment.type == TimeIncrementTypes.Second)
            {
                hours = increment.increments / (3600m);
            }
            if (increment.type == TimeIncrementTypes.MilliSecond)
            {
                hours = increment.increments / (3600000m);
            }

            return hours;
        }

        public static decimal GetTotalTimeUnitsInHours(DateIncrement increment)
        {
            var hours = 0m;

            if (increment.type == DateIncrementTypes.Day)
            {
                hours = increment.increments * 24;
            }
            if (increment.type == DateIncrementTypes.Month)
            {
                hours = increment.increments * 24 * 30;
            }
            if (increment.type == DateIncrementTypes.Year)
            {
                hours = increment.increments * 24 * 30 * 12;
            }


            return hours;
        }

        public static string GetTimeIDGivenIncrements(string timeIdA, string timeIdB)
        {
            var hour = 0m;
            var minute = 0m;
            var second = 0m;
            var miliSecond = 0m;

            var hourA = int.Parse(timeIdA.ToString().Substring(0, 2));
            var minuteA = int.Parse(timeIdA.ToString().Substring(2, 2));
            var secondA = int.Parse(timeIdA.ToString().Substring(4, 2));
            var miliSecondA = int.Parse(timeIdA.ToString().Substring(6, 2));

            var hourB = int.Parse(timeIdB.ToString().Substring(0, 2));
            var minuteB = int.Parse(timeIdB.ToString().Substring(2, 2));
            var secondB = int.Parse(timeIdB.ToString().Substring(4, 2));
            var miliSecondB = int.Parse(timeIdB.ToString().Substring(6, 2));

            hour = hourB - hourA > 24 ? hourB - hourA - 24 : hourB - hourA;
            minute = minuteB - minuteA > 60 ? minuteB - minuteA - 60 : minuteB - minuteA;
            second = secondB - secondA > 60 ? secondB - secondA : secondB - secondA;
            miliSecond = miliSecondB = miliSecondA > 1000 ? miliSecondB = miliSecondA : miliSecondB = miliSecondA;

            return (DoubleCharacterOut(hour.ToString()) + DoubleCharacterOut(minute.ToString()) + DoubleCharacterOut(second.ToString()) + DoubleCharacterOut(miliSecond.ToString()));
        }

        private static string DoubleCharacterOut(string input)
        {
            return input.Length > 1 ? "0" + input : input;
        }

    }
}
