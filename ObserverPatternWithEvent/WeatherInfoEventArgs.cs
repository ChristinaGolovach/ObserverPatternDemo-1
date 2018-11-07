using System;

namespace ObserverPatternWithEvent
{
    public class WeatherInfoEventArgs : EventArgs, ICloneable
    {
        private int _temperature;
        private int _humidity;
        private int _pressure;

        public int Temperature { get => _temperature; }
        public int Humidity { get => _humidity; }
        public int Pressure { get => _pressure; }

        public WeatherInfoEventArgs(int temperature, int humidity, int pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
        }

        public WeatherInfoEventArgs Clone()
        {
            return new WeatherInfoEventArgs(this._temperature, this._humidity, this._pressure);
        }

        object ICloneable.Clone() => Clone();
    }
}
