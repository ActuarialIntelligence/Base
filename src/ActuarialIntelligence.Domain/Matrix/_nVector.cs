using System;
using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain.Matrix
{
    public class _nVector
    {
        public IList<double> vector { get; private set; }

        public _nVector(IList<double> vector)
        {
            this.vector = vector;
        }

        public double V(int position)
        {
            return vector[position - 1];
        }

        public _nVector Add(_nVector nVector)
        {
            var vec = new List<double>();
            int cntr = 0;
            foreach (var value in vector)
            {
                vec.Add(value + nVector.vector[cntr]);
                cntr++;
            }
            return new _nVector(vec);
        }

        public _nVector Subtract(_nVector nVector)
        {
            var vec = new List<double>();
            int cntr = 0;
            foreach (var value in vector)
            {
                vec.Add(value - nVector.vector[cntr]);
                cntr++;
            }
            return new _nVector(vec);
        }

        public _nVector MultiplyByScalar(double scalar)
        {
            var componentList = new List<double>();
            foreach (var component in vector)
            {
                componentList.Add(component * scalar);
            }

            return new _nVector(componentList);
        }

        public double DotProductWithAnotherVectorTranspose(_nVector vec)
        {
            double magnitude = 0;
            int ctr = 0;
            foreach (var component in vector)
            {
                magnitude += component * vec.vector[ctr];
                ctr++;
            }
            return magnitude;
        }

        public _nVector MultiplyByMatrix(_nMatrix matrix)
        {
            var n = matrix.n;
            var componentList = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += vector[j] * matrix.GetValueAt(j + 1, i + 1);
                }
                componentList.Add(sum);
            }
            return new _nVector(componentList);
        }

        public double Norm(_nVector vec)
        {
            double sum = 0;
            foreach (var component in vec.vector)
            {
                sum += Math.Pow(component, 2);
            }
            return Math.Sqrt(sum);
        }

        public _nMatrix MatrixTypeMultiplyWithAnotherVector(_nVector vec)
        {
            var componentList = new List<double>();
            int n = this.vector.Count();
            double[,] matrixComponents = new double[n, n];
            var dictionary = new List<_nVector>();
            int i = 0;
            foreach (var component in vector)
            {
                var vctor = new List<double>();
                foreach (var component2 in vec.vector)
                {
                    vctor.Add(component * component2);
                }
                dictionary.Add(new _nVector(vctor));
                i++;
            }
            return new _nMatrix(dictionary, n);
        }

        public _nMatrix MatrixTypeMultiplyWithMe()
        {
            var componentList = new List<double>();
            int n = this.vector.Count();
            double[,] matrixComponents = new double[n, n];
            var dictionary = new List<_nVector>();
            int i = 0;
            foreach (var component in vector)
            {
                var vctor = new List<double>();
                foreach (var component2 in vector)
                {
                    vctor.Add(component * component2);
                }
                dictionary.Add(new _nVector(vctor));
                i++;
            }
            return new _nMatrix(dictionary, n);
        }

        public _mnMatrix mnMatrixTypeMultiplyWithAnotherVector(_nVector vec)
        {
            var componentList = new List<double>();
            var dictionary = new List<_nVector>();
            int i = 0, j = 0;
            foreach (var component in vector)
            {
                var vctor = new List<double>();
                foreach (var component2 in vec.vector)
                {
                    vctor.Add(component * component2);
                }
                dictionary.Add(new _nVector(vctor));
                i++;
            }
            return new _mnMatrix(dictionary, i, j);
        }


    }
}
