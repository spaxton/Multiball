using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_Destroy : Listener
{
    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        DestroyObject();
    }

        public void DestroyObject()
    {
        Destroy(gameObject);
    }

   
}
