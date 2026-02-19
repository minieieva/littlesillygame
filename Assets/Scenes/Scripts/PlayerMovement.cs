using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Tilemap grid; 

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();

        Vector3Int position = new Vector3Int(
            (int)Mathf.Round(movement.x),
            (int)Mathf.Round(movement.y),
            0
        );

        Move(position);
    }

    private void Move(Vector3Int direction)
    {
        Vector3Int currentCell = grid.WorldToCell(transform.position);

        Vector3Int targetCell = currentCell + direction;

        transform.position = grid.GetCellCenterWorld(targetCell);
    }
}
