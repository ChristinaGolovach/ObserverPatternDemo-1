using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Represent a class for working weather data and return statistic data.
    /// </summary>
    public class StatisticReport : Report
    {
        private List<WeatherInfo> infoHistory = new List<WeatherInfo>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public StatisticReport() { }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="subject">
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="subject"/> is null.
        /// </exception>
        public StatisticReport(IObservable<WeatherInfo> subject) : base(subject) { }

        /// <summary>
        /// Show average weather data.
        /// </summary>
        /// <returns>
        /// String with average weather data.
        /// </returns>
        public override string ShowReport()
        {
            return $"The average weather indicators are: Temperature is {Info.Temperature}, Humidity is {Info.Humidity}, Pressure is {Info.Pressure}.";
        }

        protected override void UpdateDateInReport(WeatherInfo info)
        {
            info = info ?? throw new ArgumentNullException($"The {nameof(info)} can not be null");

            WeatherInfo newInfo = new WeatherInfo();

            newInfo = info.Clone();

            infoHistory.Add(newInfo);

            CalculateReportData();
        }

        private void CalculateReportData()
        {
            int averageTemperature = CalculateSumOfIndicators((x) => x.Temperature) / infoHistory.Count;
            int averagePressure = CalculateSumOfIndicators((x) => x.Pressure) / infoHistory.Count;
            int averageHumidity = CalculateSumOfIndicators((x) => x.Humidity) / infoHistory.Count;

            Info.Temperature = averageTemperature;
            Info.Pressure = averagePressure;
            Info.Humidity = averageHumidity;
        }

        private delegate int Property(WeatherInfo info);

        private int CalculateSumOfIndicators(Property property)
        {
            int sum = 0;
            foreach (var item in infoHistory)
            {
                sum = sum + property(item);
            }
            return sum;            
        }        
    }
}
