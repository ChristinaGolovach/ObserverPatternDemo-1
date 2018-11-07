namespace ObserverPatternDemo
{
    /// <summary>
    /// Defines a receiver of notifications.
    /// </summary>
    /// <typeparam name="T">The object that provides notification information.</typeparam>
    public interface IObserver<T> where T : EventInfo
    {
        /// <summary>
        /// Handles an event.
        /// </summary>
        ///<param name="sender">The object that is to raised notifications.</param>
        ///<param name="info">The current notification information.</param>
        void Update(object sender, T info);
    }
}