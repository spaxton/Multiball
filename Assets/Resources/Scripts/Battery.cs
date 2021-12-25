using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [Header("Configuration")]
    public float ChargeCapacity;
    public List<Listener> ChargeAddedEvent = new List<Listener>();
    public List<Listener> ChargeFilledEvent = new List<Listener>();

    [Header("Debugging")]
    public float _CurrentCharge = 0F;

    public float CurrentCharge
    {
        get
        {
            return _CurrentCharge;
        }

        set
        {
            _CurrentCharge = Mathf.Clamp(value, 0F, ChargeCapacity);
        }
    }

    public void AddCharge(float _chargeAmount)
    {
        CurrentCharge += _chargeAmount;
    }

    
}
