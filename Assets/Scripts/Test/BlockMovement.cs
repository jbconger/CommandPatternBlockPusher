using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private GameObject[] walls;
    private GameObject[] pushableBlocks;

    // Start is called before the first frame update
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        pushableBlocks = GameObject.FindGameObjectsWithTag("Block");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool MoveBlock(Vector2 direction)
    {
        if(BlockIsBlocked(transform.position, direction))
		{
            return false;
		}
        else
		{
            transform.Translate(direction);
            return true;
		}
    }

    public bool BlockIsBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPosition = new Vector2(position.x, position.y) + direction;

        foreach (GameObject wall in walls)
        {
            if (wall.transform.position.x == newPosition.x && wall.transform.position.y == newPosition.y)
                return true;
        }

        foreach (GameObject block in pushableBlocks)
        {
            if (block.transform.position.x == newPosition.x && block.transform.position.y == newPosition.y)
                return true;
        }

        return false;
    }
}
