using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects SFX;

    public AudioSource audioSource;

    [Header("Player Sounds")]
    public AudioClip bunnyDies;
    public AudioClip wallHit;
    public AudioClip goal;
<<<<<<< HEAD
=======
    public AudioClip boxFalling;
    public AudioClip bunnyJump;
>>>>>>> 9210ff9 (where we stopped in class)

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