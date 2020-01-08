using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBouncers : MonoBehaviour {

	public int nbBouncers;
	public GameObject bouncer;
	private float x;
	private float y;
	// Use this for initialization
	void Start () {
		var random = new System.Random ();
		for (int i = 0; i != nbBouncers; i++) {
			x = random.Next (-5, 5);
			y = random.Next (-5, 5);
			Instantiate (bouncer, new Vector3 (x,0,y), new Quaternion(0f,0f,0f,1f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
