using System;
using System.Threading;

namespace ObserverPatternWithEvent
{
    public class WeatherData
    {
        private Timer timer;

        public event EventHandler<WeatherInfoEventArgs> NewWeatherInfo = delegate { };
        
        public void SetNewWeatherInfo(int temperature, int humidity, int pressure)
        {
            OnNewWeatherInfo(new WeatherInfoEventArgs(temperature, humidity, pressure));
        }

        public void StartWork()
        {
            timer = new Timer(GenerateWeaherData, this, 0, 2000);
        }

        protected virtual void OnNewWeatherInfo(WeatherInfoEventArgs e)
        {
            if (ReferenceEquals(e, null))
            {
                throw new ArgumentNullException($"The {typeof(WeatherInfoEventArgs)} can not be null.");
            }

            NewWeatherInfo?.Invoke(this, e);
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
