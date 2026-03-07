using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingBoxSFX : MonoBehaviour
{
    // gameObjects to trigger sfx
    public Tilemap grid;

    public Transform player;
    public Transform pushableBlock;

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
        
        if (currentCell != lastCell)
        {
            TriggerSound(currentCell);
        }
        // if (currentCell != lastCell)
        // {
        //     SoundEffects.SFX.Play(SoundEffects.SFX.boxMove);
        //     lastCell = currentCell;
        // }
    }

    // check if a trigger object is ahead of the falling block
    public void TriggerSound(Vector3Int currentCell)
    {
        Vector3Int playerCell = grid.WorldToCell(player.position);
        Vector3Int blockCell = grid.WorldToCell(pushableBlock.position);

        if (playerCell == currentCell)
        {
            SoundEffects.SFX.Play(SoundEffects.SFX.bunnyDie);
            return;
        }
        if (blockCell == currentCell)
        {
            SoundEffects.SFX.Play(SoundEffects.SFX.boxHit);
            return;
        }
    }
}