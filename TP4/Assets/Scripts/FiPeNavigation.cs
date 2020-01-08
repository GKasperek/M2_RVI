using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiPeNavigation : MonoBehaviour {

	public float speed = 100.0f;
	public GameObject body;

	private float angle;

	private float axeY;
	private float axeX;

	public float maxAngle = 20f;

	private float curAngle = 0f;

	private bool freelook;


	//private bool leaned; 
	// Use this for initialization
	void Start () {
		freelook = false;
		//leaned = true;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.D))
		{
			if (!Physics.Raycast (transform.position, transform.TransformDirection (Vector3.right), 1)) {
				goRight ();
			}
		}
		if(Input.GetKey(KeyCode.Q))
		{
			if (!Physics.Raycast (transform.position, transform.TransformDirection (Vector3.left), 1)) {
				goLeft ();
			}
		}
		if(Input.GetKey(KeyCode.S))
		{
			if (!Physics.Raycast (transform.position, transform.TransformDirection (Vector3.back),1)) {
				if (freelook) {
					freeLookMove (-speed);
				} else {
					goDown ();
				}
			}
		}
		if(Input.GetKey(KeyCode.Z))
		{
			//Debug.Log (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), 1));
			if (!Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), 1)) {
				if (freelook) {
					freeLookMove (speed);
				} else {
					goUp ();
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine("jump");
		}
		if (Input.GetKey (KeyCode.A)) {
			leanLeft ();
		}
		if (Input.GetKey (KeyCode.E)) {
			leanRight ();
		} 
		if (Input.GetKey (KeyCode.F)) {
			freelook = !freelook;
			 Debug.Log(freelook);
		}
			
		moveBody ();
		if (Cursor.lockState == CursorLockMode.Locked) {
			makeRotate ();
		}


	}

	/*
	 * Function to move gameobject at coordonate of the camera (simulate body)
	 */
	void moveBody(){
		body.transform.position.Set(this.transform.position.x, this.transform.position.y,body.transform.position.z) ;
	}

	/**
	 * Rotate
	 */
	void makeRotate(){
		axeY = Input.GetAxis ("Mouse Y");
		transform.Rotate(-axeY, 0, 0);

		angle = transform.eulerAngles.x;
		transform.Rotate (-angle, 0, 0);

		axeX = Input.GetAxis ("Mouse X");
		transform.Rotate (0, axeX, 0);

		transform.Rotate (angle, 0, 0);

	}

	/**
	 * Move up
	 */
	void goUp(){
		angle = transform.eulerAngles.x;
		transform.Rotate (-angle, 0, 0);
		transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
		transform.Rotate (angle, 0, 0);
	}

	/**
	 * Move back
	 */
	void goDown(){
		angle = transform.eulerAngles.x;
		transform.Rotate (-angle, 0, 0);
		transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
		transform.Rotate (angle, 0, 0);
	}

	/*
	 * Move left
	 */
	void goLeft(){
		angle = transform.eulerAngles.z;
		transform.Rotate (0, 0, -angle);
		transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		transform.Rotate (0, 0, angle);
	}

	/*
	 * Move right
	 */
	void goRight(){
		angle = transform.eulerAngles.z;
		transform.Rotate (0, 0, -angle);
		transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		transform.Rotate (0, 0, angle);
	}

	/**
	 * IEnumerator to jump
	 */
	IEnumerator jump(){
		float y;
		for (int i = 0; i < 20; i++) {
			transform.Translate (new Vector3 (0f, speed/2 * Time.deltaTime , 0f));
			yield return null;
		}
		for (int i = 0; i < 20; i++) {
				transform.Translate (new Vector3 (0f, -speed/2 * Time.deltaTime , 0f));
				yield return null;
		}
	}

	/**
	 * Function for lean left
	 */
	void leanLeft(){
		float angleZ = transform.eulerAngles.z;
		if (angleZ < 75.0 ||  angleZ > 280.0f) {
			transform.RotateAround(transform.position, new Vector3(0,0,1), 20 * Time.deltaTime);
		}
	}

	/**
	 * Function for lean right
	 */
	void leanRight(){
		float angleZ = transform.eulerAngles.z;
		if (angleZ < 80.0 || angleZ > 285.0f) {
			transform.RotateAround(transform.position, new Vector3(0,0,1), -20 * Time.deltaTime);
		}
	}


	/**
	 * Function for move un freelook mode
	 */
	void freeLookMove(float s){
		transform.Translate(new Vector3(0,0,s * Time.deltaTime));
	}
		
}
