using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour 
{
	public GameObject deathExplosion;
	public float HP = 10;
	public Boid boid = null;

	// Use this for initialization
	void Start () 
	{
		
		deathExplosion.SetActive (false);
		boid = this.gameObject.gameObject.GetComponent<Boid> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "EmpireBullet" && this.gameObject.tag == "Rebels") 
		{
			Destroy (col.gameObject);
			HP --;
			if (HP == 0) 
			{		
				boid.enabled = false;
				deathExplosion.SetActive (true);
				Destroyed();
			}
		}

		if (col.gameObject.tag == "RebelBullet" && this.gameObject.tag == "Empire") 
		{
			Destroy (col.gameObject);
			HP --;
			if (HP == 0) 
			{
				boid.enabled = false;
				deathExplosion.SetActive (true);
				Destroyed();
			}
		}
	}

	public void Destroyed()
	{
		foreach (Transform t in this.GetComponentsInChildren<Transform>())
		{
			Rigidbody rb = t.gameObject.GetComponent<Rigidbody>();
			if (rb == null)
			{
				rb = t.gameObject.AddComponent<Rigidbody>();
			}
			rb.useGravity = true;
			rb.isKinematic = false;
			Vector3 v = new Vector3(
				Random.Range(-5, 5)
				, Random.Range(5, 10)
				, Random.Range(-5, 5)
			);
			rb.velocity = v;
		}
		Destroy (this.gameObject, 2f);
	}

}
