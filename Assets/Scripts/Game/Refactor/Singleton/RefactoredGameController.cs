using Unity.VisualScripting;

public sealed class RefactoredGameController : GameControllerBase
{
    private static RefactoredGameController instance;
    public static RefactoredGameController Instance { get => instance; private set => instance = value; }

    public delegate void OnGameOver();

    //public delegate void OnObstacleDestroyed(int hp);

    public event OnGameOver onGameOver;

    //public event OnObstacleDestroyed onObstacleDestroyed;



    //void OnObstacleDestroyed(int hp): Se invoca en el momento en que se destruye un obst�culo.
    //void OnGameOver():

    protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

    protected override UIManagerBase UiManager => throw new System.NotImplementedException();

    protected override ObstacleSpawnerBase Spawner => throw new System.NotImplementedException();

    protected override void OnScoreChanged(int hp)
    {
        throw new System.NotImplementedException();
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
}