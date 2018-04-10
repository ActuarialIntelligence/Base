using ActuarialIntelligence.Domain.Matrix;
using NUnit.Framework;
using System.Collections.Generic;

namespace ActuarialIntelligence.Tests.Matrix
{
    [TestFixture]
    [Category("Domain")]
    public class _nMatrixTests
    {
        _nMatrix matrix, matrix2, identity, subMatrix;

        [SetUp]
        public void BeforeEachTest()
        {
            var lista = new List<double>() { 1, 2, 6 };
            var lista2 = new List<double>() { 3, 4, 43 };
            var lista3 = new List<double>() { 5, 6, 21 };
            var veca1 = new _nVector(lista);
            var veca2 = new _nVector(lista2);
            var veca3 = new _nVector(lista3);
            var VecLista = new List<_nVector>();

            VecLista.Add(veca1);
            VecLista.Add(veca2);
            VecLista.Add(veca3);
            subMatrix = new _nMatrix(VecLista, 3);


            var idendityClass = new nIdentityMatrix();
            identity = idendityClass.ReturnNIdentityMatrix(6);

            var list = new List<double>() { 1, 2, 6, 7, 8, 3 };
            var list2 = new List<double>() { 3, 4, 43, 23, 1, 22 };
            var list3 = new List<double>() { 5, 6, 21, 1, 34, 2 };
            var list4 = new List<double>() { 15, 46, 221, 21, 334, 32 };
            var list5 = new List<double>() { 15, 46, 21, 31, 34, 12 };
            var list6 = new List<double>() { 45, 26, 221, 11, 234, 2 };

            var vec1 = new _nVector(list);
            var vec2 = new _nVector(list2);
            var vec3 = new _nVector(list3);
            var vec4 = new _nVector(list4);
            var vec5 = new _nVector(list5);
            var vec6 = new _nVector(list6);
            var VecList = new List<_nVector>();

            VecList.Add(vec1);
            VecList.Add(vec2);
            VecList.Add(vec3);
            VecList.Add(vec4);
            VecList.Add(vec5);
            VecList.Add(vec6);

            matrix = new _nMatrix(VecList, 6);

            var list1 = new List<double>() { 1, 2, 6, 7, 8, 3 };
            var list12 = new List<double>() { 3, 4, 43, 23, 1, 22 };
            var list13 = new List<double>() { 5, 6, 21, 1, 34, 2 };
            var list14 = new List<double>() { 15, 46, 221, 21, 334, 32 };
            var list15 = new List<double>() { 2, 3, 4, 5, 6, 7 };
            var list16 = new List<double>() { 8, 9, 10, 11, 12, 13 };

            var vec11 = new _nVector(list1);
            var vec12 = new _nVector(list12);
            var vec13 = new _nVector(list13);
            var vec14 = new _nVector(list14);
            var vec15 = new _nVector(list15);
            var vec16 = new _nVector(list16);
            var VecList1 = new List<_nVector>();

            VecList1.Add(vec11);
            VecList1.Add(vec12);
            VecList1.Add(vec13);
            VecList1.Add(vec14);
            VecList1.Add(vec15);
            VecList1.Add(vec16);

            matrix2 = new _nMatrix(VecList1, 6);
        }

