using System.Collections.Generic;
using UnityEngine;

public class Dispatch_OnTick : Dispatcher
{
    [Header("Configuration")]
    public float TickPeriod;

    [Header("Debugging")]
    public float Timer;
    public bool IsRunning = true;

    private void Update()
    {
        if (IsRunning)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                Timer = TickPeriod;
                ActivateDispatcher(null);
            }
        }
       
    }



}
