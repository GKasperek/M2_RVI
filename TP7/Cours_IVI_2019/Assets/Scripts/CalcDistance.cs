using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcDistance : MonoBehaviour {

	public Transform cylindre;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.other.name == "Sphere") {
			Debug.Log(Vector3.Distance(col.other.transform.position, cylindre.transform.position));
		}
	}
}
