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
        Debug.Log("Go to levels screen when implemented");
        //SceneManager.LoadScene("levels_screen");
    }

}
