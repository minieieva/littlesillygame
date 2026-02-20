using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    

    private void pushBlock(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
