using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(LoadNext());
    }

    private IEnumerator LoadNext()
    {
        // show text animation
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(nextSceneName);
    }
}
