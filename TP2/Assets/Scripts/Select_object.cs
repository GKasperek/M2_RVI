using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_object : MonoBehaviour {

	public Text text;
	private RaycastHit hit;

	private bool _mouseState;
	private GameObject target;
	private Vector3 screenSpace;
	private Vector3 offset;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			target = GetClickedObject (out hit);
			if (target != null) {
				text.text = hit.collider.gameObject.name.ToString ();
				_mouseState = true;
				screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
				offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			_mouseState = false;
		}
		if (_mouseState) {
			Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;

			target.transform.position = curPosition;

		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			target.transform.Translate(new Vector3 (0, 0, 30 * Time.deltaTime));
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			target.transform.Translate( new Vector3 (0, 0, -30 * Time.deltaTime));
		}


	}
	

	GameObject GetClickedObject(out RaycastHit hit){
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100)) {
			target = hit.collider.gameObject;
		}
		return target;
	}
}