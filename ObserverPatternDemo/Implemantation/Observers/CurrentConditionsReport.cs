using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Represent a class for working current weather data.
    /// </summary>
    public class CurrentConditionsReport : Report
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public CurrentConditionsReport() { } 

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="subject">
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="subject"/> is null.
        /// </exception>
        public CurrentConditionsReport(IObservable<WeatherInfo> subject) : base(subject) { }

        /// <summary>
        /// Show current weather data.
        /// </summary>
        /// <returns>
        /// String with current weather data.
        /// </returns>
        public override string ShowReport()
        {
            string report = $"The current weather indicators are: Temperature is {Info.Temperature}, Humidity is {Info.Humidity}, Pressure is {Info.Pressure}.";
            Console.WriteLine(report);

            return report;
        }

        protected override void UpdateDateInReport(WeatherInfo info)
        {
            info = info ?? throw new ArgumentNullException($"The {nameof(info)} can not be null");

            this.Info = info.Clone();

            ShowReport();
        }
    }
}