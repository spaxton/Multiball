using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha_Character : MonoBehaviour
{
    public int Charge;
    public int MaxCharge;
    public int MinCharge;

    public bool BeingDrained;
    private bool Draining;
    public float TickTime;

    public Text ChargeUI;

    void FixedUpdate()
    {
        if(BeingDrained && !Draining)
        {
            StartCoroutine("DrainTimer");
        } 
        if(!BeingDrained && Draining)
        {
            StopCoroutine("DrainTimer");
        }

        ChargeUI.text = Charge.ToString();
    }

    public void OnCollisionEnter2D (Collision2D collider)
    {
        if(collider.gameObject.tag == "Walls")
        {
            ModCharge(1);
        }

        if(collider.gameObject.tag == "NegWalls")
        {
            ModCharge(-1);
        }
    }

    //Changing Charge Logic
    void ModCharge(int ChargeChange)
    {
        Charge += ChargeChange;
        if(Charge > MaxCharge)
        {
            Charge = MaxCharge;
        }
        if(Charge < MinCharge)
        {
            Charge = MinCharge;
        }
    }
    
    public void SetCharge(int ChargeVal)
    {
        Charge = ChargeVal;
    }

    //Draining Charge Logic
    void Drain()
    {
        if(Charge > 0)
        {
            Charge--;
        }
        if(Charge < 0)
        {
            Charge++;
        }
    }

        IEnumerator DrainTimer()
    {
        Draining = true;
        Drain();
        yield return new WaitForSeconds(TickTime);
        Draining = false;
    }

}
