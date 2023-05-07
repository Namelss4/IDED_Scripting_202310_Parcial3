using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    public delegate void OnObjectToRecycle(GameObject instance);

    public event OnObjectToRecycle onObjectToRecycle;

    public void RecycleObject(GameObject instance) { }

}
