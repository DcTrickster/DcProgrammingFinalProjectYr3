using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour {

	Vector3 source;
	Vector3 target;	
	public GameObject destination;
	public float fleeDistance;
	public float maxSpeed = 5f;
	Vector3 outputVelocity;

	public Vector3 force;
	public Vector3 velocity;
	public Vector3 acceleration;
	float mass = 1f;
	float maxForce = 10f;
	public float slowingDistance = 10;
	public const float proxyDist = 5f;

	Vector3 lookDirection; 
	public float turnSpeed;
	public float moveSpeed;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		source = transform.position;
		target = destination.transform.position;
		outputVelocity = FleeAway (source, target);

		force = Calculate ();
		force = Vector3.ClampMagnitude (force,maxForce);
		acceleration = force / mass;
		velocity += acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		velocity *= 0.99f;
		transform.position += velocity * Time.deltaTime;
	}

	void FixedUpdate()
	{
		lookDirection = target - source;
		Quaternion rotate = Quaternion.LookRotation (lookDirection.normalized);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotate, Time.deltaTime * turnSpeed);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotate, Time.deltaTime * turnSpeed);
		transform.Translate (new Vector3 (0, 0, moveSpeed) * Time.deltaTime);

	}

	Vector3 Calculate()
	{
		if (Vector3.Distance (source, target) < proxyDist)
		{
			return FleeAway (source, target);
		}

		else
			
		{
			return ArriveForce();
		}
	}

	public Vector3 FleeAway (Vector3 source, Vector3 target)
	{
		Vector3 toTarget = target - source;
		if (toTarget.magnitude > fleeDistance)
		{
			return Vector3.zero;
		}
		else
		{
			toTarget.Normalize();
		}
		Vector3 desired = toTarget * maxSpeed;
		return outputVelocity - desired;
	}

	Vector3 ArriveForce()
	{
		Vector3 toTarget = target - transform.position;
		float dist = toTarget.magnitude;
		float ramped = maxSpeed * (dist / slowingDistance);
		float clamped = Mathf.Min (ramped, maxSpeed);
		Vector3 desired = clamped * (toTarget / dist);
		return desired - velocity;
	}
}
