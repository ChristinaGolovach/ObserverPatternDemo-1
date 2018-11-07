using System;
using System.Threading;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class for the sending weather data to another classes.
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List <IObserver<WeatherInfo>> observers;
        private WeatherInfo info;
        private int temperature;
        private int humidity;
        private int pressure;
        private Random random;

        /// <summary>
        /// Constructor.
        /// </summary>
        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
            random = new Random();
            info = new WeatherInfo();
        }

        /// <summary>
        /// Performs the registration of new observer.
        /// </summary>
        /// <param name="observer">
        /// A new observer.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="observer"/> is null.
        /// </exception>
        public void Register(IObserver<WeatherInfo> observer)
        {
            CheckInputData(observer);

            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }            
        }

        /// <summary>
        /// Performs unregistration of given observer.
        /// </summary>
        /// <param name="observer">
        /// The observer for deleting from list of observers.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="observer"/> is null.
        /// </exception>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            CheckInputData(observer);

            observers.Remove(observer);
        }

        /// <summary>
        /// Simulates the work station.
        /// </summary>
        /// <param name="count">
        /// Amount of the generation of new weather data.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="count"/> less or equal 0.
        /// </exception>
        public void Start(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"The {nameof(count)} must be more than zero.");
            }

            SetNewWeatherInfo(count);
        }

        /// <summary>
        /// Performs sending new info about weather to another classes.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="info">
        /// A new info.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="info"/> or <paramref name="sender"/> is null.
        /// </exception>
        void IObservable<WeatherInfo>.Notify(WeatherInfo info) => Notify(info);

        protected virtual void Notify(WeatherInfo info)
        {
            CheckInputData(info);

            foreach (var item in observers)
            {
                item.Update(this, info);
            }
        }

        private void SetNewWeatherInfo(int count)
        {
            for (int i=0; i<=count; i++)
            {
                temperature = random.Next(-20, 30);
                humidity = random.Next(10, 80);
                pressure = random.Next(10, 120);

                info.Temperature = temperature;
                info.Humidity = humidity;
                info.Pressure = pressure;

                (this as IObservable<WeatherInfo>).Notify(info);

                Console.WriteLine(Environment.NewLine);
                
                Thread.Sleep(2000);
            }
        }

        private void CheckInputData(WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException($"The {nameof(info)} can not be null.");
            }
        }

        private void CheckInputData(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentNullException($"The {nameof(observer)} can not be null.");
            }
        }
    }
}
