using System.Collections.Generic;

public interface IObserver
{
    void Update(string message);
}

public class NewsAgency
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void NotifyObservers(string news)
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(news);
        }
    }
}
