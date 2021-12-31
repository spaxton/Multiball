using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballCharacterResetter : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject StartingBarrelPrefab;
    public List<Vector3> StartingPositions = new List<Vector3>();

    Dictionary<Vector3, GameObject> StartingBarrelRoster = new Dictionary<Vector3, GameObject>();

    private void Awake()
    {
        foreach(Vector3 Position in StartingPositions)
        {
            StartingBarrelRoster[Position] = null;
        }
    }

    public void MoveToStartingBarrel(Character _character)
    {
        foreach (KeyValuePair<Vector3, GameObject> KVP in StartingBarrelRoster)
        {
            if (KVP.Value == null)
            {
                SpawnPlayerInBarrel(KVP.Key, _character.gameObject);
                return;
            }
        }

        Debug.LogError("PinballCharacterResetter: All Slots In Starting Barrel Roster Filled");
    }

    void SpawnPlayerInBarrel(Vector2 _position, GameObject _character)
    {
        Barrel_Base Barrel = Instantiate(StartingBarrelPrefab, _position, Quaternion.identity).GetComponent<Barrel_Base>();
        Barrel.OneTimeUse = true;
        Barrel.BringInPlayer(_character);
        StartingBarrelRoster[_position] = Barrel.gameObject;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        foreach (Vector3 Position in StartingPositions)
        {
            Gizmos.DrawWireSphere(Position, 0.5F);
        }
    }
}