        [Test]
        public void AssertMatrixMultiplicationTest1()
        {
            var result = matrix.MultiplyByAnotherMatrix(matrix2);
            Assert.AreEqual(result.GetValueAt(1, 1), 182m);
            Assert.AreEqual(result.GetValueAt(2, 2), 1539m);
            Assert.AreEqual(result.GetValueAt(3, 3), 1106m);
            Assert.AreEqual(result.GetValueAt(4, 4), 3847m);
            Assert.AreEqual(result.GetValueAt(5, 5), 11582m);
            Assert.AreEqual(result.GetValueAt(6, 6), 3165m);

            Assert.AreEqual(result.GetValueAt(2, 1), 753m);
            Assert.AreEqual(result.GetValueAt(3, 1), 227m);
            Assert.AreEqual(result.GetValueAt(4, 1), 2497m);
            Assert.AreEqual(result.GetValueAt(5, 1), 887m);
            Assert.AreEqual(result.GetValueAt(6, 1), 1877m);

            Assert.AreEqual(result.GetValueAt(1, 2), 419m);
            Assert.AreEqual(result.GetValueAt(3, 2), 326m);
            Assert.AreEqual(result.GetValueAt(4, 2), 3796m);
            Assert.AreEqual(result.GetValueAt(5, 2), 1976m);
            Assert.AreEqual(result.GetValueAt(6, 2), 2746m);

            Assert.AreEqual(result.GetValueAt(1, 3), 1827m);
            Assert.AreEqual(result.GetValueAt(2, 3), 6400m);
            Assert.AreEqual(result.GetValueAt(4, 3), 13006m);
            Assert.AreEqual(result.GetValueAt(5, 3), 9616m);
            Assert.AreEqual(result.GetValueAt(6, 3), 9416m);

            Assert.AreEqual(result.GetValueAt(1, 4), 279m);
            Assert.AreEqual(result.GetValueAt(2, 4), 886m);
            Assert.AreEqual(result.GetValueAt(3, 4), 407m);
            Assert.AreEqual(result.GetValueAt(5, 4), 2137m);
            Assert.AreEqual(result.GetValueAt(6, 4), 2557m);

            Assert.AreEqual(result.GetValueAt(1, 5), 2636m);
            Assert.AreEqual(result.GetValueAt(2, 5), 9442m);
            Assert.AreEqual(result.GetValueAt(3, 5), 1322m);
            Assert.AreEqual(result.GetValueAt(4, 5), 17082m);
            Assert.AreEqual(result.GetValueAt(6, 5), 13002m);

            Assert.AreEqual(result.GetValueAt(1, 6), 378m);
            Assert.AreEqual(result.GetValueAt(2, 6), 1212m);
            Assert.AreEqual(result.GetValueAt(3, 6), 485m);
            Assert.AreEqual(result.GetValueAt(4, 6), 4925m);
            Assert.AreEqual(result.GetValueAt(5, 6), 2485m);


        }

        [Test]
        public void AssertTransposeTest1()
        {
            var transpose = matrix.ReturnTranspose(matrix);

            Assert.AreEqual(transpose.GetValueAt(1, 1), matrix.GetValueAt(1, 1));
            Assert.AreEqual(transpose.GetValueAt(2, 2), matrix.GetValueAt(2, 2));
            Assert.AreEqual(transpose.GetValueAt(3, 3), matrix.GetValueAt(3, 3));
            Assert.AreEqual(transpose.GetValueAt(4, 4), matrix.GetValueAt(4, 4));
            Assert.AreEqual(transpose.GetValueAt(5, 5), matrix.GetValueAt(5, 5));
            Assert.AreEqual(transpose.GetValueAt(6, 6), matrix.GetValueAt(6, 6));

            Assert.AreEqual(transpose.GetValueAt(2, 1), matrix.GetValueAt(1, 2));
            Assert.AreEqual(transpose.GetValueAt(3, 1), matrix.GetValueAt(1, 3));
            Assert.AreEqual(transpose.GetValueAt(4, 1), matrix.GetValueAt(1, 4));
            Assert.AreEqual(transpose.GetValueAt(5, 1), matrix.GetValueAt(1, 5));
            Assert.AreEqual(transpose.GetValueAt(6, 1), matrix.GetValueAt(1, 6));

            //Assert.AreEqual(transpose.GetValueAt(1, 2), 419m);
            //Assert.AreEqual(transpose.GetValueAt(3, 2), 326m);
            //Assert.AreEqual(transpose.GetValueAt(4, 2), 3796m);
            //Assert.AreEqual(transpose.GetValueAt(5, 2), 1976m);
            //Assert.AreEqual(transpose.GetValueAt(6, 2), 2746m);

            //Assert.AreEqual(transpose.GetValueAt(1, 3), 1827m);
            //Assert.AreEqual(transpose.GetValueAt(2, 3), 6400m);
            //Assert.AreEqual(transpose.GetValueAt(4, 3), 13006m);
            //Assert.AreEqual(transpose.GetValueAt(5, 3), 9616m);
            //Assert.AreEqual(transpose.GetValueAt(6, 3), 9416m);

            //Assert.AreEqual(transpose.GetValueAt(1, 4), 279m);
            //Assert.AreEqual(transpose.GetValueAt(2, 4), 886m);
            //Assert.AreEqual(transpose.GetValueAt(3, 4), 407m);
            //Assert.AreEqual(transpose.GetValueAt(5, 4), 2137m);
            //Assert.AreEqual(transpose.GetValueAt(6, 4), 2557m);

            //Assert.AreEqual(transpose.GetValueAt(1, 5), 2636m);
            //Assert.AreEqual(transpose.GetValueAt(2, 5), 9442m);
            //Assert.AreEqual(transpose.GetValueAt(3, 5), 1322m);
            //Assert.AreEqual(transpose.GetValueAt(4, 5), 17082m);
            //Assert.AreEqual(transpose.GetValueAt(6, 5), 13002m);

            //Assert.AreEqual(transpose.GetValueAt(1, 6), 378m);
            //Assert.AreEqual(transpose.GetValueAt(2, 6), 1212m);
            //Assert.AreEqual(transpose.GetValueAt(3, 6), 485m);
            //Assert.AreEqual(transpose.GetValueAt(4, 6), 4925m);
            //Assert.AreEqual(transpose.GetValueAt(5, 6), 2485m);
        }

