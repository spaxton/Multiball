using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Stat
{
    public string Name;
    public float MaxValue;
    public float MinValue = 0F;
    public float CurrentValue
    {
        get
        {
            return _CurrentValue;
        }

        set
        {
            _CurrentValue = Mathf.Clamp(value, MinValue, MaxValue);
            UpdateStatDisplays();
        }
    }

    public float _CurrentValue;

    public List<StatDisplay> StatDisplays = new List<StatDisplay>();

    public void UpdateCurrentValue(float _changeAmount)
    {
        CurrentValue += _changeAmount;
    }

    public void RegisterStatDisplay(StatDisplay _statDisplay)
    {
        if (StatDisplays.Contains(_statDisplay))
        {
            return;
        }

        StatDisplays.Add(_statDisplay);
        _statDisplay.RegisterStat(this);
    }

    public void UnregisterStatDisplay(StatDisplay _statDisplay)
    {
        StatDisplays.Remove(_statDisplay);
    }

    public void UpdateStatDisplays()
    {
        foreach(StatDisplay statDisplay in StatDisplays)
        {
            statDisplay.OnStatUpdate();
        }
    }
}
