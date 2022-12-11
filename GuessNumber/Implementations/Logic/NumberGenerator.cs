using GuessNumber.Abstractions.Logic;

namespace GuessNumber.Implementations.Logic
{
    internal class NumberGenerator : INumberGenerator
    {
        public int GetNumberBetween(int min, int max) => new Random().Next(min, max);
    }
}
