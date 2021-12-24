using System.Collections.Generic;
using UnityEngine;
public class Dispatcher : MonoBehaviour
{
    [Header("Listeners")]
    public List<Listener> Listeners = new List<Listener>();

    public void Awake()
    {
        foreach(Listener listener in Listeners)
        {
            if (listener != null)
            {
                listener.Dispatchers.Add(this);
            }
            else
            {
                Debug.LogError("Dispatcher: " + gameObject.name + " has null listener pointers.");
            }
        }
    }

    public void ActivateDispatcher(GameObject _interactor)
    {
        foreach(Listener listener in Listeners)
        {
            listener.RunListenerLogic(new DispatchData(_interactor, gameObject));
        }
    }
}

public class DispatchData
{
    public GameObject InteractorGO;
    public GameObject DispatcherGO;

    public DispatchData(GameObject _interactor, GameObject _dispatcher)
    {
        InteractorGO = _interactor;
        DispatcherGO = _dispatcher;
    }
}