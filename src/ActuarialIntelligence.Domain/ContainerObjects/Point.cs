namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class Point<X, Y>
    {
        public X Xval { get; private set; }
        public Y Yval { get; private set; }
        public Point(X Xval,
                     Y Yval)
        {
            this.Xval = Xval;
            this.Yval = Yval;
        }
    }
}
