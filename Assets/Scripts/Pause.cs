﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour {

	public bool isPaused;
	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (isPaused)
		{
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
		}
		else 
		{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
		}
	}

	public void Resume()
	{
		isPaused = false;
	}
}




