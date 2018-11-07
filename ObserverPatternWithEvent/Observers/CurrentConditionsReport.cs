namespace ObserverPatternWithEvent.Observers
{
    public class CurrentConditionsReport : Report
    {
        public CurrentConditionsReport() { }

        public CurrentConditionsReport(WeatherData weatherData) : base() { }


        protected override void UpdateDataInReport(object sender, WeatherInfoEventArgs weatherInfoEventArgs)
        {
            WeatherInfo = weatherInfoEventArgs.Clone();
        }

        public override string ShowReport()
        {
            string report = $"Current report -  The current weather indicators are: Temperature is {WeatherInfo.Temperature}, Humidity is {WeatherInfo.Humidity}, Pressure is {WeatherInfo.Pressure}.";
            return report;
        }
    }
}
