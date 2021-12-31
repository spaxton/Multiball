using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Pinball : MonoBehaviour, IInputConnectable
{
    [Header("Debugging")]
    public InputHandler IH;

    public void ConnectInput(InputHandler _IH)
    {
        IH = _IH;
    }

    public void DisconnectInput()
    {
        IH = null;
    }

    
}
