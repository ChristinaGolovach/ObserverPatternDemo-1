using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo, ICloneable
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

        public WeatherInfo Clone()
        {
            return new WeatherInfo() { Temperature = this.Temperature, Humidity = this.Humidity, Pressure = this.Pressure };
        }

        object ICloneable.Clone() => Clone();
    }
}