namespace Interface_Nasledovanie;

public interface IRateAndCopy
{
    double rating { get; }
    object DeepCopy();
}