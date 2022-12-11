namespace GuessNumber.Abstractions.Logic
{
    public interface INumberGenerator
    {
        int GetNumberBetween(int min, int max);
    }
}
