using UnityEngine;

public class BlockPusher : MonoBehaviour
{

    // private MovementPlayer MovementPlayer;

    private void OnTriggerEnter2D(Collider2D otherObjectCollider)
    {
        // from the object that just collided get the script MovementPlayer
        var BunnyMovement = otherObjectCollider.GetComponent<MovementPlayer>();

        // this is in case something else collides into it that doesn't have a MovementPlayer 
        if (BunnyMovement == null)
            return;

        // and here if the object that collided has a Tag player then the new position 
        // of the box is gonna be in the same direction as the bunny and of unit 1
        if (otherObjectCollider.CompareTag("Player"))
        {
            Vector2 direction2 = BunnyMovement.direction; 

            Vector3 Nextposition = transform.position + new Vector3(direction2.x, direction2.y, 0f); 

            Vector3Int position = BunnyMovement.Tilemap.WorldToCell(Nextposition);
            BoundsInt bounds = BunnyMovement.Tilemap.cellBounds;
            if (!bounds.Contains(position))
            return;

            transform.position = Nextposition;
        }
        else
        {
            return;
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
