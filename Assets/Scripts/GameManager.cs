using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	GameObject levelEndOverlay;

	[SerializeField]
	GameObject player;

	[SerializeField]
	GameObject goal;

	private void Update()
	{
		if (player.transform.position == goal.transform.position)
			LevelEnd();
	}

	public void LevelEnd()
	{
		levelEndOverlay.SetActive(true);
	}
}
