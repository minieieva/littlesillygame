using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Tilemap Tilemap;
    private Vector2 InitialInput;
    private Vector2 direction;

    public void OnMove(InputValue input)
    {
        InitialInput = input.Get<Vector2>();

        direction = Cardinal(InitialInput);

        if (direction != Vector2.zero)
        {
            Forward(direction);
        }
        else
        {
            return;
        }
    }

    public void Forward(Vector2 direction)
    {
        Vector3Int Cell = Tilemap.WorldToCell(transform.position);
        Vector3Int TargetPosition = Cell + new Vector3Int((int)direction.x, (int)direction.y, 0);

        // Chat Solution
        BoundsInt bounds = Tilemap.cellBounds;

        if (!bounds.Contains(TargetPosition))
            return;
        //end of chat solution

        Vector2 FinalPosition = Tilemap.GetCellCenterWorld(TargetPosition);
        transform.position = FinalPosition;
    }

    private Vector2 Cardinal(Vector2 InitialInput)
    {
        if(Math.Abs(InitialInput.x) < Math.Abs(InitialInput.y))
        {
            return new Vector2(0,Math.Sign(InitialInput.y));
        }
        if(Math.Abs(InitialInput.x) > Math.Abs(InitialInput.y))
        {
            return new Vector2(Math.Sign(InitialInput.x), 0);
        }
        return Vector2.zero;

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
