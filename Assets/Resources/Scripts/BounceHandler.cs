using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceHandler : MonoBehaviour
{

    [Header("Configuration")]
    public int BounceDifferenceThreshold = 2;
    public int MatchBonusMultiplier = 2;

    public void ResolveBounces(int _RequiredBounces)
    {
        Character character = GetComponent<Character>();
        Stat ChargeStat = character.FindStat("Charge");
        Stat BounceStat = character.FindStat("Bounces");

        if (BounceStat.CurrentValue > _RequiredBounces)
        {
            BounceStat.CurrentValue = 0F;
            return;
        }

        int difference = (int) (_RequiredBounces - BounceStat.CurrentValue);

        if (difference > BounceDifferenceThreshold)
        {
            BounceStat.CurrentValue = 0F;
            return;
        }
        else
        {          
            ChargeStat.CurrentValue += BounceStat.CurrentValue * MatchBonusMultiplier;
            BounceStat.CurrentValue = 0F;
            return;
        }


    }
}
