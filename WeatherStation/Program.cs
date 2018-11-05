 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherInfo weatherInfo = new WeatherInfo() { Temperature = 1, Humidity = 2, Pressure = 2, };
            WeatherData weatherData = new WeatherData();                      

            Report currentReport = new CurrentConditionsReport(weatherData);
            Report statisticReport = new StatisticReport(weatherData);

           weatherData.Start(5);

           Console.ReadLine();

        }
    }
}
