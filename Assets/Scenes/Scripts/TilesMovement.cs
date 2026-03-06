using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using UnityEngine.SceneManagement;

public class TilesMovement : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] private TileBase groundTile;   
    [SerializeField] private Vector3Int holeStart = new Vector3Int(5, 0, 0);
    [SerializeField] private Vector3Int holeDirection   = new Vector3Int(-1, 0, 0);   
    [SerializeField] private int holeSteps = 3;
    // [SerializeField] private float holeStepDelay = 100f;    
    private bool holeRunning = false;
    private bool holeTriggered = false;
    private Bunnydies BunnyDies;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BunnyDies = GetComponent<Bunnydies>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tilemap == null) return;

        Vector3Int cell = tilemap.WorldToCell(transform.position);
        if(tilemap.GetTile(cell) == null)
        {
            BunnyDies.Dies();
        }

        if (cell == new Vector3Int(2, 0, 0) && !holeRunning && !holeTriggered)
        {
            //that stops the coroutine from starting again every frame
            holeTriggered = true;
            StartCoroutine(MoveHole());
        }
    }
    private IEnumerator MoveHole()
    {
        holeRunning = true;

        Vector3Int current = holeStart;

        //Gets the tile at the start position of the hole
        TileBase currentOriginal = tilemap.GetTile(current);

        // Remove first tile 
        tilemap.SetTile(current, null);
        // yield return new WaitForSeconds(1);

        for (int i = 0; i < holeSteps; i++)
        {
            if(currentOriginal == null && current == transform.position)
            {
                BunnyDies.Dies();
            }
            
            yield return new WaitForSeconds(1);

            Vector3Int next = current + holeDirection;

            // Save next tile before removing it
            TileBase nextOriginal = tilemap.GetTile(next);


            // if (nextOriginal == null)
            // {

            //     break;
            // }

            // Restore the previous cell using the tile we saved earlier
            tilemap.SetTile(current, currentOriginal);


            tilemap.SetTile(next, null);

            current = next;

            currentOriginal = nextOriginal;

        }

        holeRunning = false;
    }
}
