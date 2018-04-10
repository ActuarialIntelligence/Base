using ActuarialIntelligence.Domain.Matrix;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.Mathematical_Technique_Objects
{
    public class HouseholderBase
    {
        public IList<_nMatrix> UHouseholderMatrices { get; private set; }
        public IList<_nMatrix> VHouseholderMatrices { get; private set; }

        public _nMatrix Umatrix(int n)
        {
            var identity = new nIdentityMatrix();
            var UU = identity.ReturnNIdentityMatrix(n);
            for (int i = n - 2; i >= 0; i--)
            {
                var mat = UHouseholderMatrices[i];
                UU = UHouseholderMatrices[i].MultiplyByAnotherMatrix(UU);
            }

            return UU;
        }

        public HouseholderBase()
        {
            UHouseholderMatrices = new List<_nMatrix>();
            VHouseholderMatrices = new List<_nMatrix>();
            var tempIdentity = new nIdentityMatrix();

        }

        private _nVector HHStep1_1(_nMatrix matrix)
        {
            var n = matrix.n;
            var firstColumn = matrix.GetColumn(0);
            var coefficient = Sign(firstColumn.V(1)) * firstColumn.Norm(firstColumn);
            var coefficientTimesUnitVector = iComponentVector(n).MultiplyByScalar(coefficient);
            var resultAfterAdd = coefficientTimesUnitVector.Add(firstColumn);
            return resultAfterAdd;
        }

        private _nVector HHStep1_2(_nMatrix matrix)
        {
            var resultAfterStep1 = HHStep1_1(matrix);
            var scalar = (1 / resultAfterStep1.Norm(resultAfterStep1));
            var result = resultAfterStep1.MultiplyByScalar((1 / resultAfterStep1.Norm(resultAfterStep1)));
            return result;
        }

        /// <summary>
        /// // At this point U has been calculated including the norm of U being multiplied to U. Therefore, when we multiply U by itself it is in fact the norm times itself , and amounts to VT*V
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public _nMatrix HouseholderResult(_nMatrix matrix, int i, int dim)
        {
            var U = HHStep1_2(matrix);

            var result = U.MultiplyByMatrix(matrix);
            var multiplicationResult = U.MatrixTypeMultiplyWithAnotherVector(result);
            var resultTimes2 = multiplicationResult.MultiplyByScalar(2);
            var subtractionResult = matrix.SubtractAnotherMatrix(resultTimes2);
            if (i > 1)
            {
                AddToUHouseholder(U, subtractionResult, i, dim);
            }
            return subtractionResult;
        }


        private _nVector HHStep1_1R(_mnMatrix matrix)
        {
            var m = matrix.m;
            var firstRow = matrix.GetRow(0);
            var coefficient = Sign(firstRow.V(1)) * firstRow.Norm(firstRow);
            var coefficientTimesUnitVector = iComponentVector(m).MultiplyByScalar(coefficient);
            var resultAfterAdd = coefficientTimesUnitVector.Add(firstRow);
            return resultAfterAdd;
        }

        private _nVector HHStep1_2R(_mnMatrix matrix)
        {
            var resultAfterStep1 = HHStep1_1R(matrix);

            var scalar = (1 / resultAfterStep1.Norm(resultAfterStep1));
            var result = resultAfterStep1.MultiplyByScalar((1 / resultAfterStep1.Norm(resultAfterStep1)));
            return result;
        }

        public _mnMatrix HouseholderRightSideResult(_mnMatrix mnMatrix, int i, int dim)
        {
            var U = HHStep1_2R(mnMatrix);
            var result = mnMatrix.MultiplyByVector(U);
            var multiplicationResult = result.mnMatrixTypeMultiplyWithAnotherVector(U);
            var resultTimes2 = multiplicationResult.MultiplyByScalar(2);
            var subtractionResult = mnMatrix.SubtractAnotherMatrix(resultTimes2);
            if (i > 1)
            {
                AddToVHouseholder(U, subtractionResult, i, dim);
            }
            return subtractionResult;
        }

        public void AddToVHouseholder(_nVector V, _mnMatrix mnMatrix, int i, int dim)
        {
            var vMatrix = V.MatrixTypeMultiplyWithMe();
            var resultafterUMatrixTimes2 = vMatrix.MultiplyByScalar(2);
            var identity = new nIdentityMatrix();
            var finvlHouseholderMatrix = identity.ReturnNIdentityMatrix(i - 1)
                .SubtractAnotherMatrix(resultafterUMatrixTimes2);
            var matrixToAdd = identity.ReturnNIdentityMatrix(dim - 1);
            matrixToAdd.InsertSubMatrix(finvlHouseholderMatrix, i - 1);
            VHouseholderMatrices.Add(matrixToAdd);
            //var maybe = matrixToAdd.MultiplyByAnotherMatrix(matrixToAdd.ReturnTranspose(matrixToAdd));
            //var result = mnMatrix.MultiplyMeByNMatrix(matrixToAdd);   
        }

        public void AddToUHouseholder(_nVector U, _nMatrix matrix, int i, int dim)  // Householder Matrices are correct and functioning
        {
            var uMatrix = U.MatrixTypeMultiplyWithMe();
            var resultafterUMatrixTimes2 = uMatrix.MultiplyByScalar(2);
            var identity = new nIdentityMatrix();
            var finalHouseholderMatrix = identity.ReturnNIdentityMatrix(i)
                .SubtractAnotherMatrix(resultafterUMatrixTimes2);
            var matrixToAdd = identity.ReturnNIdentityMatrix(dim);
            matrixToAdd.InsertSubMatrix(finalHouseholderMatrix, i);
            UHouseholderMatrices.Add(matrixToAdd);
            //var result = matrixToAdd.MultiplyByAnotherMatrix(matrix);          
        }

        public double Sign(double value)
        {
            return value / (Math.Abs(value));
        }

        public _nVector iComponentVector(int m)
        {
            var Components = new List<double>();
            Components.Add(1);
            for (int i = 0; i < m - 1; i++)
            {
                Components.Add(0);
            }
            return new _nVector(Components);
        }
    }
}
