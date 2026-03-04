using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class CookieTransporter : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Transform player;
    [SerializeField] Vector3Int triggerCell;
    private CookieAnimation animCookie;

    void Start()
    {
        animCookie = GetComponent<CookieAnimation>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3Int playerCell = tilemap.WorldToCell(player.position);
       // Debug.Log("Player cell: " + playerCell + " | Trigger cell: " + triggerCell);

        if (playerCell.x == triggerCell.x && playerCell.y == triggerCell.y)
        {
            MovementPlayer.isDead = true;
            triggerCell.x = 0;
            triggerCell.y = 0;
            animCookie.PlayTransportAnimation();
            StartCoroutine(Transportation());
        }
    }

    private IEnumerator Transportation()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("transition_scene");
    }
}
