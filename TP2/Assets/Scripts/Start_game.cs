using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Start_game : MonoBehaviour {

	public Button button_start;

	// Use this for initialization
	void Start () {
		Button btn = button_start.GetComponent<Button>();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		SceneManager.LoadScene ("scene_2");
	}
}
