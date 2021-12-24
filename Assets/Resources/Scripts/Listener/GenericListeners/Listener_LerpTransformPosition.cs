using UnityEngine;
using UnityEngine.UI;

public class Listener_LerpTransformPosition : Listener
{
    [Header("Configuration")]
    public Vector3 TargetPosition;
    public float LerpDuration;
    public bool LerpOnStart;
    public bool FlipLerpDirectionOnEnd = false;
    public bool UseSourcePositionAsStart = true;
    public bool UseLocalPosition = true;

    [Header("Debugging")]
    public bool LerpIsRunning;
    public float LerpTimer;
    public Vector3 StartPosition = Vector3.zero;

    // On Enable
    private void OnEnable()
    {
        if (UseSourcePositionAsStart)
        {
            StartPosition = transform.localPosition;
        }

        if (LerpOnStart)
        {
            BeginLerp();
        }
    }

    

    // Every Frame
    void Update()
    {
        if (LerpIsRunning)
        {

            if (LerpTimer > LerpDuration)
            {
                LerpIsRunning = false;

                if (FlipLerpDirectionOnEnd)
                {
                    Vector3 temp = TargetPosition;
                    TargetPosition = StartPosition;
                    StartPosition = temp;
                }

            }
            else // Fade Incomplete
            {
                if (UseLocalPosition == true)
                {
                    transform.localPosition = Vector3.Lerp(StartPosition, TargetPosition, LerpTimer / LerpDuration);

                }
                else
                {
                    transform.position = Vector3.Lerp(StartPosition, TargetPosition, LerpTimer / LerpDuration);
                }
                LerpTimer += Time.deltaTime;
            }        
        }
    }

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
            BeginLerp();
    }

        // This begins the fade transition
        public void BeginLerp()
    {

        if (LerpIsRunning == false)
        {
            LerpTimer = 0F;
            LerpIsRunning = true;
        }
    }

    // This configures the fade
    public void ConfigurePositionLerp(float _lerpDuration, Vector3 _startPosition, Vector3 _targetPosition)
    {
        LerpDuration = _lerpDuration;
        StartPosition = _startPosition;
        TargetPosition = _targetPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if (UseLocalPosition == true)
        {
            Gizmos.DrawWireSphere(transform.position + TargetPosition, 0.5F);
        }
        else
        {
            Gizmos.DrawWireSphere(TargetPosition, 0.5F);
        }
    }

}
