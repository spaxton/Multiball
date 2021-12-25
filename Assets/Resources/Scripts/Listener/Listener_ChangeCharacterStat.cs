using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_ChangeCharacterStat : Listener
{
    [Header("Configuration")]
    public string StatName;
    public float ChangeValue = 0F;
    public Character Character;

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        ChangeStat(_dispatchData);
    }

    public void ChangeStat(DispatchData _dispatchData)
    {
        if (Character != null)
        {
            Character.ChangeCurrentValue(StatName, ChangeValue);
        }
    }
}
