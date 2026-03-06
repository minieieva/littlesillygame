using UnityEngine;
using System.Collections;

public class Bunnydies : MonoBehaviour
{
    [SerializeField] public Sprite[] frames;
    [SerializeField] public float frameRate = 24f;
    private SpriteRenderer spriteRenderer;
    public FaderBetweenLoses scriptFaderRef;
    private MovementPlayer stopsMoving;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scriptFaderRef = GetComponent<FaderBetweenLoses>();
        stopsMoving = GetComponent<MovementPlayer>();
    }

    public void Dies()
    {
        StartCoroutine(DieSequence());
        stopsMoving.Die();
    }

    private IEnumerator DieSequence()
    {
        yield return StartCoroutine(PlayDead());      // play death animation
        yield return StartCoroutine(scriptFaderRef.FadeIn(1f)); // fade and reload

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
