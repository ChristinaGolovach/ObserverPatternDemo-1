 using System;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;
using PatternEventObservers =  ObserverPatternWithEvent.Observers;
using PatternEvent =  ObserverPatternWithEvent;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPatternWithInterfaces();

            TestPatternWithEvents();

            Console.ReadLine();

        }

        static void TestPatternWithInterfaces()
        {
            WeatherInfo weatherInfo = new WeatherInfo() { Temperature = 1, Humidity = 2, Pressure = 2, };
            WeatherData weatherData = new WeatherData();

            Report currentReport = new CurrentConditionsReport(weatherData);
            Report statisticReport = new StatisticReport(weatherData);

            weatherData.Start(5);
        }
        
        static void TestPatternWithEvents()
        {
            var weatherData = new PatternEvent.WeatherData();
            var statisticReport = new PatternEventObservers.StatisticReport();
            var currentReport = new PatternEventObservers.CurrentConditionsReport();

            statisticReport.Subscribe(weatherData);
            currentReport.Subscribe(weatherData);

            weatherData.StartWork();
        }
    }
}
