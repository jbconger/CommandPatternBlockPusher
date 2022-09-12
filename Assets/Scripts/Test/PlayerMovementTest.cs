using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{

    private GameObject[] walls;
    private GameObject[] pushableBlocks;

    private bool bCanMove;

    // Start is called before the first frame update
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        pushableBlocks = GameObject.FindGameObjectsWithTag("Block");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();

        if(moveDirection.sqrMagnitude > 0.5)
		{
            if (bCanMove)
			{
                bCanMove = false;
                MovePlayer(moveDirection);
			}
		}
		else
		{
            bCanMove = true;
		}
    }

    public bool MovePlayer(Vector2 direction)
	{
        if(Mathf.Abs(direction.x) < 0.5)
		{
            direction.x = 0;
		}
		else
		{
            direction.y = 0;
		}

        direction.Normalize();

        if (PlayerIsBlocked(transform.position, direction))
		{
            return false;
		}
        else
		{
            transform.Translate(direction);
            return true;
		}
	}

    public bool PlayerIsBlocked(Vector3 position, Vector2 direction)
	{
        Vector2 newPosition = new Vector2(position.x, position.y) + direction;

        foreach(GameObject wall in walls)
		{
            if (wall.transform.position.x == newPosition.x && wall.transform.position.y == newPosition.y)
                return true;
		}

        foreach (GameObject block in pushableBlocks)
		{
            if(block.transform.position.x == newPosition.x && block.transform.position.y == newPosition.y)
			{
                BlockMovement blockPush = block.GetComponent<BlockMovement>();
                if (blockPush && blockPush.MoveBlock(direction))
                    return false;
                else
                    return true;
			}
		}

        return false;
	}
}
