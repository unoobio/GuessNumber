using GuessNumber.Abstractions.Logic;

namespace GuessNumber.Implementations.Logic
{
    public class CashedAppConfigSettingsProvider : AppConfigSettingsProvider, ICachedModelProvider<Settings>
    {
        private Settings? _cahsedSetting;

        public Settings GetCashedModel()
        {
            if (_cahsedSetting == null)
            {
                _cahsedSetting = base.GetSettings();
            }

            return _cahsedSetting;
        }
    }
}
