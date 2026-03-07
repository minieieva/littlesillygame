using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class FaderBetweenLoses : MonoBehaviour
{
    public Image image; // Assign in Inspector

    private void Awake()
    {
        // Ensure image is fully black at start
        Color c = image.color;
        c.a = 1f;
        image.color = c;
    }

    private void Start()
    {
        // Fade from black to transparent at scene start
        StartCoroutine(FadeOut(2f));
    }

    // Fade from black to transparent
    public IEnumerator FadeOut(float duration)
    {
        float t = 0f;
        Color c = image.color;
        c.a = 1f; // start fully black
        image.color = c;

        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, t / duration); // alpha from 1 → 0
            image.color = c;
            yield return null;
        }

        c.a = 0f;
        image.color = c; // ensure fully transparent
    }

    // Fade from transparent to black and reload scene
    public IEnumerator FadeIn(float duration)
    {
        MovementPlayer.isDead = true;
        float t = 0f;
        Color c = image.color;
        c.a = 0f; // start transparent
        image.color = c;

        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / duration); // alpha from 0 → 1
            image.color = c;
            yield return null;
        }

        c.a = 1f;
        image.color = c; // ensure fully black

        yield return new WaitForSeconds(0.2f); // optional pause
        MovementPlayer.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Convenience function
    public void FadeToBlackAndReload(float duration)
    {
        StartCoroutine(FadeIn(duration));
    }
}