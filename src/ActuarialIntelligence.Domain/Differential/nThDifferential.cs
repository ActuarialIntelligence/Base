using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.Differential
{
    public class nThDifferential
    {
        /// <summary>
        /// We are employing a convention whereby the enumeration of the variable list object 
        /// is from right to left, where the iTh element is same variable (within the same type 
        /// of differential 'context')
        /// ..,f3,f2,f1,f0
        ///          f1,f0
        /// Using the following 'rows' as matrix entries and RowEcholon reduction / QR-Decomp
        /// will solve any differential equations involving x alone for n-points given sufficient equations.
        /// For x,y,z etc.. one will need to solve multiple separate matrices.
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public IList<decimal> DifferentialRow(int n, decimal constant, double h)
        {
            var row = new List<decimal>();
            var cnt = 0;
            for (int i = n; i > 0; i--)
            {
                row.Add((constant * (n - (cnt - 1)) * (decimal)Math.Pow((-1), (cnt))) / ((decimal)Math.Pow(h, 2 * n)));
                cnt++;
            }
            return row;
        }

    }
}
