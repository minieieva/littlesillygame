using UnityEngine;
using UnityEngine.SceneManagement;

public class UiNavigation : MonoBehaviour
{
    public void OnClickStartGame()
    {
        string sceneDisplay = "scripts";
        Debug.Log("Start the game");
        SceneManager.LoadScene(sceneDisplay);
    }

    public void OnClickExitGame()
    {
        Debug.Log("Game is exiting");
        //Application.Quit();
    }
}
