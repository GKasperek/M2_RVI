using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFollow : MonoBehaviour {

	private Vector3 worldPos;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

		Debug.Log (worldPos.x);
		Debug.Log (worldPos.y);

		//transform.Translate(worldPos); 
		transform.position = new Vector3(worldPos.x, worldPos.y, -7f);

	}


}
