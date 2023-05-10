public interface ISubject
{
    void ResisterObserver(IObserver observer);

    void RemoveObserver(IObserver observer);

    void NotifyObservers();
}
