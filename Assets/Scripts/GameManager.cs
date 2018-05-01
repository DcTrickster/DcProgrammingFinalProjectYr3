using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public bool sendingBombers = false;
	public GameObject[] yWings, aWings, empireShips;
	public int currentTurrets = 5;
	public GameObject milleniumFalcon, advancedTIE, empire, rebels, RebelUI, EmpireUI;
	public bool bombed = false;

	// Use this for initialization
	void Start () 
	{
		foreach (GameObject i in yWings) 
		{
			i.SetActive (false);
		}

		foreach (GameObject i in aWings) 
		{
			i.SetActive (false);
		}

		foreach (GameObject i in empireShips) 
		{
			i.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (currentTurrets == 0) 
		{
			sendingBombers = true;

		}

		if (sendingBombers == true) 
		{
			foreach (GameObject i in yWings) 
			{
				i.SetActive (true);
			}

			foreach (GameObject i in aWings) 
			{
				i.SetActive (true);
			}

			foreach (GameObject i in empireShips) 
			{
				i.SetActive (true);
			}
		}

		foreach (GameObject i in yWings) 
		{
			if (yWings.Length < 1) 
			{
				EmpireWins ();
			}
		}

		if (milleniumFalcon == null) 
		{
			EmpireWins ();
		}

		if (advancedTIE == null) 
		{
			RebelsWin ();
		}

		if (bombed == true) 
		{
			RebelsWin ();
		}
	}

	void RebelsWin()
	{
		empire.SetActive (false);
		RebelUI.SetActive (true);
	}

	void EmpireWins()
	{
		rebels.SetActive (false);
		EmpireUI.SetActive (true);
	}
}
