using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointageNavigation : MonoBehaviour {

	public Camera pointCam;

	private float angle;
	private float speed = 100.0f;

	private float axeY;
	private float offsetY;
	private float axeX;

	private Plane plane;
	private float dist;

	private Vector3 screenSpace;
	private Vector3 offset;

	private Vector3 point;
	private Vector3 planeNormal; 
	private Vector3 planeOrigin;

	// Use this for initialization
	void Start () {
		plane =  new Plane(Vector3.up, 0);
		dist = 20.0f;
		planeNormal = new Vector3 (0, 1, 0);
		planeOrigin = pointCam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Clic gauche pour delock la camera
		if (Input.GetMouseButton (0)) {
			if (Cursor.lockState != CursorLockMode.Locked) {
				Vector3 point;
				Ray ray = pointCam.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (ray, out dist)) {
					point = ray.GetPoint (dist);
					Vector3 v = point - planeOrigin;
					Vector2 d = Vector3.Project (v, planeNormal.normalized);
					Vector3 projectPoint = point - (Vector3)d;
					//pointCam.transform.LookAt (projectPoint);
					pointCam.transform.LookAt (point);
				/*	if (Input.GetAxis ("Mouse X") < -1 ) {
						pointCam.transform.RotateAround(point,Vector3.up,100 * Time.deltaTime);
						pointCam.transform.LookAt (point);

					}

					if (Input.GetAxis ("Mouse X") > 1) {
						pointCam.transform.RotateAround(point,Vector3.up,-100 * Time.deltaTime);
						pointCam.transform.LookAt (point);

					}*/
				}
				if (Input.GetAxis ("Mouse Y") < 0) {
					pointCam.transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
				}



					
				Cursor.lockState = CursorLockMode.Locked;

			} else {
				Cursor.lockState = CursorLockMode.None;
			}


		}


		// Si la camera est bloqué
		if (Cursor.lockState == CursorLockMode.Locked) {
			makeRotate ();
		}
	}

	void makeRotate(){
		axeY = Input.GetAxis ("Mouse Y");

		transform.Rotate(-axeY, 0, 0);

		angle = transform.eulerAngles.x;
		transform.Rotate (-angle, 0, 0);

		axeX = Input.GetAxis ("Mouse X");
		transform.Rotate (0, axeX, 0);

		transform.Rotate (angle, 0, 0);

	}
}
