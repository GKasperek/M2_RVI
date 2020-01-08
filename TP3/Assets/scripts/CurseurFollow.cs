using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurseurFollow : MonoBehaviour {

	public Camera cameraSecondaire;
	public PhysicMaterial p1;
	public PhysicMaterial p2;
	public PhysicMaterial p3;
	public Texture texture;
	public Text txt;

	private Vector3 worldPos;
	private Vector3 viewPortPos;
	private RaycastHit hit;
	private Ray ray;
	private int compteur;
	private Renderer m_renderer;
	// Use this for initialization
	void Start () {
		txt.text =  compteur.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		var random = new System.Random();

		worldPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 20));
		transform.position = worldPos;
		if (Input.mousePosition.x > Screen.width/2) {
			worldPos = cameraSecondaire.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 20));
			transform.position = worldPos;
		}

		if (Input.GetMouseButtonDown (0)) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			Rigidbody gameORigid = sphere.AddComponent<Rigidbody> ();
			sphere.transform.position = transform.position;

			int rand = random.Next (0, 3);

			PhysicMaterial physic  = p1;
			if (rand == 1) {
				physic = p2;
			}
			if (rand == 2) {
				physic = p3;
			}

			Collider collider = sphere.GetComponent<Collider> ();
			collider.material = physic;

			m_renderer = sphere.GetComponent<Renderer> ();
			m_renderer.material.SetTexture ("_MainTex", texture);

			sphere.tag = "sphere";
		}


		var spheres = GameObject.FindGameObjectsWithTag ("sphere");

		foreach(GameObject s in spheres) {
			if (s.transform.position.y < 0) {
				compteur++;
				Destroy (s);
			}
		}
		Debug.Log (compteur);
		txt.text =  "Billes tombées : " + compteur.ToString();
	}
}
