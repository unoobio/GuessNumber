using GuessNumber.Abstractions.Logic;

namespace GuessNumber.Implementations.Logic
{
    public class ConcievedNumberProvider : IConcievedNumberProvider
    {
        private readonly ISettingsProvider _settingsProvider;
        private readonly INumberGenerator _numberGenerator;

        public ConcievedNumberProvider(ISettingsProvider settingsProvider, INumberGenerator numberGenerator)
        {
            _settingsProvider = settingsProvider;
            _numberGenerator = numberGenerator;
        }
        
        public int GetConcievedNumber()
        {
            Settings settings = _settingsProvider.GetSettings();
            return _numberGenerator.GetNumberBetween(settings.RangeOfNumberMin, settings.RangeOfNumberMax);
        }
    }
}
