using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(LoadNext());
        MovementPlayer.isDead = false;
    }

    private IEnumerator LoadNext()
    {
        // show text animation
        yield return new WaitForSeconds(2);
        string levelScene = "level" + LevelCounter.level.ToString();

        SceneManager.LoadScene(levelScene);
        MovementPlayer.isDead = false;
    }
}
