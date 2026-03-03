//reference: https://www.youtube.com/watch?v=CrkO1Y0nHFY
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FaderBetweenLoses : MonoBehaviour
{
    public Image image;

    public void FadeAndLoad(float duration)
    {
        StartCoroutine(Fader(duration));
    }

    public IEnumerator Fader(float duration)
    {
        float t = 0;
        Color c = image.color;
        while(t< duration)
        {
            t += Time.deltaTime;
            c.a = t / duration;
            image.color = c;
            yield return null; //one frame
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator FadeOut()
    {
        float t = 0;
        Color c = image.color;
        while (t < 1)
        {
            t += Time.deltaTime;
            c.a = 1f - (t/1f);
            image.color = c;
            yield return null; //one frame
        }
    }


}