        [Test]
        public void AssertIdentityMatrix()
        {
            var result = identity;
            Assert.AreEqual(result.GetValueAt(1, 1), 1);
            Assert.AreEqual(result.GetValueAt(2, 2), 1);
            Assert.AreEqual(result.GetValueAt(3, 3), 1);
            Assert.AreEqual(result.GetValueAt(4, 4), 1);
            Assert.AreEqual(result.GetValueAt(5, 5), 1);
            Assert.AreEqual(result.GetValueAt(6, 6), 1);

            Assert.AreEqual(result.GetValueAt(2, 1), 0);
            Assert.AreEqual(result.GetValueAt(3, 1), 0);
            Assert.AreEqual(result.GetValueAt(4, 1), 0);
            Assert.AreEqual(result.GetValueAt(5, 1), 0);
            Assert.AreEqual(result.GetValueAt(6, 1), 0);

            Assert.AreEqual(result.GetValueAt(1, 2), 0);
            Assert.AreEqual(result.GetValueAt(3, 2), 0);
            Assert.AreEqual(result.GetValueAt(4, 2), 0);
            Assert.AreEqual(result.GetValueAt(5, 2), 0);
            Assert.AreEqual(result.GetValueAt(6, 2), 0);

            Assert.AreEqual(result.GetValueAt(1, 3), 0);
            Assert.AreEqual(result.GetValueAt(2, 3), 0);
            Assert.AreEqual(result.GetValueAt(4, 3), 0);
            Assert.AreEqual(result.GetValueAt(5, 3), 0);
            Assert.AreEqual(result.GetValueAt(6, 3), 0);

            Assert.AreEqual(result.GetValueAt(1, 4), 0);
            Assert.AreEqual(result.GetValueAt(2, 4), 0);
            Assert.AreEqual(result.GetValueAt(3, 4), 0);
            Assert.AreEqual(result.GetValueAt(5, 4), 0);
            Assert.AreEqual(result.GetValueAt(6, 4), 0);

            Assert.AreEqual(result.GetValueAt(1, 5), 0);
            Assert.AreEqual(result.GetValueAt(2, 5), 0);
            Assert.AreEqual(result.GetValueAt(3, 5), 0);
            Assert.AreEqual(result.GetValueAt(4, 5), 0);
            Assert.AreEqual(result.GetValueAt(6, 5), 0);

            Assert.AreEqual(result.GetValueAt(1, 6), 0);
            Assert.AreEqual(result.GetValueAt(2, 6), 0);
            Assert.AreEqual(result.GetValueAt(3, 6), 0);
            Assert.AreEqual(result.GetValueAt(4, 6), 0);
            Assert.AreEqual(result.GetValueAt(5, 6), 0);


        }

        [Test]
        public void AssertInsertSquareSubMatrix()
        {
            var identityClass = new nIdentityMatrix();
            var identity = identityClass.ReturnNIdentityMatrix(6);
            identity.InsertSubMatrix(subMatrix, 3);

            Assert.AreEqual(identity.GetValueAt(4, 4), 1);
            Assert.AreEqual(identity.GetValueAt(5, 5), 4);
            Assert.AreEqual(identity.GetValueAt(6, 6), 21);


            Assert.AreEqual(identity.GetValueAt(5, 4), 3);
            Assert.AreEqual(identity.GetValueAt(6, 4), 5);



        }
    }
}
