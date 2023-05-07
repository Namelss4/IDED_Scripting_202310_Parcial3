using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHardPool : MonoBehaviour
{
    protected override void ProcessTargetToRetrieve(GameObject instance)
    {
        instance.transform.parent = null;
        instances.Remove(instance);
        instance.SetActive(true);
    }
    protected override void ProcessTargetToRecycle(GameObject instance)
    {
        instance.SetActive(false); //apago el gameObject
        instance.transform.position = transform.position;
        instance.transform.rotation = Quaternion.identity;
        instance.transform.parent = transform;
    }
}
