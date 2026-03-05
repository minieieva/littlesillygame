using System.Collections;
using UnityEngine;

public class CookieAnimation : MonoBehaviour
{
    [SerializeField] public Sprite[] frames;
    [SerializeField] public float frameRate = 1f;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayTransportAnimation()
    {
        StartCoroutine(PlayTransport());
    }

    public IEnumerator PlayTransport()
    {
        float frameDelay = 1f / frameRate;
        foreach (Sprite frame in frames)
        {
            spriteRenderer.sprite = frame;
            yield return new WaitForSeconds(frameDelay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
