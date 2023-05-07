using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMidPool : PoolBase
{
    private static ObstacleMidPool instance;

    public static ObstacleMidPool Instance { get => instance; private set => instance = value; }

    protected override void ProcessTargetToRetrieve(GameObject instance)
    {
        instance.transform.parent = null;
        instances.Remove(instance);
        instance.SetActive(true);
    }
    protected override void ProcessTargetToRecycle(GameObject instance)
    {
        instance.SetActive(false);
        instance.transform.position = transform.position;
        instance.transform.rotation = Quaternion.identity;
        instance.transform.parent = transform;
    }

    private void Start()
    {
        //Debug.Log("Start jeje");
        RetrieveInstance();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
