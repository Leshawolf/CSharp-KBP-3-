namespace Pract2;

public interface IRateAndCopy
{
    double rating { get; }
    object DeepCopy();
}