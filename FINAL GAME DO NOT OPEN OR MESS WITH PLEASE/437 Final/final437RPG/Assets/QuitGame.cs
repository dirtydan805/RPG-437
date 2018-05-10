using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour {

	public int sceneLoader;

	public void QuitOnClick()
	{
		SceneManager.LoadScene (sceneLoader);
	}
}
