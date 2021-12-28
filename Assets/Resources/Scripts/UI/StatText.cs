using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatText : StatDisplay
{
    [Header("Stat Text Debugging")]
    public TextMeshPro StatTMP;

    private void Awake()
    {
        StatTMP = GetComponent<TextMeshPro>();
    }

    public override void OnStatUpdate()
    {
        if (ConnectedStat != null)
        {
            StatTMP.text = ConnectedStat.CurrentValue.ToString();
        }
    }
}
