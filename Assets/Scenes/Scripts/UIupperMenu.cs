using UnityEngine;
using UnityEngine.SceneManagement;

public class UIupperMenu : MonoBehaviour
{
    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene("levels_scene");
    }

}
