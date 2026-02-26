using UnityEngine;
using System.Collections;

public class Bunnydies : MonoBehaviour
{
    [SerializeField] public Sprite[] frames;
    [SerializeField] public float frameRate = 24f;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Dies()
    {
        StartCoroutine(PlayDead());
    }
    public IEnumerator PlayDead()
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
