using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Rotation : Barrel_Base
{
    [Header("Rotation Barrel Configuration")]
    public float RotationSpeed;
    public override void HandleMoveInput()
    {
        if (PassengerInput != null)
        {           
            transform.rotation = Quaternion.Euler(0F, 0F, transform.rotation.eulerAngles.z + Time.deltaTime * RotationSpeed * PassengerInput.MoveInput.x);
        }
    }
}
