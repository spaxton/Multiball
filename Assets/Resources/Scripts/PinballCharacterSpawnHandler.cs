using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballCharacterSpawnHandler : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<PinballCharacterResetter>().MoveToStartingBarrel(GetComponent<Character>());
    }
}
