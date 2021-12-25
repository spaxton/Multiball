using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Configuration")]
    public List<Stat> CurrentStats = new List<Stat>();

    public void Start()
    {
        FindObjectOfType<PlayerUIManager>()?.CreatePlayerUI(this);
    }

    public void ChangeCurrentValue(string _name, float _value)
    {
        FindStat(_name).CurrentValue += _value;
    }

    public void SetCurrentValue(string _name, float _value)
    {
        FindStat(_name).CurrentValue = _value;
    }

    public void ChangeMaxValue(string _name, float _value)
    {
        FindStat(_name).MaxValue += _value;
    }

    public void SetMaxValue(string _name, float _value)
    {
        FindStat(_name).MaxValue = _value;
    }

    public Stat FindStat(string _name)
    {
        foreach (Stat stat in CurrentStats)
        {
            if (stat.Name == _name)
            {
                return stat;
            }
        }

        return null;
    }
}
