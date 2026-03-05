using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSFX : MonoBehaviour
{
    // gameObjects to trigger sfx
    public Tilemap grid;

    public Transform goal;
    public LayerMask obstacles;
    public LayerMask wallLayer;

    private Vector3Int lastCell;

    // get player grid starting position
    void Start()
    {
        lastCell = grid.WorldToCell(transform.position);
    }

    // get player grid current position
    void Update()
    {
        Vector3Int currentCell = grid.WorldToCell(transform.position);

        // if player moved, then check and see if a trigger is pulled to need sfx
        if (currentCell != lastCell)
        {
            TriggerSound(lastCell, currentCell);
            lastCell = currentCell;
        }
    }

    // check if the trigger object is in the next cell
    void TriggerSound(Vector3Int previousCell, Vector3Int currentCell)
    {
        // use the direction that the player moved to check if there is an object ahead of the player
        Vector3Int direction = currentCell - previousCell;

        Vector3 nextPos = grid.GetCellCenterWorld(currentCell + direction);

        Collider2D obstacle = Physics2D.OverlapPoint(nextPos, obstacles);
        Collider2D wall = Physics2D.OverlapPoint(nextPos, wallLayer);

        // if the collider detects an object ahead then play a sound effect
        if (obstacle != null)
        {
            SoundEffects.SFX.Play(SoundEffects.SFX.bunnyDies);
            return;
        }

        if (wall != null)
        {
            SoundEffects.SFX.Play(SoundEffects.SFX.wallHit);
            return;
        }

        Vector3Int goalCell = grid.WorldToCell(goal.position);

        if (currentCell == goalCell)
        {
            SoundEffects.SFX.Play(SoundEffects.SFX.goal);
            return;
        }

        // SoundEffects.SFX.Play(SoundEffects.SFX.move);
    }
}