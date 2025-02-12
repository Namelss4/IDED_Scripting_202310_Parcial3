using Unity.VisualScripting;
using UnityEngine;

public sealed class RefactoredGameController : GameControllerBase, IObserver
{
    [SerializeField]
    private RefactoredUIManager uiManager;

    [SerializeField]
    private RefactoredPlayerController playerController;

    [SerializeField]
    private RefactoredObstacleSpawner obstacleSpawner;


    private static RefactoredGameController instance;
    public static RefactoredGameController Instance { get => instance; private set => instance = value; }

    public delegate void OnGameOver();

    public delegate void OnObstacleDestroyed(int hp);

    public event OnGameOver onGameOver;

    public event OnObstacleDestroyed onObstacleDestroyed;



    //protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

    //protected override UIManagerBase UiManager => throw new System.NotImplementedException();

    //protected override ObstacleSpawnerBase Spawner => throw new System.NotImplementedException();

    protected override PlayerControllerBase PlayerController => playerController;

    protected override UIManagerBase UiManager => uiManager;

    protected override ObstacleSpawnerBase Spawner => obstacleSpawner;
    protected override void OnScoreChanged(int hp)
    {
        throw new System.NotImplementedException();
    }

    private void Instance_onObstacleBeingDestroyed(int hp)
    {
        onObstacleDestroyed.Invoke(hp);
        OnScoreChanged(hp);
    }

    //public event OnObstacleDestroyed lol;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //RefactoredObstacle.Instance.onObstacleBeingDestroyed += Instance_onObstacleBeingDestroyed; //this caused a lot of problems but fixed itself out of nowhere
        //RefactoredObstacle.Instance.onObstacleBeingDestroyed += onObstacleDestroyed;

        //RefactoredObstacle.Instance.SubscribeObserver(this);
    }


    public void Notify(int hp)
    {
        Instance_onObstacleBeingDestroyed(hp);
    }
}