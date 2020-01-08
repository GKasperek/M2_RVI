using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public float vitesse;
	float rotY;
	float rotX;
	// Use this for initialization
	void Start () {
		Debug.Log (gameObject.name);
		vitesse = 10;
	}
	
	// Update is called once per frame
	void Update () {
		rotY += Time.deltaTime * vitesse;
		rotX += Time.deltaTime * vitesse;
		transform.rotation = Quaternion.Euler (rotX, 0, 0);
	}
}
