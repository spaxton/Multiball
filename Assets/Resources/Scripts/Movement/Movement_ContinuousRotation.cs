using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_ContinuousRotation : MonoBehaviour
{
    [Header("Configuration")]
    public float MaxRotationSpeed;
    [Range(-1F, 1F)] public float SpeedSetting;

    void Update()
    {
        if (SpeedSetting != 0F)
        {
            Rotate();
        }
    }

   void Rotate()
    {
        transform.rotation = Quaternion.Euler(0F, 0F, transform.rotation.eulerAngles.z + MaxRotationSpeed * SpeedSetting * Time.deltaTime);


    }
}
