namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class Nominal
    {
        public decimal nominal { get; private set; }
        public Nominal(decimal nominal)
        {
            this.nominal = nominal;
        }
    }
}
