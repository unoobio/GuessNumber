using GuessNumber.Abstractions.Logic;

namespace GuessNumber.Implementations.Logic
{
    public class SettingsValidator : ISettingsProvider
    {
        private readonly ISettingsProvider _settingsProvider;

        public SettingsValidator(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }
        
        public Settings GetSettings()
        {
            Settings settings = _settingsProvider.GetSettings();
            if (settings.NumberOfAttemps < 1)
                throw new Exception("NumberOfAttemps must be bigger than 0.");

            if (settings.RangeOfNumberMax <= settings.RangeOfNumberMin)
                throw new Exception("RangeOfNumberMax must be greater than RangeOfNumberMin.");

            return settings;
        }
    }
}
