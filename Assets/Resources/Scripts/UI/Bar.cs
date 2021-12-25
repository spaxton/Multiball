using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : StatDisplay
{
    [Header("Bar Configuration")]
    public TextMeshProUGUI BarTMP;

    [Header("Debugging (Bar)")]
    public Slider SliderUI;

    private void Awake()
    {
        SliderUI = GetComponent<Slider>();
    }
    public override void OnStatUpdate()
    {
        if (ConnectedStat != null)
        {
            SliderUI.value = Mathf.Clamp(ConnectedStat.CurrentValue / ConnectedStat.MaxValue, 0F, 1F);

            if (BarTMP != null)
            {
                BarTMP.text = ConnectedStat.CurrentValue + "/" + ConnectedStat.MaxValue;
            }
        }
    }
}
