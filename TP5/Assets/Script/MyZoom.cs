using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyZoom : MonoBehaviour {


	private float m_distanceZ;
	private bool pressed;
	private float enterLeftUp,enterRightDown;
	private Plane m_plane;
	private Vector3 m_DistanceFromCamera;

	private Vector3 pointLeftUp, pointRightDown;

	// Use this for initialization
	void Start () {
		m_distanceZ = 2.0f;
		enterLeftUp = 0.0f;
		enterRightDown = 0.0f;
		pressed = false;
		m_DistanceFromCamera = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + m_distanceZ);
		m_plane = new Plane (Vector3.forward, m_DistanceFromCamera);


	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.y < 90 && transform.rotation.y > 90) {
			m_distanceZ = -2.0f;
			m_DistanceFromCamera = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - m_distanceZ);
			m_plane.SetNormalAndPosition (Vector3.forward, m_DistanceFromCamera);

		} else {
			m_distanceZ = 2.0f;
			m_DistanceFromCamera = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - m_distanceZ);
			m_plane.SetNormalAndPosition (Vector3.forward, m_DistanceFromCamera);

		}
		//m_DistanceFromCamera = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - m_distanceZ);
		//m_plane = new Plane (Vector3.forward, m_DistanceFromCamera);
		//m_plane = Plane.Translate (m_plane, m_DistanceFromCamera);
		//m_plane.SetNormalAndPosition (Vector3.forward, m_DistanceFromCamera);
		//m_plane.transform.RotateAround (m_plane, transform.TransformDirection (Vector3.right), -90);

		DrawRect ();
	}

	void DrawRect(){

		if (Input.GetMouseButtonDown(1)) {
			if (!pressed) {
				pressed = true;
				Debug.Log ("press");

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if(m_plane.Raycast(ray, out enterLeftUp)){
					
					pointLeftUp = ray.GetPoint (enterLeftUp);
					Debug.Log (pointLeftUp);
				}
			}
		}
		if (Input.GetMouseButtonUp(1) && pressed) {
			Ray ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
			Debug.Log ("unpress");
			pressed = false;

			if(m_plane.Raycast(ray2, out enterRightDown)){
				pointRightDown = ray2.GetPoint (enterRightDown);
			}

		/*	GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = pointLeftUp;
			float dist = Vector3.Distance (pointLeftUp, pointRightDown);
			cube.transform.localScale += new Vector3(dist,dist,0.1f);
			cube.transform.position -= new Vector3 (-dist / 2, -dist / 2, 0);

			var cubeRenderer = cube.GetComponent<Renderer> ();
			cubeRenderer.material.SetColor("coloor",new Color(0.0f,0.0f,0.0f,0.0f));
			cube.transform.LookAt(this.transform);*/

		}
	}
}
