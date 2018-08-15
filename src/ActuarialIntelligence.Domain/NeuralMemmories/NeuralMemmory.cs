using ActuarialIntelligence.Domain.ContainerObjects;

namespace ActuarialIntelligence.Domain.NeuralMemmories
{
    /// <summary>
    /// Memmory object to store Neural Memmory.
    /// For use by learner and processor objects.
    /// Sums of object properties for instance will be stored here if necessary.
    /// </summary>
    public class NeuralMemmory<U,T>
    {
        private readonly Point<U, T> memmoryValues;
        public NeuralMemmory(Point<U, T> memmoryValues)
        {
            this.memmoryValues = memmoryValues;
        }

        public Point<U, T> GetMemmoryValues()
        {
            return memmoryValues;
        }
    }
}
