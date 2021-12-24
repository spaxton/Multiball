using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_PlayPFX : Listener
{
    [Header("Configuration")]
    public ParticleSystem PFX;
    public bool CanOverlapSounds = false;

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        PlayPFX();
    }

    public void PlayPFX()
    {
        PFX.Play();

    }
}
