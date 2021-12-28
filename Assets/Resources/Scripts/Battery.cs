using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [Header("Configuration")]
    public float ChargeCapacity;
    public Transform ChargeMask;
    public float MaskTravelDistance;
    public int RequiredBounces = 2;
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
            ChargeMask.localPosition = new Vector2(0F, Mathf.Lerp(MaskTravelDistance, 0F, _CurrentCharge / ChargeCapacity));

            
        }
    }

    public void Start()
    {
        CurrentCharge = 0F;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (_CurrentCharge >= ChargeCapacity)
        {
            return;
        }

        Character character = collision.GetComponent<Character>();

        //TEST CODE
        character.GetComponent<BounceHandler>()?.ResolveBounces(RequiredBounces);

        if (character != null)
        {
            Stat characterStat = character.FindStat("Charge");
            if (characterStat != null)
            {
                AddCharge(characterStat.CurrentValue);

                characterStat.CurrentValue = 0F;

                if (_CurrentCharge == ChargeCapacity)
                {
                    OnBatteryCharged(character.gameObject);
                }
            }
            else
            {
                Debug.LogError("Listener_AddBatteryCharge: Did not find Stat of type charge on " + character.gameObject);
            }
        }
    }

    public void AddCharge(float _chargeAmount)
    {
        CurrentCharge += _chargeAmount;
    }

    public void OnBatteryCharged(GameObject _activator)
    {
        foreach(Listener listener in ChargeFilledEvent)
        {
            listener.RunListenerLogic(new DispatchData(_activator, gameObject));
        }
    }
}
