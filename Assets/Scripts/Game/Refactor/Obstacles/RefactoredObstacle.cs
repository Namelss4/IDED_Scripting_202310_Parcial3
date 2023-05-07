using System.Collections.Generic;
public abstract class RefactoredObstacle : ObstacleBase
{
    private static GameControllerBase gameController;

    private static RefactoredObstacle instance;
    public static RefactoredObstacle Instance { get => instance; private set => instance = value; }

    //private static GameController gameController;

    public delegate void OnObstacleBeingDestroyed(int hp);

    public event OnObstacleBeingDestroyed onObstacleBeingDestroyed;

    public List<IObserver> observers;

    protected override GameControllerBase GameController
    {
        get
        {
            if (gameController == null)
            {
                gameController = FindObjectOfType<RefactoredGameController>();
            }

            return gameController;
        }
    }

    protected override void DestroyObstacle(bool notify = false)
    {
        if (notify)
        {
            onObstacleBeingDestroyed?.Invoke(HP);
            //NotifyObservers(HP);

            //GameController?.SendMessage("OnObstacleDestroyed", HP);
        }

        Destroy(gameObject);
    }

    public void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        Instance.observers = new List<IObserver>();
    }

    public void SubscribeObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnsubscribeObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(int hp)
    {
        foreach (IObserver observer in observers)
        {
            observer.Notify(hp);
        }
    }
}