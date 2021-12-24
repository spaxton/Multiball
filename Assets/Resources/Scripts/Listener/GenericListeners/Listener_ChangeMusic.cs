using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_ChangeMusic : Listener
{
    [Header("Configuration")]
    public AudioClip Clip;
    public float TransitionTime = 1F;

    MusicTrack MusicTrack;
    Coroutine ChangeTrackCoroutine;

    void Awake()
    { 
        MusicTrack = FindObjectOfType<MusicTrack>();

        if (MusicTrack == null)
        {
            GameObject musicTrack = new GameObject("MusicTrack");
            MusicTrack = musicTrack.AddComponent<MusicTrack>();
        }
    }

    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        ChangeTracks();
    }

    public void ChangeTracks()
    {
        StopAllCoroutines();
        ChangeTrackCoroutine = StartCoroutine(ChangeTrackCR());
    }

    IEnumerator ChangeTrackCR()
    {
        float startVolume = MusicTrack.Source.volume;
        float endVolume = 0F;
        float elapsedTime = Mathf.Lerp(TransitionTime, 0F, startVolume);

        while (elapsedTime < TransitionTime)
        {
            AdjustVolume(ref elapsedTime, startVolume, endVolume);
            yield return null;
        }

        MusicTrack.Source.volume = 0F;
        startVolume = 0F;
        endVolume = 1F;
        elapsedTime = 0F;

        MusicTrack.Source.Stop();
        MusicTrack.Source.clip = Clip;
        MusicTrack.Source.Play();

        while (elapsedTime < TransitionTime)
        {
            AdjustVolume(ref elapsedTime, startVolume, endVolume);
            yield return null;
        }

        MusicTrack.Source.volume = 1F;
    }

    void AdjustVolume(ref float _elapsedTime, float _startVolume, float _endVolume)
    {
        MusicTrack.Source.volume = Mathf.Lerp(_startVolume, _endVolume, _elapsedTime/TransitionTime);

        _elapsedTime += Time.deltaTime;
    }
}
