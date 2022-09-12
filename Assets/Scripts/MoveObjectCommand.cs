using UnityEngine;

public class MoveObjectCommand : Command
{
	[HideInInspector]
	public GameObject gameObject;
	private Vector3 previousPosition;
	private Vector3 newPosition;
	public bool bIsCrate;

	public MoveObjectCommand(GameObject i_gameObject, Vector3 i_newPosition)
	{
		gameObject = i_gameObject;
		previousPosition = i_gameObject.transform.position;
		newPosition = i_newPosition;
		if (i_gameObject.CompareTag("Crate"))
			bIsCrate = true;
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