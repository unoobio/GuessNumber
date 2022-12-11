using GuessNumber.Abstractions.Logic;
using GuessNumber.Abstractions.UI;

namespace GuessNumber.Implementations.UI
{
    public class ConsoleDialogManager : IDialogManager
    {
        private readonly IMainLogic _mainLogic;

        public ConsoleDialogManager(IMainLogic mainLogic)
        {
            _mainLogic = mainLogic;
        }
        
        public void Run()
        {
            while (true)
            {
                if (!this.TryRunDialogIteration())
                    break;
            }
        }

        private bool TryRunDialogIteration()
        {
            Console.WriteLine("Do you want to guess the number (Y/N):");

            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar != 'Y' && key.KeyChar != 'y')
                return false;

            _mainLogic.PrepareNumber();
            CompareResult? compareResult;
            do
            {
                if (!this.TryRunGuessDialogIteration(out compareResult) || compareResult == CompareResult.Equal)
                    break;
            }
            while (true);

            return true;
        }

        private bool TryRunGuessDialogIteration(out CompareResult? compareResult)
        {
            compareResult = null;

            if (!this.HaveAttemps())
                return false;

            int number;
            do { }
            while (!TryGetNumberFromConsole(out number));

            compareResult = this.CompareWithConcieved(number);

            return true;
        }

        private bool TryGetNumberFromConsole(out int number)
        {
            Console.WriteLine($"Enter the number.");
            string? numberStr = Console.ReadLine();
            if (!int.TryParse(numberStr, out number))
            {
                Console.WriteLine("Please enter correct number.");
                return false;
            }

            return true;
        }

        private CompareResult? CompareWithConcieved(int number)
        {
            _mainLogic.TryCompareWithConcieved(number, out CompareResult? compareResult);

            if (compareResult == CompareResult.Equal)
            {
                Console.WriteLine("Congratulations!!!");
                return compareResult;
            }

            Console.WriteLine($"The concieved number is {(compareResult == CompareResult.Less ? "less" : "greater")}.");

            return compareResult;
        }

        private bool HaveAttemps()
        {
            if (!_mainLogic.HaveAttemps())
            {
                Console.WriteLine("You've run out of tries :(");
                return false;
            }
            return true;
        }
    }
}
