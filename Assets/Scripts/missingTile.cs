using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionSoundPlayer : MonoBehaviour
{
    [System.Serializable]
    public class TagSoundPair
    {
        public string targetTag;      // Tag to detect
        public AudioClip soundClip;   // Sound to play
        public bool useTrigger;       // True if using trigger collision
    }

    [SerializeField] private TagSoundPair[] tagSounds;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAndPlay(collision.gameObject, false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckAndPlay(other.gameObject, true);
    }

    private void CheckAndPlay(GameObject otherObject, bool isTrigger)
    {
        foreach (var pair in tagSounds)
        {
            if (pair.useTrigger == isTrigger && otherObject.CompareTag(pair.targetTag))
            {
                audioSource.PlayOneShot(pair.soundClip);
                return;
            }
        }
    }
}