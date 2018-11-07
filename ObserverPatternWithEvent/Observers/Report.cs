using System;

namespace ObserverPatternWithEvent.Observers
{
    public abstract class Report
    {
        private WeatherInfoEventArgs weatherInfo;

        public WeatherInfoEventArgs WeatherInfo
        {
            get => weatherInfo;
            internal protected set => weatherInfo = value ?? throw new ArgumentNullException($"The {(nameof(WeatherInfo))} can not be null.");
        }

        # region Constructors
        public Report() { }

        public Report(WeatherData weatherData)
        {
            CheckInputData(weatherData);

            weatherData.NewWeatherInfo += UpdateData;
        }
        # endregion Constructors


        public void Subscribe(WeatherData weatherData)
        {
            CheckInputData(weatherData);

            weatherData.NewWeatherInfo += UpdateData;
        }        

        public void Unsubscribe(WeatherData weatherData)
        {
            CheckInputData(weatherData); 

            weatherData.NewWeatherInfo -= UpdateData;
        }

        public abstract string ShowReport();

        protected abstract void UpdateDataInReport(object sender, WeatherInfoEventArgs weatherInfoEventArgs);

        private void UpdateData(object sender, WeatherInfoEventArgs weatherInfoEventArgs)
        {
            CheckInputData(sender, weatherInfoEventArgs);

            UpdateDataInReport(sender, weatherInfoEventArgs);

            Console.WriteLine(ShowReport() + Environment.NewLine);           
        }

        #region Check Data
        private void CheckInputData(WeatherData weatherData)
        {
            if (ReferenceEquals(weatherData, null))
            {
                throw new ArgumentNullException($"The {nameof(weatherData)} can not be null.");
            }
        }

        private void CheckInputData(object sender, WeatherInfoEventArgs weatherInfoEventArgs)
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentNullException($"The {nameof(sender)} can not be null.");
            }

            if (ReferenceEquals(weatherInfoEventArgs, null))
            {
                throw new ArgumentNullException($"The {nameof(weatherInfoEventArgs)} can not be null.");
            }
        }
        #endregion Check Data
    }
}
