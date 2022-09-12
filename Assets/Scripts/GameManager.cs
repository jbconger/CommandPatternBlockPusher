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

	private AudioSource goalSound;
	private bool playSound = true;

	private void Awake()
	{
		goalSound = this.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (player.transform.position == goal.transform.position && playSound)
			LevelEnd();
	}

	public void LevelEnd()
	{
		playSound = false;
		levelEndOverlay.SetActive(true);
		goalSound.Play();
	}
}
