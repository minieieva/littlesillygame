using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounterText : MonoBehaviour
{
    public TextMeshProUGUI levelText; 
    void Start()
    {
        levelText.text = "LEVEL " + LevelCounter.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
