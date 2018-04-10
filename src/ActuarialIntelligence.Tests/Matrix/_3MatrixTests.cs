using ActuarialIntelligence.Domain.ContainerObjects;
using NUnit.Framework;

namespace ActuarialIntelligence.Tests.Matrix
{
    [TestFixture]
    [Category("Domain")]
    public class _3MatrixTests
    {
        _3Matrix matrix;
        [SetUp]
        public void BeforeEachTest()
        {
            matrix = new _3Matrix(new _3Vector(1, 0, 0), new _3Vector(0, 1, 0), new _3Vector(0, 0, 1));
        }
        [Test]
        public void AssertMatrixIsIdentity()
        {
            var result = matrix.MultiplyByAnotherMatrix(matrix);
            Assert.AreEqual(result.GetValueAt(1, 1), 1m);
            Assert.AreEqual(result.GetValueAt(2, 2), 1m);
            Assert.AreEqual(result.GetValueAt(3, 3), 1m);
            Assert.AreEqual(result.GetValueAt(1, 2), 0m);
            Assert.AreEqual(result.GetValueAt(1, 3), 0m);
            Assert.AreEqual(result.GetValueAt(2, 1), 0m);
            Assert.AreEqual(result.GetValueAt(2, 3), 0m);
            Assert.AreEqual(result.GetValueAt(3, 1), 0m);
            Assert.AreEqual(result.GetValueAt(3, 2), 0m);
        }
    }
}
