using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Listener : MonoBehaviour
{
    [Header("Debugging")]
    public List<Dispatcher> Dispatchers = new List<Dispatcher>();

    private void OnDestroy()
    {
        foreach(Dispatcher dispatcher in Dispatchers)
        {
            dispatcher.Listeners.Remove(this);
        }
    }

    public virtual void RunListenerLogic(DispatchData _dispatchData)
    {

    }
}