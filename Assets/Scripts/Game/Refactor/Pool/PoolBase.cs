using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour, IPool
{
    //private static PoolBase instance;

    [SerializeField]
    private int count;

    [SerializeField]
    private GameObject basePrefab;

    [SerializeField]
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

    protected void PopulatePool()
    {
        Debug.Log("afuera" + count);
        for (int i = 0; i < count; i++)
        {
            Debug.Log("Adentro");
            GameObject newInstance = Instantiate(basePrefab, transform.position, Quaternion.identity);
            RecycleInstance(newInstance);
        }
    }


    protected abstract void ProcessTargetToRetrieve(GameObject instance);
    protected abstract void ProcessTargetToRecycle(GameObject instance);
}