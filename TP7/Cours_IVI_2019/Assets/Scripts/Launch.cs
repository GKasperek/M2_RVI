using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

	public GameObject munition;
	private HingeJoint[] springs;
	// Use this for initialization
	void Start () {
		springs = GetComponents<HingeJoint>();

	}
	
	// Update is called once per frame
	void Update () {
		if (munition.transform.position.y > 15f) {
			springs[0].breakForce = 0.001f;
		}
	}
}
