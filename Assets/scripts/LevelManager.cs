﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LaadLevel (string level) {
		SceneManager.LoadScene (level);
	}

	public void loadNextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void StopSpel () {
		Application.Quit ();
	}
}