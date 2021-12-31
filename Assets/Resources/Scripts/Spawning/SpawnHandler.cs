using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [Header("Configuration")]
    public List<Spawner> Spawners = new List<Spawner>();

    public void Spawn()
    {
        foreach(Spawner spawner in Spawners)
        {
            spawner.Spawn();
        }
    }
}
