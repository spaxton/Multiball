using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Listener_LerpImageOpacity : Listener
{
    [Header("Configuration")]
    [Range(0F, 1F)] public float TargetOpacity;
    public float LerpDuration;
    public bool LerpOnStart;
    public bool FlipLerpDirectionOnEnd = false;
    public bool UseSourceOpacityAsStart = true;

    [Header("Debugging")]
    public Image ImageToOpacityLerp;
    public bool LerpIsRunning;
    public float LerpTimer;
    public float StartOpacity;

    // Variable Initialization
    private void Awake()
    {
        ImageToOpacityLerp = GetComponent<Image>();
    }

    // On Enable
    private void OnEnable()
    {
        if (UseSourceOpacityAsStart)
        {
            StartOpacity = GetComponent<Image>().color.a;
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
                    float temp = TargetOpacity;
                    TargetOpacity = StartOpacity;
                    StartOpacity = temp;
                }

            }
            else // Fade Incomplete
            {
                ImageToOpacityLerp.color = new Color(ImageToOpacityLerp.color.r, ImageToOpacityLerp.color.g, ImageToOpacityLerp.color.b, Mathf.Lerp(StartOpacity, TargetOpacity, LerpTimer / LerpDuration));
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
    public void ConfigureLerp(float _fadeDuration, float _startOpacity, float _targetOpacity)
    {
        LerpDuration = _fadeDuration;
        StartOpacity = _startOpacity;
        TargetOpacity = _targetOpacity;
    }   
}
