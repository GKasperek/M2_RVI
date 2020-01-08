using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;

	public Button b1;
	public Button b2;

	// Use this for initialization
	void Start () {
		camera1 = this.camera1;
		Button btn1 = b1.GetComponent<Button> ();
		btn1.onClick.AddListener (SwitchCam);

		Button btn2 = b2.GetComponent<Button> ();
		btn2.onClick.AddListener (SwitchCam);
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Tab)) {
			SwitchCam ();
		}
		if (Input.GetKeyUp (KeyCode.L)) {
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
