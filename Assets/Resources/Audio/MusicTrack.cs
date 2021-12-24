using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class MusicTrack : MonoBehaviour
{
    [Header("Debugging")]
    public AudioSource Source;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();

        if (Source == null)
        {
            Debug.LogError("No Source Found on Music Track");
        }
    }
}
