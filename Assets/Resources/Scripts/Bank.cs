using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [Header("Configuration")]
    public float ChargeCapacity = 100F;
    public Transform ChargeMask;
    public float MaskTravelDistance;
    public Color PositiveChargeColor = Color.white;
    public Color NegativeChargeColor = Color.white;
    public Color NeutralChargeColor = Color.white;
    public List<Listener> ChargeStoredEvent = new List<Listener>();
    public List<Listener> ChargeDrawnEvent = new List<Listener>();

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
            _CurrentCharge = value;
            if (value > 0F)
            {              
                ChargeMask.localPosition = new Vector2(0F, Mathf.Lerp(MaskTravelDistance, 0F, _CurrentCharge / ChargeCapacity));

                SetSpriteColors(PositiveChargeColor);
            
            }
            else if (value < 0F)
            {
                ChargeMask.localPosition = new Vector2(0F, Mathf.Lerp(MaskTravelDistance, 0F, _CurrentCharge / -ChargeCapacity));
                SetSpriteColors(NegativeChargeColor);
            }
            else
            {
                ChargeMask.localPosition = new Vector2(0F, Mathf.Lerp(MaskTravelDistance, 0F, _CurrentCharge / ChargeCapacity));
                SetSpriteColors(NeutralChargeColor);
            }
        }
    }

    public void Start()
    {
        CurrentCharge = 0F;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = collision.collider.GetComponent<Character>();

        if (character != null)
        {
            Stat characterStat = character.FindStat("Charge");
            if (characterStat != null)
            {
                if (CurrentCharge == 0F)
                {
                    AddCharge(character);
                }
                else
                {
                    PullCharge(character);
                }
            }
        }
    }

    public void AddCharge(Character _character)
    {
        float amount = _character.FindStat("Charge").CurrentValue;
        CurrentCharge += amount;
        _character.FindStat("Charge").UpdateCurrentValue(-amount);

        foreach (Listener listener in ChargeStoredEvent)
        {
            listener.RunListenerLogic(new DispatchData(_character.gameObject, gameObject));
        }
    }

    public void PullCharge(Character _character)
    {
        float amount = CurrentCharge;
        CurrentCharge -= amount;
        _character.FindStat("Charge").UpdateCurrentValue(amount);

        foreach(Listener listener in ChargeDrawnEvent)
        {
            listener.RunListenerLogic(new DispatchData(_character.gameObject, gameObject));
        }
    }

    public void SetSpriteColors(Color _color)
    {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.color = _color;
        }
    }
   
}
