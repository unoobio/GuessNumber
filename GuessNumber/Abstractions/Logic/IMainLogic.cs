namespace GuessNumber.Abstractions.Logic
{
    public interface IMainLogic
    {
        bool HaveAttemps();

        void PrepareNumber();
        
        bool TryCompareWithConcieved(int number, out CompareResult? compareResult);
    }
}
