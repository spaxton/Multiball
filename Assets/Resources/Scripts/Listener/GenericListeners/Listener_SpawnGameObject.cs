using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_SpawnGameObject : Listener
{
    [Header("Configuration")]
    public GameObject Prefab;

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        Instantiate(Prefab, transform.position, Quaternion.identity);

    }
}
