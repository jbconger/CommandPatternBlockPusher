using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandListManager : MonoBehaviour
{
	private List<MoveObjectCommand> commandList;
	private int currentIndex = -1;

	private void Start()
	{
		commandList = new List<MoveObjectCommand>();
	}

	private void Update()
	{
		if (currentIndex > -1)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				commandList[currentIndex].Undo();
				if (commandList[currentIndex].bIsCrate)
				{
					commandList[currentIndex - 1].Undo();
					currentIndex--;
				}
				currentIndex--;
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				commandList[currentIndex].Execute();
				if (currentIndex + 1 < commandList.Count && commandList[currentIndex + 1].bIsCrate)
				{
					commandList[currentIndex + 1].Execute();
					currentIndex++;
				}
				currentIndex++;
			}
		}
	}

	public void AddCommand(GameObject gameObject, Vector3 newPosition)
	{
		currentIndex++;
		MoveObjectCommand newCommand = new MoveObjectCommand(gameObject, newPosition);
		commandList[currentIndex] = newCommand;

		newCommand.Execute();
		RemoveInvalidCommands();
	}

	private void RemoveInvalidCommands()
	{
		if (currentIndex < 0 && commandList.Count > 0)
			commandList.Clear();

		if (commandList.Count > currentIndex + 1)
			commandList.RemoveRange(currentIndex + 1, commandList.Count - 1);
	}
}
