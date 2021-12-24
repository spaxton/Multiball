using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_ChangeCharacterStat : Listener
{
    [Header("Configuration")]
    public string StatName;
    public float ChangeValue = 0F;

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        ChangeStat(_dispatchData);
    }

    public void ChangeStat(DispatchData _dispatchData)
    {
        Character character = _dispatchData.InteractorGO.GetComponent<Character>();

        if (character != null)
        {
            character.ChangeCurrentValue(StatName, ChangeValue);
        }
    }


}
