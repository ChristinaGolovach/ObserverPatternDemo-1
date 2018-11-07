﻿using System;
using System.Threading;

namespace ObserverPatternWithEvent
{
    public class WeatherData
    {
        private Timer timer;

        // Register/Unregister in pettern 
        public event EventHandler<WeatherInfoEventArgs> NewWeatherInfo = delegate { };

        // event handler - Notify in pattern
        protected virtual void OnNewWeatherInfo(WeatherInfoEventArgs e)
        {
            NewWeatherInfo?.Invoke(this, e);
        }

        public void SetNewWeatherInfo(int temperature, int humidity, int pressure)
        {
            OnNewWeatherInfo(new WeatherInfoEventArgs(temperature, humidity, pressure));
        }

        public void StartWork()
        {
            timer = new Timer(GenerateWeaherData, this, 0, 2000);
        }

        private void GenerateWeaherData(object stateInfo)
        {
            Random random = new Random();

            int temperature = random.Next(-25, 30);
            int humidity = random.Next(100, 200);
            int pressure = random.Next(250, 450);

            SetNewWeatherInfo(temperature, humidity, pressure);
        }

    }
}
