using ActuarialIntelligence.Domain.Matrix;

namespace ActuarialIntelligence.Domain.Mathematical_Technique_Objects
{
    /// <summary>
    /// QR_Decomposition by householder matrix object.
    /// </summary>
    public class HouseholderQR : HouseholderBase
    {
        private int n;
        public HouseholderQR(int n) : base()
        {
            this.n = n;
        }

        public _nMatrix QRByHouseholderReflection(_nMatrix matrix, int dim)
        {
            var finalMatrix = matrix;
            var temp = matrix;
            for (int i = (n - 1); i >= 1; i--)
            {

                var result = HouseholderResult(temp, i + 1, dim);
                temp.InsertSubMatrix(result, i + 1);
                temp = temp.GetSubMatrix(i);
                finalMatrix.InsertSubMatrix(result, i + 1);

            }

            ZeroOutLeft(finalMatrix);
            return finalMatrix;

        }

        public _nMatrix BiDiagonalizationByHouseholderReflection(_nMatrix matrix, int dim)
        {
            var finalMatrix = matrix;
            var temp = matrix;
            for (int i = (n - 1); i >= 1; i--)
            {
                var result = HouseholderResult(temp, i, dim);

                temp.InsertSubMatrix(result, i + 1);
                temp = temp.GetSubMatrix(i);
                finalMatrix.InsertSubMatrix(result, i + 1);
                if (i > 1)
                {
                    HouseholderRight(finalMatrix, i, dim);
                }

            }
            ZeroOutLeft(finalMatrix);
            ZeroOutRight(finalMatrix);
            return finalMatrix;

        }

        public void HouseholderRight(_nMatrix matrix, int i, int dim)
        {
            _nMatrix temp = matrix;
            _nMatrix finalMatrix = matrix;
            HouseholderReflectionRight(matrix, temp, finalMatrix, i, n, dim);
        }

        public void HouseholderReflectionRight(_nMatrix matrix, _nMatrix temp
            , _nMatrix finalMatrix, int i, int n, int dim)
        {
            var temp3 = temp.GetSubMatrix(n - i - 1, n - (i - 1) - 1);

            if (i > 1)
            {
                var thing = temp3;
                var rightHouseholder = HouseholderRightSideResult(temp3, i, dim);
                temp.InsertSubMatrix(rightHouseholder, i + 1, i);
                finalMatrix.InsertSubMatrix(rightHouseholder, i + 1, i);
            }
        }

        public void ZeroOutRight(_nMatrix matrix)
        {
            int cntr = 0;
            foreach (var vctor in matrix.rows)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i >= cntr + 2)
                    {
                        vctor.Value.vector[i] = 0;
                    }
                }
                cntr++;
            }
        }

        public void ZeroOutLeft(_nMatrix matrix)
        {
            int row = 0;
            int cntr = 0;
            foreach (var vctor in matrix.rows)
            {
                if (row != 0)
                {
                    for (int i = 0; i <= cntr; i++)
                    {
                        vctor.Value.vector[i] = 0;
                    }
                    cntr++;
                }
                row++;
            }
        }
    }
}
