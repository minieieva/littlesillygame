using UnityEngine;

// source: https://tengel403.medium.com/how-to-create-an-audio-manager-in-unity-1120a77ac10b
public class SoundEffects : MonoBehaviour
{
    public static SoundEffects SFX;

    public AudioSource audioSource;

    [Header("Player Sounds")]
    public AudioClip bunnyDies;
    public AudioClip wallHit;
    public AudioClip goal;

    [Header("Box Sounds")]
    public AudioClip bunnyDie;
    public AudioClip boxHit;

    void Awake()
    {
        SFX = this;
        audioSource = GetComponent<AudioSource>();
    }

    // play sound effect without interrupting other sounds/music
    public void Play(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}