namespace ActuarialIntelligence.Calculators.Interfaces
{
    public interface ICalculate<T>
    {
        T Calculate();
    }

    public interface ICalculateParametric<T, U>
    {
        T Calculate(U parameter);
    }

    public interface ICalculateParametric<T, U, V>
    {
        T Calculate(U parameter1, V parameter2);
    }
    public interface ICalculateParametric<T, U, V, W>
    {
        T Calculate(U parameter1, V parameter2, W parameter3);
    }
}
