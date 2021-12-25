using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_AddBatteryCharge : Listener
{
    [Header("Listener Configuration")]
    public Battery Battery;
    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        DepleteStat(_dispatchData);
    }

    public void DepleteStat(DispatchData _dispatchData)
    {
        Character character = _dispatchData.InteractorGO.GetComponent<Character>();

        if (character != null)
        {
            Stat characterStat = character.FindStat("Charge");
            if (characterStat != null)
            {
                Battery.AddCharge(characterStat.CurrentValue);

                characterStat.CurrentValue = 0F;
            }
            else
            {
                Debug.LogError("Listener_AddBatteryCharge: Did not find Stat of type charge on " + character.gameObject);
            }
        }
    }


}
