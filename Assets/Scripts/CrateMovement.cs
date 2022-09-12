using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateMovement : MonoBehaviour
{
	[SerializeField]
	CommandListManager commandListManager;

	[HideInInspector]
	public AudioSource pushSound;

	private GameObject[] walls;
	private GameObject[] crates;

	private void Start()
	{
		pushSound = this.GetComponent<AudioSource>();
		walls = GameObject.FindGameObjectsWithTag("Wall");
		crates = GameObject.FindGameObjectsWithTag("Crate");
	}

	public bool MoveCrate(Vector2 direction)
	{
		if (CrateIsBlocked(transform.position, direction))
			return false;
		else
		{
			//transform.Translate(direction); //sams command implementation
			commandListManager.AddCommand(this.gameObject, direction);
			return true;
		}
	}

	private bool CrateIsBlocked(Vector3 position, Vector2 direction)
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
				return true;
		}

		return false;
	}
}
