using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Abstract base class for working with weather data.
    /// </summary>
    public abstract class Report : IObserver<WeatherInfo>
    {
        private IObservable<WeatherInfo> weatherObservable;
        private WeatherInfo info;

        /// <summary>
        /// Property for weather info.
        /// </summary>
        public WeatherInfo Info
        {
            get => info;
            internal protected set => info = value ?? throw new ArgumentNullException($"The value for {nameof(WeatherInfo)} can not be null");
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Report()
        {
            Info = new WeatherInfo();
        }

        /// <summary>
        /// Constructor. Performs subscribe to given subject.
        /// </summary>
        /// <param name="subject">
        /// Observable subject.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="subject"/> is null.
        /// </exception>
        public Report(IObservable<WeatherInfo> subject) : this()
        {
            CheckObservableSubject(subject);

            this.weatherObservable = subject;
            subject.Register(this);
        }

        /// <summary>
        /// Resive a new weather data from sender and update inner data of weather.
        /// </summary>
        /// <param name="sender">
        /// The observable sender.
        /// </param>
        /// <param name="info">
        /// A new weather data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="info"/> or <paramref name="sender"/> is null.
        /// </exception>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            CheckObservableSubject(sender, info);

            if (ReferenceEquals(sender, weatherObservable))
            {
                UpdateDateInReport(info);
            }
        }

        /// <summary>
        /// Performs subscribe on given subject.
        /// </summary>
        /// <param name="subject">
        /// The subject for the subscription.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="subject"/> is null.
        /// </exception>
        public void Subscribe(IObservable<WeatherInfo> subject)
        {
            CheckObservableSubject(subject);

            this.weatherObservable = subject;
            subject.Register(this);
        }

        /// <summary>
        /// Unsubscribe from current observable subject.
        /// </summary>
        public void Unsubscribe()
        {
            if (!ReferenceEquals(weatherObservable, null))
            {
                weatherObservable.Unregister(this);
            }                
        }

        /// <summary>
        /// Abstract report for showing report with necessary data of weather.
        /// </summary>
        /// <returns></returns>
        public abstract string ShowReport();

        protected abstract void UpdateDateInReport(WeatherInfo info);

        private void CheckObservableSubject(IObservable<WeatherInfo> subject, WeatherInfo info)
        {
            CheckObservableSubject(subject);

            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException($"The {nameof(info)} subject or sender can not be null;");
            }
        }

        private void CheckObservableSubject(IObservable<WeatherInfo> subject)
        {
            if (ReferenceEquals(subject, null))
            {
                throw new ArgumentNullException($"The observable {typeof(IObservable<WeatherInfo>)} subject or sender can not be null;");
            }
        }       
    }
}
