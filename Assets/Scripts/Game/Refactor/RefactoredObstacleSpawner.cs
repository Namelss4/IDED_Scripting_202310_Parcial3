using UnityEngine;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    private static RefactoredObstacleSpawner instance;
    public static RefactoredObstacleSpawner Instance { get => instance; private set => instance = value; }

    [SerializeField]
    private PoolBase obstacleLowPool;

    [SerializeField]
    private PoolBase obstacleMidPool;

    [SerializeField]
    private PoolBase obstacleHardPool;

    protected override void SpawnObject()
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}