using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerate : MonoBehaviour {

	public Material rockMat;
	public float deform;
	public GameObject c1;

	// Use this for initialization
	void Start () {
		GameObject c = CreateChailloux (3f,3f,3f);

		//c1 = CreateChailloux (3f,3f,3f);



	}
	
	// Update is called once per frame
	void Update () {
		Destroy (c1);
		c1 = CreateChailloux (3f,3f,3f);
		c1.transform.position = new Vector3 (3, 3, 0);
		
	}

	public GameObject CreateChailloux(float x, float y, float z){
		GameObject cailloux = new GameObject("chailloux");
		Mesh meshCailloux = MyMeshGenerator.GenerateChailloux (x, y, z, deform);
		MeshFilter meshF = cailloux.AddComponent<MeshFilter> ();
		meshF.mesh = meshCailloux;
		MeshRenderer mr = cailloux.AddComponent<MeshRenderer> ();

		mr.material = rockMat;
		return cailloux;
	}
}

