using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public static GameMaster Instance;

	void Awake()
	{
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy (this);
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);;
	}

}
