using System;

namespace ObserverPatternWithEvent.Observers
{
    public abstract class Report
    {
        private WeatherInfoEventArgs weatherInfo;

        public WeatherInfoEventArgs WeatherInfo
        {
            get => weatherInfo;
            internal protected set => weatherInfo = value ?? throw new ArgumentNullException($"The {(nameof(WeatherInfo ))} can not be null.");
        }

        public Report() { }

        public Report(WeatherData weatherData)
        {
            weatherData.NewWeatherInfo += UpdateData;
        }

        public void Subscribe(WeatherData weatherData)
        {
            weatherData.NewWeatherInfo += UpdateData;
        }

        public void Unsubscribe(WeatherData weatherData)
        {
            weatherData.NewWeatherInfo -= UpdateData;
        }

        private void UpdateData(object sender, WeatherInfoEventArgs weatherInfoEventArgs)
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentNullException("");
            }

            if (ReferenceEquals(weatherInfoEventArgs, null))
            {
                throw new ArgumentNullException("");
            }

            UpdateDataInReport(sender, weatherInfoEventArgs);

            Console.WriteLine(ShowReport() + Environment.NewLine);           
        }

        protected abstract void UpdateDataInReport(object sender, WeatherInfoEventArgs weatherInfoEventArgs);

        public abstract string ShowReport();
    }
}
