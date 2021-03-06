using System.Collections.Generic;
using UnityEngine;

public class Dispatch_OnCollision2D : Dispatcher
{
    [Header("Configuration")]
    public string[] Tags;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Tags.Length == 0)
        {
            ActivateDispatcher(collision.collider.gameObject);
            return;
        }

        foreach (string tag in Tags)
        {
            if (collision.collider.tag == tag)
            {
                ActivateDispatcher(collision.collider.gameObject);
                return;
            }
        }
    }
    
}
