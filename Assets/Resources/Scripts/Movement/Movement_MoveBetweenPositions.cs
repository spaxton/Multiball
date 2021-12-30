using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_MoveBetweenPositions : MonoBehaviour
{
    [Header("Configuration")]
    public List<Vector3> Positions = new List<Vector3>();
    public float MaxSpeed;
    [Range(-1F, 1F)] public float SpeedSetting;

    [Header("Debugging")]
    public Vector3 CurrentPosition;
    public Vector3 NextPosition;

    void Start()
    {
        if (Positions.Count >= 1)
        {
            CurrentPosition = Positions[0];
        }

        if (Positions.Count >= 2)
        {
            NextPosition = Positions[1];
        }

        transform.localPosition = CurrentPosition;
    }

    void Update()
    {
        if (SpeedSetting != 0F)
        {
            SetNext();
            Move();

            if (ReachedDestination())
            {
                CurrentPosition = NextPosition;
            }


            
        }
    }

    public void Move()
    {
        Vector3 dir = (NextPosition - transform.localPosition).normalized;

        transform.localPosition += dir * MaxSpeed * SpeedSetting * Time.deltaTime;
    }

    public void SetNext()
    {
        if (SpeedSetting > 0F)
        {
            NextPosition = Positions[GetWrappedIndex(Positions.IndexOf(CurrentPosition) + 1)];
        }

        if (SpeedSetting < 0F)
        {
            NextPosition = Positions[GetWrappedIndex(Positions.IndexOf(CurrentPosition) - 1)];
        }
    }

    public bool ReachedDestination()
    {
        return (transform.localPosition - NextPosition).magnitude < 0.1F;
    }

    public int GetWrappedIndex(int _index)
    {
        if (_index < 0)
        {
            return Positions.Count - 1;
        }

        if (_index >= Positions.Count)
        {
            return 0;
        }


        return _index;
        
    }

    private void OnDrawGizmosSelected()
    {
        if (Positions.Count == 0)
        {
            return;
        }

        Color startingColor = Color.red;
        Color endingColor = Color.blue;
        float index = 0;

        foreach (Vector3 position in Positions)
        {
            Gizmos.color = Color.Lerp(startingColor, endingColor, index / Positions.Count);
            Gizmos.DrawWireSphere(position, 0.5F);
            index++;
        }
    }
}
