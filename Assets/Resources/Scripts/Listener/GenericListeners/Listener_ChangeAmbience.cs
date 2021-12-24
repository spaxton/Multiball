using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_ChangeAmbience : Listener
{
    [Header("Configuration")]
    public AudioClip NewAmbienceClip;
    public float TransitionTime = 1F;

    [Header("Debugging")]
    public AmbienceTrack Ambience_1;
    public AmbienceTrack Ambience_2;
    Coroutine ChangeTrackCoroutine;

    void Awake()
    {


        AmbienceTrack[] AmbienceTracks = FindObjectsOfType<AmbienceTrack>();

        if (AmbienceTracks.Length == 0)
        {
            CreateAmbienceTracks();
        }
        else if (AmbienceTracks.Length == 2)
        {
            Ambience_1 = AmbienceTracks[0];
            Ambience_2 = AmbienceTracks[1];
        }
        else
        {
            Debug.LogError("Listener_ChangeAmbience: Make sure you either have 0 or 2 ambience tracks in the scene.");
        }
       

    }

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        ChangeAmbience();
    }

    public void ChangeAmbience()
    {
        if (NewAmbienceClip == Ambience_1.Source.clip)
        {
            return;
        }

        StopAllCoroutines();

        if (Ambience_1.IsPlaying)
        {
            ChangeTrackCoroutine = StartCoroutine(ChangeAmbienceCR(Ambience_1, Ambience_2, NewAmbienceClip));
        }
        else
        {
            ChangeTrackCoroutine = StartCoroutine(ChangeAmbienceCR(Ambience_2, Ambience_1, NewAmbienceClip));

        }
    }

    public void CreateAmbienceTracks()
    {
        AmbienceTrack[] AmbienceTracks = FindObjectsOfType<AmbienceTrack>();
        
        if (AmbienceTracks.Length < 2)
        {
            GameObject ambience1 = new GameObject("AmbienceTrack_1");
            GameObject ambience2 = new GameObject("AmbienceTrack_2");

            Ambience_1 = ambience1.AddComponent<AmbienceTrack>();
            Ambience_2 = ambience2.AddComponent<AmbienceTrack>();
        }
    }

    IEnumerator ChangeAmbienceCR(AmbienceTrack _ambienceToDeactivate, AmbienceTrack _ambienceToActivate, AudioClip _clip)
    {
        _ambienceToDeactivate.IsPlaying = false;
        _ambienceToActivate.IsPlaying = true;

        _ambienceToActivate.Source.clip = _clip;
        _ambienceToActivate.Source.Play();

        float ambienceDeactivateStartVolume = _ambienceToDeactivate.Source.volume;
        float ambienceDeactivateEndVolume = 0F;

        float ambienceActivateStartVolume = _ambienceToActivate.Source.volume;
        float ambienceActivateEndVolume = 1F;

        float elapsedTime = 0F;

        while (elapsedTime < TransitionTime)
        {
            _ambienceToDeactivate.Source.volume = Mathf.Lerp(ambienceDeactivateStartVolume, ambienceDeactivateEndVolume, elapsedTime / TransitionTime);
            _ambienceToActivate.Source.volume = Mathf.Lerp(ambienceActivateStartVolume, ambienceActivateEndVolume, elapsedTime / TransitionTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _ambienceToDeactivate.Source.Stop();
       
    }
}
