using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_PlaySFX : Listener
{
    [Header("Configuration")]
    public AudioClip SFX;
    public bool CanOverlapSounds = false;

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        PlaySFX();
    }

        public void PlaySFX()
    {
        AudioSource.PlayClipAtPoint(SFX, transform.position);

    }
}
