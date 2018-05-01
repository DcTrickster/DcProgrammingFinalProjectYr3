using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{

	public GameObject Rbullet;
	public GameObject Ebullet;
	public int shootSpeed = 5000;
	public float maxDist = 100f;
	public bool recharging = false;


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (this.gameObject.tag == "Rebels") 
		{
			if (recharging == false) 
			{
				GameObject bulletClone = GameObject.Instantiate (Rbullet, this.transform.position, Quaternion.Euler (new Vector3 (90, 0, 1))) as GameObject;
				bulletClone.GetComponent<Rigidbody> ().AddForce (transform.forward * shootSpeed);
				StartCoroutine (recharge ());

			}
		}

		if (this.gameObject.tag == "Empire") 
		{
			if (recharging == false) 
			{
				GameObject bulletClone = GameObject.Instantiate (Ebullet, this.transform.position, Quaternion.Euler (new Vector3 (90, 0, 1))) as GameObject;
				bulletClone.GetComponent<Rigidbody> ().AddForce (transform.forward * shootSpeed);
				StartCoroutine (recharge ());

			}
		}
		
	}

	public IEnumerator recharge()
	{
		int randomCharge = Random.Range (3,5);
		
		recharging = true;
		yield return new WaitForSeconds (randomCharge);
		recharging = false;
	}
}
