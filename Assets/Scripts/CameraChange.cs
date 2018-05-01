using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour 
{
	public Camera currentCam;
	public GameObject[] ShipCameras;
	public int camIndex;

	public bool isPaused = false;

	// Use this for initialization
	void Start () 
	{
		ShipCameras = GameObject.FindGameObjectsWithTag("Camera");
		currentCam = ShipCameras [camIndex].GetComponent<Camera>();
		currentCam.enabled = true;
		StartCoroutine (ChangeCam ());

	}

	// Update is called once per frame
	void Update () 
	{
		ShipCameras = GameObject.FindGameObjectsWithTag("Camera");
		currentCam = ShipCameras [camIndex].GetComponent<Camera>();

		if (Input.GetKeyDown (KeyCode.E))
		{
			Toggle ();
		}

	}

	void Toggle()
	{
		isPaused = !isPaused;
	}

	public IEnumerator ChangeCam()
	{



		while (isActiveAndEnabled) 
		{
			if (camIndex < ShipCameras.Length) 
			{
				if (ShipCameras [camIndex].GetComponent<Camera>() == null && currentCam == null) 
				{
					camIndex++;
					currentCam = ShipCameras [camIndex].GetComponent<Camera>();

				} 
				else 
				{
					currentCam.enabled = false;
					ShipCameras [camIndex].GetComponent<Camera> ().enabled = true;
					if (isPaused) 
					{
//						camIndex = camIndex;
					}
					else 
					{
						camIndex++;
					}
					if (camIndex < ShipCameras.Length)
					{
					currentCam = ShipCameras [camIndex].GetComponent<Camera>();
					currentCam.enabled = true;
					}
				}
				
			} 

			if (camIndex >= ShipCameras.Length)
			{
				camIndex = 0;
				camIndex++; 
				currentCam = ShipCameras [camIndex].GetComponent<Camera>();
				currentCam.enabled = true;
			}

			yield return new WaitForSeconds (3);
		}
	}

}
