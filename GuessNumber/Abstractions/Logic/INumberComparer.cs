namespace GuessNumber.Abstractions.Logic
{
    public interface INumberComparer
    {
        CompareResult Compare(int source, int target);
    }
}
