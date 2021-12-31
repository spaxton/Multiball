using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_RotationInput : Barrel_Base
{
    [Header("Rotation Barrel Configuration")]
    public float RotationSpeed;
    public override void HandleMoveInput()
    {
        if (PassengerInput != null)
        {           
            transform.rotation = Quaternion.Euler(0F, 0F, transform.rotation.eulerAngles.z + Time.deltaTime * RotationSpeed * PassengerInput.MoveInput.x);
        }

        if(Passenger.GetComponent("Alpha_Character") != null){
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0F, 0F, transform.rotation.eulerAngles.z + Time.deltaTime * RotationSpeed * 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0F, 0F, transform.rotation.eulerAngles.z + Time.deltaTime * RotationSpeed * -1);
            }
        }
    }
}
