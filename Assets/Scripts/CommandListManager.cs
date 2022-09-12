using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandListManager : MonoBehaviour
{
	private List<MoveObjectCommand> commandList;
	private int currentIndex;

	private void Start()
	{
		commandList = new List<MoveObjectCommand>();
		currentIndex = -1;
	}

	private void Update()
	{
		if (currentIndex > -1 && currentIndex < commandList.Count)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				commandList[currentIndex].Undo();
				commandList[currentIndex].gameObject.GetComponent<AudioSource>().Play();
				if (currentIndex - 1 > -1 && commandList[currentIndex - 1].bIsCrate)
				{
					commandList[currentIndex - 1].Undo();
					commandList[currentIndex].gameObject.GetComponent<AudioSource>().Play();
					currentIndex--;
				}
				currentIndex--;
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				if (currentIndex + 1 < commandList.Count)
				{
					currentIndex++;
					commandList[currentIndex].Execute();
					commandList[currentIndex].gameObject.GetComponent<AudioSource>().Play();

					if (commandList[currentIndex].bIsCrate)
					{
						currentIndex++;
						commandList[currentIndex].Execute();
						commandList[currentIndex].gameObject.GetComponent<AudioSource>().Play();
					}
				}
			}
		}
	}

	public void AddCommand(GameObject gameObject, Vector3 newPosition)
	{
		currentIndex++;
		MoveObjectCommand newCommand = new MoveObjectCommand(gameObject, newPosition);
		commandList.Insert(currentIndex, newCommand);

		newCommand.Execute();
		commandList[currentIndex].gameObject.GetComponent<AudioSource>().Play();
		RemoveInvalidCommands();
	}

	private void RemoveInvalidCommands()
	{
		if (currentIndex < 0 && commandList.Count > 0)
			commandList.Clear();

		if (currentIndex < commandList.Count - 1 && currentIndex > -1)
			commandList.RemoveRange(currentIndex + 1, commandList.Count - 1);
	}
}
