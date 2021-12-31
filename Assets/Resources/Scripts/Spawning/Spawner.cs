using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject ObjectToSpawn;
    public Vector3 SpawnPosition;
    public float GizmoSize = 0.5F;

    public GameObject Spawn()
    {
        return Instantiate(ObjectToSpawn, SpawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(SpawnPosition, GizmoSize);
    }
}
