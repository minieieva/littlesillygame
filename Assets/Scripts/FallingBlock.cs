using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using UnityEngine.SceneManagement;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Transform player;
    [SerializeField] Vector3Int triggerCell;
    [SerializeField] Vector2Int direction = Vector2Int.down;
    [SerializeField] float stepDelay = 0.01f;
    private Bunnydies BunnyDies;
    private Animations BlockBreaks;
    private MovementPlayer StopsMoving;

    [SerializeField] GameObject targetObject;    

    bool moving;
    bool stopsMoving = false;

    void Start()
    {
        BunnyDies = player.GetComponent<Bunnydies>();
        BlockBreaks = GetComponent<Animations>();
        StopsMoving = player.GetComponent<MovementPlayer>();
    }

    void Update()
    {

        if (moving) return;

        // if (tilemap == null || player == null)
        // {
        //     Debug.LogWarning("Tilemap or Player not assigned");
        //     return;
        // }

        Vector3Int playerCell = tilemap.WorldToCell(player.position);

        // DEBUG: See what cell the player is currently in
        Debug.Log("Player cell: " + playerCell + " | Trigger cell: " + triggerCell);

        if (playerCell.x == triggerCell.x)
        {
            StartCoroutine(MoveLine());
        }

    }
    private void Stops()
    {
        stopsMoving = true;
    }

    IEnumerator MoveLine()
    {
        moving = true;

        // stops the block from keep falling when hitting bunny
        while (!stopsMoving)
        {
            Vector3Int cell = tilemap.WorldToCell(transform.position);
            Vector3Int nextCell = cell + new Vector3Int(direction.x, direction.y, 0);

            if (!tilemap.cellBounds.Contains(nextCell))
                break;
        Vector2 nextWorldPos = tilemap.GetCellCenterWorld(nextCell);

        Collider2D hit = Physics2D.OverlapPoint(nextWorldPos);

        if (hit != null && hit.gameObject != gameObject)
        {
            // Something is blocking the fall
            break;
        }

        transform.position = nextWorldPos;

        yield return new WaitForSeconds(stepDelay);
        }

        moving = false;
    }

private void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject == targetObject)
    {
        StopsMoving.Die();
        Stops();
        BunnyDies.Dies();
        BlockBreaks.Dies();
        StartCoroutine(DestroyAfterDelay());
    }
}

private IEnumerator DestroyAfterDelay()
{

    // yield return new WaitForSeconds(3f);
    // Destroy(gameObject);
    // Destroy(targetObject);
    
    yield return new WaitForSeconds(1);
    SceneManager.LoadScene(0);
}
}
