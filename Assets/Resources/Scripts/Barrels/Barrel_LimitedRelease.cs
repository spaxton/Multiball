using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_LimitedRelease : Barrel_Base
{
    [Header("Limited Release Configuration")]
    public List<float> Angles;
    public float ChangeAngleCooldown = 0.3F;

    [Header("Limited Release Debugging")]
    public int Index = 0;
    public float ChangeAngleTimer = 0F;

    public override void HandleMoveInput()
    {
        if (PassengerInput != null && ChangeAngleTimer <= 0F)
        {   
            if (PassengerInput.MoveInput.x > 0F)
            {
                NextAngle();
            }

            if (PassengerInput.MoveInput.x < 0F)
            {
                PreviousAngle();
            }

            ChangeAngleTimer = ChangeAngleCooldown;
        }

        if (ChangeAngleTimer > 0F)
        {
            ChangeAngleTimer -= Time.deltaTime;
        }
    }

    public void NextAngle()
    {
        Index++;

        if (Index >= Angles.Count)
        {
            Index = 0;
        }

        transform.rotation = Quaternion.Euler(0F, 0F, Angles[Index]);
    }

    public void PreviousAngle()
    {
        Index--;

        if (Index < 0)
        {
            Index = Angles.Count - 1;
        }

        transform.rotation = Quaternion.Euler(0F, 0F, Angles[Index]);
    }

    private void OnDrawGizmos()
    {
        foreach(float Angle in Angles)
        {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, Angle) * transform.up * 3);
        }
    }
}
