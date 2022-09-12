using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void PlayLevel1()
	{
		SceneManager.LoadScene("BlockPusher1");
	}

	public void PlayLevel2()
	{
		SceneManager.LoadScene("BlockPusher2");
	}

	public void PlayLevel3()
	{
		SceneManager.LoadScene("BlockPusher3");
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
