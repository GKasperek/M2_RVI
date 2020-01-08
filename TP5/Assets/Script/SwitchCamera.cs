using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Tab)) {
			SwitchCam ();
		}
		if (Input.GetMouseButtonDown(0)) {
			if (Cursor.lockState != CursorLockMode.Locked) {
				Cursor.lockState = CursorLockMode.Locked;
			} else {
				Cursor.lockState = CursorLockMode.None;
			}
		}
	}

	void SwitchCam(){
		camera1.enabled = !camera1.enabled;
		camera2.enabled = !camera2.enabled;
	}


}
