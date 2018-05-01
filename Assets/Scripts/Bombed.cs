using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombed : MonoBehaviour 
{
	GameManager gm;

	// Use this for initialization
	void Start () 
	{
		gm = GetComponentInParent<GameManager> ();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Y-Wing") 
		{
			gm.bombed = true;
		}	
	}
}
