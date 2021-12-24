using UnityEngine;

public class AmbienceTrack : MonoBehaviour
{
    [Header("Configuration")]
    public bool IsPlaying;

    [Header("Debugging")]
    public AudioSource Source;
    

    private void Awake()
    {
        Source = GetComponent<AudioSource>();

        if (Source == null)
        {
            Debug.LogError("No Audio Source Found on Ambience Object");
        }
    }
}
