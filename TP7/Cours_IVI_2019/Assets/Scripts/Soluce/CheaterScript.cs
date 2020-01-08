using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheaterScript : MonoBehaviour {

    public Transform proj;
    SpringJoint[] springs;

	// Use this for initialization
	void Start () {
        springs = GetComponents<SpringJoint>();
	}
	
	// Update is called once per frame
	void Update () {
		if(proj.position.y > 11f) { springs[1].breakForce = 0.01f; }
	}
}
