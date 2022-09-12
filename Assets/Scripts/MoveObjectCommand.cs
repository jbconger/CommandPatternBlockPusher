using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectCommand : Command
{
	private GameObject gameObject;
	private Vector3 previousPosition;
	private Vector3 newPosition;

	MoveObjectCommand(GameObject i_gameObject, Vector3 i_newPosition)
	{
		gameObject = i_gameObject;
		previousPosition = i_gameObject.transform.position;
		newPosition = i_newPosition;
	}

	public override void Execute()
	{
		gameObject.transform.Translate(newPosition);
	}

	public override void Undo()
	{
		gameObject.transform.position = previousPosition;
	}
}
