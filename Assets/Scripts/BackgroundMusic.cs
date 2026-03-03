using UnityEditor.Animations;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic bgmusic;
    private void Awake()
    {
        //if(bgmusic != null)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    bgmusic = this;
        //}
        //Don't delete this object when a new scene loads
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
