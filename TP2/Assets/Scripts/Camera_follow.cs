using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class Camera_follow : MonoBehaviour {

	public float speed = 100.0f;

	public Text posText;

	public Button button_up;
	public Button button_down;
	public Button button_left;
	public Button button_right;

	public GameObject cible;
	// Use this for initialization
	void Start () {
		Button btn_up = button_up.GetComponent<Button>();
		btn_up.onClick.AddListener (goUp);

		Button btn_down = button_down.GetComponent<Button>();
		btn_down.onClick.AddListener (goDown);

		Button btn_right = button_right.GetComponent<Button>();
		btn_right.onClick.AddListener (goRight);

		Button btn_left = button_left.GetComponent<Button>();
		btn_left.onClick.AddListener (goLeft);


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			goRight ();
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			goLeft ();
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			goDown ();
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			goUp ();
		}
		posText.text = transform.position.ToString();
		transform.LookAt (cible.transform);

	}

	void goUp(){
		transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
	}

	void goDown(){
		transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
	}

	void goLeft(){
		transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
	}

	void goRight(){
		transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
	}
}
