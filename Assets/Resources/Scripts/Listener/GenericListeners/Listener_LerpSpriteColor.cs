using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Listener_LerpSpriteColor : Listener
{
    [Header("Configuration")]
    public Color TargetColor;
    public float LerpDuration;
    public bool LerpOnStart;
    public bool FlipLerpDirectionOnEnd = false;
    public bool UseSourceColorAsStart = true;

    [Header("Debugging")]
    public SpriteRenderer ImageToColorLerp;
    public bool LerpIsRunning;
    public float LerpTimer;
    public Color StartColor;

    // Variable Initialization
    private void Awake()
    {
        ImageToColorLerp = GetComponent<SpriteRenderer>();

    }

    // On Enable
    private void OnEnable()
    {
        if (UseSourceColorAsStart)
        {
            StartColor = GetComponent<SpriteRenderer>().color;
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

            if (LerpTimer > LerpDuration) // Fade Complete
            {
                LerpIsRunning = false;

                if (FlipLerpDirectionOnEnd)
                {
                    Color temp = TargetColor;
                    TargetColor = StartColor;
                    StartColor = temp;
                }

            }
            else // Fade Incomplete
            {
                ImageToColorLerp.color = Color.Lerp(StartColor, TargetColor, LerpTimer / LerpDuration);
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
            BeginLerp();
        }

        LerpTimer = 0F;
        LerpIsRunning = true;
    }

    // This configures the fade
    public void ConfigureColorLerp(float _lerpDuration, Color _startColor, Color _targetColor)
    {
        LerpDuration = _lerpDuration;
        StartColor = _startColor;
        TargetColor = _targetColor;
    }
}
