using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Translation : Barrel_Base
{
    [Header("Translation Barrel Debugging")]
    public Movement_MoveBetweenPositions MovementHandler;

    public override void HandleMoveInput()
    {
        if (PassengerInput != null)
        {
            MovementHandler.SpeedSetting = PassengerInput.MoveInput.x;         
        }
    }
}
