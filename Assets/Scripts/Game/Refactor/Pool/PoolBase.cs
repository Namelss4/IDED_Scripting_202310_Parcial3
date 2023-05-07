using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour, IPool
{
    [SerializeField]
    private int count = 0;

    [SerializeField]
    private GameObject basePrefab;

    protected List<GameObject> instances = new List<GameObject>();

    public void RecycleInstance(GameObject instance)
    {
        ProcessTargetToRecycle(instance);
        instances.Add(instance);
    }

    public GameObject RetrieveInstance()
    {
        if (instances.Count < 1)
        {
            PopulatePool();
        }

        GameObject instance = instances[0];
        ProcessTargetToRetrieve(instance);
        instances.Remove(instance);
        return instance;
    }

    private void PopulatePool()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newInstance = Instantiate(basePrefab, transform.position, Quaternion.identity);
            instances.Add(newInstance);
            RecycleInstance(newInstance);
        }
    }

    protected abstract void ProcessTargetToRetrieve(GameObject instance);
    protected abstract void ProcessTargetToRecycle(GameObject instance);
}