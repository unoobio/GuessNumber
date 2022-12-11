using GuessNumber.Abstractions.Logic;

namespace GuessNumber.Implementations.Logic
{
    public class NumberComparer : INumberComparer
    {
        public NumberComparer()
        {

        }

        public CompareResult Compare(int source, int target)
        {
            int compareResult = source.CompareTo(target);
            switch (compareResult)
            {
                case -1:
                    return CompareResult.Less;
                case 0:
                    return CompareResult.Equal;
                case 1:
                    return CompareResult.Greater;
                default:
                    throw new Exception("Not recognized compare result.");
            }
        }
    }
}
