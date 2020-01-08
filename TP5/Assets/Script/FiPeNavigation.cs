using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiPeNavigation : MonoBehaviour {

	public float speed = 100.0f;
	public GameObject body;

	private float angle;

	private float axeY;
	private float axeX;

	public float maxAngle = 20f;

	float curAngle = 0f;


	//private bool leaned; 
	// Use this for initialization
	void Start () {
		//leaned = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.D))
		{
			goRight ();
		}
		if(Input.GetKey(KeyCode.Q))
		{
			goLeft ();
		}
		if(Input.GetKey(KeyCode.S))
		{
			goDown ();
		}
		if(Input.GetKey(KeyCode.Z))
		{
			goUp ();
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
		//moveBody ();
		makeRotate ();


	}

	void moveBody(){
		body.transform.position.Set(this.transform.position.x, this.transform.position.y,body.transform.position.z) ;
	}

	void makeRotate(){
		if (Cursor.lockState == CursorLockMode.Locked) {
			axeY = Input.GetAxis ("Mouse Y");
			/*angle = transform.eulerAngles.x + axeY;
			Mathf.Clamp (angle, -90, 90);*/
			transform.Rotate (-axeY, 0, 0);

			angle = transform.eulerAngles.x;
			transform.Rotate (-angle, 0, 0);

			axeX = Input.GetAxis ("Mouse X");
			transform.Rotate (0, axeX, 0);

			transform.Rotate (angle, 0, 0);
		}

	}

	void goUp(){
		angle = transform.eulerAngles.x;
		transform.Rotate (-angle, 0, 0);
		transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
		transform.Rotate (angle, 0, 0);
	}

	void goDown(){
		angle = transform.eulerAngles.x;
		transform.Rotate (-angle, 0, 0);
		transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
		transform.Rotate (angle, 0, 0);
	}

	void goLeft(){
		transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
	}

	void goRight(){
		transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
	}

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

	void leanLeft(){
		float angleZ = transform.eulerAngles.z;
		if (angleZ < 75.0 ||  angleZ > 280.0f) {
			transform.RotateAround(transform.position, new Vector3(0,0,1), 20 * Time.deltaTime);
		}
	}

	void leanRight(){
		float angleZ = transform.eulerAngles.z;
		if (angleZ < 80.0 || angleZ > 285.0f) {
			transform.RotateAround(transform.position, new Vector3(0,0,1), -20 * Time.deltaTime);
		}
	}


		
}
