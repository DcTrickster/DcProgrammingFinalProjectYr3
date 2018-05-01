using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviourScript : MonoBehaviour 
{
	Seek seekScript;
	Arrive arriveScript;

	public GameObject[] rebels, empire;
	public int enemyIndex;
	public GameObject currentEnemy;
	public bool fixedCam = false;
	public bool movingCam = true;

	// Use this for initialization
	void Start () 
	{
		seekScript = this.gameObject.GetComponent<Seek> ();
		arriveScript = this.gameObject.GetComponent<Arrive> ();

		seekScript.enabled = false;
		arriveScript.enabled = true;

		empire = GameObject.FindGameObjectsWithTag ("Empire");
		rebels = GameObject.FindGameObjectsWithTag ("Rebels");

		if (this.gameObject.tag == "Rebels")
		{
			currentEnemy = empire [enemyIndex].GetComponent<GameObject>();
		}

		if (this.gameObject.tag == "Empire")
		{
			currentEnemy = rebels [enemyIndex].GetComponent<GameObject>();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		empire = GameObject.FindGameObjectsWithTag ("Empire");
		rebels = GameObject.FindGameObjectsWithTag ("Rebels");
	}

	public void OnTriggerEnter(Collider other)
	{
			if (this.gameObject.tag == "Empire" && other.gameObject.tag == "Rebels") {
				seekScript.enabled = true;
				arriveScript.enabled = false;
				seekScript.targetGameObject = other.gameObject;
			if (seekScript.targetGameObject == null) 
			{
				StartCoroutine (ChangeTarget ());

			}
			} 


		if (this.gameObject.tag == "Rebels" && other.gameObject.tag == "Empire") {
			seekScript.enabled = true;
			arriveScript.enabled = false;
			seekScript.targetGameObject = other.gameObject;
		} 


		if (other.gameObject.tag == "Space")
		{
			seekScript.enabled = false;
			arriveScript.enabled = true;
		}
	}

	IEnumerator ChangeTarget()
	{
		if (this.gameObject.tag == "Rebels" && currentEnemy == null) 
		{
			seekScript.target = currentEnemy.transform.position;
			currentEnemy = empire [enemyIndex].GetComponent<GameObject>();
			enemyIndex++;

		}

		if (this.gameObject.tag == "Empire" && currentEnemy == null) 
		{
			seekScript.target = currentEnemy.transform.position;
			currentEnemy = rebels [enemyIndex].GetComponent<GameObject>();
			enemyIndex++;

		}

		yield return new WaitForEndOfFrame();
	}

}
