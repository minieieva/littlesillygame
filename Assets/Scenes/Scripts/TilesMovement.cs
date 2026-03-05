using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using UnityEngine.SceneManagement;

public class TilesMovement : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] private TileBase groundTile;     // the tile to restore (assign in Inspector)
    [SerializeField] private Vector3Int holeStart = new Vector3Int(5, 0, 0);
    [SerializeField] private Vector3Int holeDir   = new Vector3Int(1, 0, 0);   // move right
    [SerializeField] private int holeSteps = 1;
    [SerializeField] private float holeStepDelay = 1f;    
    private bool holeRunning = false;
    private bool holeTriggered = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (tilemap == null) return;

    Vector3Int cell = tilemap.WorldToCell(transform.position);

    if (cell == new Vector3Int(3, 0, 0) && !holeRunning && !holeTriggered)
    {
        holeTriggered = true;
        StartCoroutine(MoveHole());
    }
    }
private IEnumerator MoveHole()
{
    holeRunning = true;

    Vector3Int current = holeStart;

    // Save what is REALLY on the map at current
    TileBase currentOriginal = tilemap.GetTile(current);
    if (currentOriginal == null)
    {
        holeRunning = false;
        yield break; // nothing to remove/restore
    }

    // Remove first tile
    tilemap.SetTile(current, null);
    tilemap.RefreshTile(current);

    for (int i = 0; i < holeSteps; i++)
    {
        yield return new WaitForSeconds(holeStepDelay);

        Vector3Int next = current + holeDir;

        // Save next tile BEFORE removing it
        TileBase nextOriginal = tilemap.GetTile(next);
        if (nextOriginal == null)
            break;

        // Restore the previous cell using the exact tile that was there
        tilemap.SetTile(current, currentOriginal);
        tilemap.RefreshTile(current);
        Debug.Log($"Tile at holeStart {holeStart} is: " + tilemap.GetTile(holeStart));
        // Remove next cell
        tilemap.SetTile(next, null);
        tilemap.RefreshTile(next);

        // Advance: what we should restore next time is what was originally at "next"
        current = next;
        currentOriginal = nextOriginal;
    }

    holeRunning = false;
}
}
