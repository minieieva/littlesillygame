using UnityEngine;
using System.Collections;

public class JumpAnimation : MonoBehaviour
{
    [SerializeField] public Sprite[] frames;
    [SerializeField] public float frameRate = 12f;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayRight()
    {
        StartCoroutine(PlayJumpAnimationRight());
    }

    public void PlayLeft()
    {
        StartCoroutine(PlayJumpAnimationLeft());
    }

    public IEnumerator PlayJumpAnimationRight()
    {
        float frameDelay = 1f / frameRate;
        foreach (Sprite frame in frames)
         {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = frame;
            yield return new WaitForSeconds(frameDelay);
         }

    }
    public IEnumerator PlayJumpAnimationLeft()
    {
        float frameDelay = 1f / frameRate;
        foreach (Sprite frame in frames)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.sprite = frame;
            yield return new WaitForSeconds(frameDelay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
