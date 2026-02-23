using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] public Tilemap Tilemap;
    private Vector2 InitialInput;
    public Vector2 direction;
    private BunnyJumpAnimation animBunny;

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

    private void Forward(Vector2 direction)
    {
        Vector3Int Cell = Tilemap.WorldToCell(transform.position);
        Vector3Int TargetPosition = Cell + new Vector3Int((int)direction.x, (int)direction.y, 0);

        // Got this solution from chatgpt
        BoundsInt bounds = Tilemap.cellBounds;

        if (!bounds.Contains(TargetPosition))
        return;
        // 

        Vector2 FinalPosition = Tilemap.GetCellCenterWorld(TargetPosition);

        // Check if a collider exist at target position https://docs.unity3d.com/ScriptReference/Physics2D.OverlapPoint.html
        Collider2D hit = Physics2D.OverlapPoint(FinalPosition);

        if (hit != null){
            
            Vector3Int blockTarget = TargetPosition + new Vector3Int((int)direction.x, (int)direction.y, 0);
            // Check if the target position for that block is outside the bounds
            if (!bounds.Contains(blockTarget))
            {
                return;
            }
            Vector2 FinalblockTargetPos = Tilemap.GetCellCenterWorld(blockTarget);
            if (Physics2D.OverlapPoint(FinalblockTargetPos) != null)
                return; 
            
            hit.transform.position = FinalblockTargetPos;
        }

        animBunny.PlayForDuration(); // plays 24 frames = 1 sec (4 frames * 6)
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

    // public Vector2 movementDirection()
    // {
    //     return direction;
    // }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animBunny = GetComponent<BunnyJumpAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}