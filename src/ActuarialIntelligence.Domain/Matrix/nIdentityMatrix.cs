using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuarialIntelligence.Domain.Matrix
{
    public class nIdentityMatrix
    {
        public nIdentityMatrix()
        {

        }

        public _nMatrix ReturnNIdentityMatrix(int n)
        {
            var matrixRows = new List<_nVector>();
            for (int i = 0; i < n; i++)
            {
                var row = new List<double>();
                for (int j = 0; j < n; j++)
                {
                    if (j == i)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(0);
                    }
                }
                var vectorRow = new _nVector(row);
                matrixRows.Add(vectorRow);
            }
            return new _nMatrix(matrixRows, n);
        }

    }
}
