using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Configurateur : MonoBehaviour {

	public RawImage point;
	public RawImage camera;
	public Canvas canvas;
	public Button validate;
	public Texture mytexture;
	public GameObject meuble;
	public Camera cam;

    private RaycastHit hit;
    private Vector3 target;
    private Vector3 screenspace;
    private Vector3 offset;

	private List <RawImage> listImage = new List<RawImage> ();
	private Transform p1;
	private Transform p2;

	private bool configuration;
	private GameObject meublePointeur;

	// Use this for initialization
	void Start () {
		Button btn = validate.GetComponent<Button>();
		btn.onClick.AddListener(onClickValidate);
		float posX = 100f;
		float posY = 100f;
		float size = 30;
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
				plane.transform.position = new Vector3 (posX, 0, posY);
				plane.transform.localScale = new Vector3 (10, 1, 10);
				posX += size;
				plane.GetComponent<Renderer> ().material.mainTexture = mytexture;
			}
			posY += size;
			posX = 200f;
		}

		configuration = true;
		meublePointeur = Instantiate (meuble, new Vector3(0,0,0), new Quaternion (0, 0, 0, 1));
		meublePointeur.transform.localScale = new Vector3(10,10, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if (configuration)
        {
			if(Input.GetMouseButtonDown(0)){
				target = Input.mousePosition;
				if (target.y < 280 && target.y > 70 &&target.x < 560 && target.x > 160) {
					RawImage ri = (RawImage)Instantiate (point) as RawImage;
					ri.transform.parent = canvas.transform;
					ri.transform.position = target;
					Debug.Log (target);
					listImage.Add (ri);
				}


			}

        }
		if (!configuration) {
			float dist = 500;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, dist)) {
				Vector3 pointMeuble = ray.GetPoint (dist);
				Vector3 pointeur = new Vector3(pointMeuble.x,5,pointMeuble.z);
				meublePointeur.transform.position = pointeur;
				if (Input.GetMouseButtonDown (0)) {
					GameObject m = Instantiate (meuble, pointeur , new Quaternion (0, 0, 0, 1));
					m.transform.localScale = new Vector3(10,10, 10);
				}
			}
		}
	}

	void onClickValidate(){
		canvas.enabled = false;
		configuration = false;

		if (listImage.Count > 2) {
			Transform first = listImage [0].transform;
			p1 = listImage [0].transform;
			for(int i = 1; i < listImage.Count; i++) {
				p2 = listImage [i].transform;
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

				Vector3 point1 = new Vector3 (p1.position.x, 1f, p1.position.y);
				Vector3 point2 = new Vector3 (p2.position.x, 1f, p2.position.y);
				Vector3 centre = new Vector3 ((p1.position.x + p2.position.x) / 2, 1, (p1.position.y + p2.position.y) / 2);

				cube.transform.position = centre;
				float dist = Vector3.Distance(point1,point2);
				cube.transform.LookAt(point1);
				cube.transform.localScale = new Vector3 (1f, 20, dist);
				p1 = p2;
			}
			Transform last = listImage [listImage.Count-1].transform;
			GameObject lastc = GameObject.CreatePrimitive(PrimitiveType.Cube);

			Vector3 plast = new Vector3 (last.position.x, 1f, last.position.y);
			Vector3 pfirst = new Vector3 (first.position.x, 1f, first.position.y);
			Vector3 centrelf = new Vector3 ((last.position.x + first.position.x) / 2, 1, (last.position.y + first.position.y) / 2);

			lastc.transform.position = centrelf;
			float distf = Vector3.Distance(plast,pfirst);
			lastc.transform.LookAt (plast);
			lastc.transform.localScale = new Vector3 (1f, 20, distf);


		}
	}
		

	float mapX(float oldmin, float oldmax, float newmin, float newmax, float x){
		// -339 340
		float oldRange = (oldmax - oldmin);
		float newRange = (newmax - newmin);
		float newValue = (((x - oldmin) * newRange) / oldRange) + newmin;
		return(newValue);
	}

	float mapY(float oldmin, float oldmax, float newmin, float newmax, float y){
		// -166 122 
		float oldRange = (oldmax - oldmin);
		float newRange = (newmax - newmin);
		float newValue = (((y - oldmin) * newRange) / oldRange) + newmin;
		return(newValue);
	}

	float distance(float x1, float y1,float x2,float y2){
		return Mathf.Sqrt (Mathf.Pow (x2 - x1, 2) + Mathf.Pow (y2 - y1, 2));
	}
}
