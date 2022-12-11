using GuessNumber.Abstractions.Logic;
using System.Configuration;

namespace GuessNumber.Implementations.Logic
{
    public class AppConfigSettingsProvider : ISettingsProvider
    {
        private const string _rangeOfNumberMax = "RangeOfNumberMax";
        private const string _rangeOfNumberMin = "RangeOfNumberMin";
        private const string _numberOfAttemps = "NumberOfAttemps";
        
        public Settings GetSettings()
        {
            int rangeOfNumberMax = this.GetRequiredIntValueByKey(_rangeOfNumberMax);
            int rangeOfNumberMin = this.GetRequiredIntValueByKey(_rangeOfNumberMin);

            int numberOfAttemps = this.GetRequiredIntValueByKey(_numberOfAttemps);

            Settings settings = new()
            {
                NumberOfAttemps = numberOfAttemps,
                RangeOfNumberMax = rangeOfNumberMax,
                RangeOfNumberMin = rangeOfNumberMin
            };

            return settings;
        }

        private int GetRequiredIntValueByKey(string key)
        {
            string valueStr = this.GetRequiredValueByKey(key);
            if (!int.TryParse(valueStr, out int value))
                throw new Exception($"""The value "{valueStr}" by key "{key}" in .config settings cannot parse to int.""");

            return value;
        }

        private string GetRequiredValueByKey(string key)
        {
            string value = ConfigurationManager.AppSettings[key]
                ?? throw new Exception($"""The key "{key}" is not filled in .config settings.""");
            return value;
        }
    }
}
