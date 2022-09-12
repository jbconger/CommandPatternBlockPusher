using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	CommandListManager commandListManager;

	[HideInInspector]
	public AudioSource stepSound;

	private GameObject[] walls;
	private GameObject[] crates;

	private bool bCanMove;

	private void Start()
	{
		stepSound = this.GetComponent<AudioSource>();
		walls = GameObject.FindGameObjectsWithTag("Wall");
		crates = GameObject.FindGameObjectsWithTag("Crate");
		bCanMove = true;
	}

	private void Update()
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
		if (Mathf.Abs(direction.x) < 0.5)
		{
			direction.x = 0;
		}
		else
		{
			direction.y = 0;
		}

		direction.Normalize();

		if (IsBlocked(transform.position, direction))
		{
			return false;
		}
		else
		{
			//transform.Translate(direction); //sans command implementation
			commandListManager.AddCommand(this.gameObject, direction);
			return true;
		}
	}

	bool IsBlocked(Vector3 position, Vector2 direction)
	{
		Vector2 newPosition = new Vector2(position.x, position.y) + direction;

		foreach(GameObject wall in walls)
		{
			if (wall.transform.position.x == newPosition.x && wall.transform.position.y == newPosition.y)
				return true;
		}

		foreach (GameObject crate in crates)
		{
			if (crate.transform.position.x == newPosition.x && crate.transform.position.y == newPosition.y)
			{
				CrateMovement crateMovement = crate.GetComponent<CrateMovement>();
				if (crateMovement && crateMovement.MoveCrate(direction))
					return false;
				else
					return true;
			}
		}

		return false;
	}
}
