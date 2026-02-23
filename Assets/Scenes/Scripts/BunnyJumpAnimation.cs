using UnityEngine;
using System.Collections;

public class BunnyJumpAnimation : MonoBehaviour
{
    [SerializeField] public Sprite[] frames;
    [SerializeField] public float frameRate = 24f;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayRight()
    {
        StartCoroutine(PlayRightJump());
    }

    public void PlayLeft()
    {
        StartCoroutine(PlayLeftJump());
    }

    public IEnumerator PlayRightJump()
    {
        float frameDelay = 1f / frameRate;
        foreach (Sprite frame in frames)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = frame;
            yield return new WaitForSeconds(frameDelay);
        }

    }

    public IEnumerator PlayLeftJump()
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
