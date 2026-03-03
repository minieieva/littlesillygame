using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiNavigation : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    private bool muted = false;
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
    public void OnClickSound()
    {
        Debug.Log("Sound button clicked");
        muted = !muted;

        AudioListener.pause = muted;

        if (muted)
        {
            buttonImage.sprite = soundOffSprite;
        }
        else
        {
            buttonImage.sprite = soundOnSprite;
        }
    }
}
