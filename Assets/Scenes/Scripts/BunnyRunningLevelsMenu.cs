using System.Collections;
using UnityEngine;

public class BunnyRunningLevelsMenu : MonoBehaviour
{
    [SerializeField] private Sprite[] frames;
    [SerializeField] private float frameRate = 24f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(PlayRightJump());
    }

    IEnumerator PlayRightJump()
    {
        float frameDelay = 1f / frameRate;

        //while (true)
        //
            foreach (Sprite frame in frames)
            {
                spriteRenderer.flipX = false;
                spriteRenderer.sprite = frame;
                yield return new WaitForSeconds(frameDelay);
            }
        //}
        StartCoroutine(PlayRightJump());
    }
}