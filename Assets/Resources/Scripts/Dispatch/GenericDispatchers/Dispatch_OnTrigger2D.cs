using System.Collections.Generic;
using UnityEngine;

public class Dispatch_OnTrigger2D : Dispatcher
{
    [Header("Configuration")]
    public string[] Tags;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (Tags.Length == 0)
        {
            ActivateDispatcher(collider.gameObject);
            return;
        }

        foreach (string tag in Tags)
        {
            if (collider.tag == tag)
            {
                ActivateDispatcher(collider.gameObject);
                return;
            }
        }
    }
    
}
