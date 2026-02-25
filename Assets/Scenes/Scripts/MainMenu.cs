using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStartGame()
    {
        string sceneDisplay = "scene_Mariia";
        Debug.Log("Start the game");
        SceneManager.LoadScene(sceneDisplay);
    }
}
