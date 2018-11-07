using System;
using System.Collections.Generic;

namespace ObserverPatternWithEvent.Observers
{
    public class StatisticReport : Report
    {
        private int averageTemperature;
        private int averagePressure;
        private int averageHumidity;
        private List<WeatherInfoEventArgs> weatherHistory = new List<WeatherInfoEventArgs>();

        public StatisticReport() { }

        public StatisticReport(WeatherData weatherData) : base (weatherData) { }  

        protected override void UpdateDataInReport(object sender, WeatherInfoEventArgs weatherInfoEventArgs)
        {
            weatherHistory.Add(weatherInfoEventArgs.Clone());
        }

        public override string ShowReport()
        {
            CalculateReportData();

            string report = $"Statistic report - The average weather indicators are: Temperature is {averageTemperature}, Humidity is {averageHumidity}, Pressure is {averagePressure}.";

            return report;
        }

        private void CalculateReportData()
        {
            averageTemperature = CalculateSumOfIndicators((info) => info.Temperature) / weatherHistory.Count;
            averagePressure = CalculateSumOfIndicators((info) => info.Pressure) / weatherHistory.Count;
            averageHumidity = CalculateSumOfIndicators((info) => info.Humidity) / weatherHistory.Count;
        }

        private int CalculateSumOfIndicators(Func<WeatherInfoEventArgs, int> property)
        {
            int sum = 0;
            foreach (var item in weatherHistory)
            {
                sum = sum + property(item);
            }
            return sum;
        }
    }
}
