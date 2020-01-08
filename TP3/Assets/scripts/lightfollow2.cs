using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightfollow2 : MonoBehaviour {

	public Slider slider;
	public Light slight;

	private Vector3 worldPos;
	// Use this for initialization
	void Start () {
		
		slider.minValue = 0;
		slider.maxValue = 30;
		slider.onValueChanged.AddListener(delegate {
			ValueChangeCheck();
		});
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") != 0f) {
			slider.value+= (Input.GetAxis ("Mouse ScrollWheel")*10);
		}
		worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

		transform.LookAt(new Vector3(worldPos.x, worldPos.y, worldPos.z));
	}

	public void ValueChangeCheck(){
		Debug.Log (slider.value);
		slight.spotAngle = slider.value;
	}
}
