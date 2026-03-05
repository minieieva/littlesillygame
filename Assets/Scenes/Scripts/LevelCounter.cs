using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    //public static LevelCounter Instance { get; private set; } // Static reference to the instance
    public static int level = 1;

    private void Awake()
    {
            //Instance = this; // Set this as the instance
            //DontDestroyOnLoad(this.gameObject); // Persist across scenes
    }

    public void AddLevel()
    {
        level++;
    }
}