using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject cible;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (cible.transform);
		transform.RotateAround (cible.transform.position, Vector3.up, 20 * Time.deltaTime);
	}
}
