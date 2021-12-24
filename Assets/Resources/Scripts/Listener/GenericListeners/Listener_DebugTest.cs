using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_DebugTest : Listener
{
    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        LogTest();
    }

        public void LogTest()
    {
        Debug.Log(gameObject.name + ": Event Triggered");     
    }   
}
