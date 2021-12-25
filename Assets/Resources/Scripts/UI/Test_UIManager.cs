using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_UIManager : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject PlayerUIPrefab;
    

    public void CreatePlayerUI(Character _character)
    {
        GameObject playerUI = Instantiate(PlayerUIPrefab, transform);

        foreach(StatDisplay statDisplay in playerUI.GetComponentsInChildren<StatDisplay>())
        {
            Stat characterStat = _character.FindStat(statDisplay.StatName);
            if (characterStat == null)
            {
                continue;
            }
            else
            {
                statDisplay.RegisterStat(characterStat);
            }
        }
    }
}
