using System.Collections;
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
        int index = Random.Range(0, 3);

        switch (index)
        {
            case 0:
                obstacleLowPool.RetrieveInstance();
                break;
            case 1:
                obstacleLowPool.RetrieveInstance();
                break;
            case 2:
                obstacleLowPool.RetrieveInstance();
                break;
        }
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

    private void Start()
    {
        StartCoroutine(SpawnObjectCR());
    }

    IEnumerator SpawnObjectCR()
    {
        yield return new WaitForSeconds(Random.Range(1,4));
        SpawnObject();
    }
}