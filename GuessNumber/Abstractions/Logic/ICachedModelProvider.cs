namespace GuessNumber.Abstractions.Logic
{
    public interface ICachedModelProvider<T>
        where T : class
    {
        T GetCashedModel();
    }
}
