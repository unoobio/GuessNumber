using GuessNumber.Abstractions.Logic;

namespace GuessNumber.Implementations.Logic
{
    public class MainLogic : IMainLogic
    {
        private readonly IConcievedNumberProvider _concievedNumberProvider;
        private readonly INumberComparer _numberComparer;
        private readonly ICachedModelProvider<Settings> _settingsProvider;

        public MainLogic(IConcievedNumberProvider concievedNumberProvider, INumberComparer numberComparer, ICachedModelProvider<Settings> settingsProvider)
        {
            _concievedNumberProvider = concievedNumberProvider;
            _numberComparer = numberComparer;
            _settingsProvider = settingsProvider;
        }

        private int? _concievedNumber;
        private int _attempCount;

        public void PrepareNumber()
        {
            _concievedNumber = _concievedNumberProvider.GetConcievedNumber();
            _attempCount = 0;
        }

        public bool TryCompareWithConcieved(int number, out CompareResult? compareResult)
        {
            if (_concievedNumber == null)
                throw new Exception("Concieved number wasn't generated.");

            compareResult = null;

            _attempCount++;
            if (_attempCount > _settingsProvider.GetCashedModel().NumberOfAttemps)
                return false;

            compareResult = _numberComparer.Compare(_concievedNumber.Value, number);

            return true;
        }

        public bool HaveAttemps() => _attempCount < _settingsProvider.GetCashedModel().NumberOfAttemps;
    }
}
