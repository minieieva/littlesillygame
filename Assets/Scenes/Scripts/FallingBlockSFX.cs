using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingBoxSFX : MonoBehaviour
{
    // gameObjects to trigger sfx
    public Tilemap grid;

    public LayerMask playerLayer;
    public LayerMask boxLayer;

    private Vector3Int lastCell;

    // get the starting grid position of the falling block
    void Start()
    {
        lastCell = grid.WorldToCell(transform.position);
    }

    // get the current grid position of the falling block
    void Update()
    {
        Vector3Int currentCell = grid.WorldToCell(transform.position);

        // if (currentCell != lastCell)
        // {
        //     SoundEffects.SFX.Play(SoundEffects.SFX.boxMove);
        //     lastCell = currentCell;
        // }
    }

    // check if a trigger object is ahead of the falling block
    public void CheckBlocked(Vector2 direction)
    {
        // use the direction that block is travelling/falling to check if there is an object ahead of it
        Vector3 checkPos = transform.position + (Vector3)direction;

        // if there is an object ahead then play a sound effect
        if (Physics2D.OverlapPoint(checkPos, boxLayer))
        {
            SoundEffects.SFX.Play(SoundEffects.SFX.boxHit);
            return;
        }
        if (Physics2D.OverlapPoint(checkPos, playerLayer))
        {
            SoundEffects.SFX.Play(SoundEffects.SFX.bunnyDie);
            return;
        }
    }
}