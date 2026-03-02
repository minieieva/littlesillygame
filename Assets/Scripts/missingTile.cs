using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using UnityEngine.SceneManagement;

public class missingTile : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Transform player;
    [SerializeField] Vector3Int triggerCell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int playercell = tilemap.WorldToCell(player.position);

        if (playercell == triggerCell)
            TileDisappear();
    }

    private void TileDisappear()
    {
        tilemap.SetTileFlags(triggerCell, TileFlags.None);
        tilemap.SetColor(triggerCell, Color.black);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
