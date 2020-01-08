using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrcInit : MonoBehaviour {

	public GameObject tree;
	public GameObject floor;
	public GameObject hovel;
	public GameObject water;
	public int sizeX;
	public int sizeY;

	int taille = 8;
	// Use this for initialization
	void Start () {
		var random = new System.Random ();


		for (int x = 0; x < sizeX; x++) {
			for (int z = 0; z < sizeY; z++) {
				int ran = random.Next (0, 3);
				if (ran == 0 || ran == 1) {
					Instantiate (floor, new Vector3 (x * taille, 0, z * taille), new Quaternion (-1, 0, 0, 1));
					if (ran == 0) {
						Instantiate (tree,new Vector3(x*taille, 1, z*taille), new Quaternion(-1,0,0,1));
					} else {
						Instantiate (hovel,new Vector3(x*taille, 2, z*taille), new Quaternion(-1,0,0,1));
					}
				}
				if(ran == 2) {
					Instantiate(water, new Vector3(x*taille, -0.5f, z*taille), new Quaternion (-1, 0, 0, 1));
				}
			}
		}

		/*int x = random.Next(-3,3);
		int y = random.Next(-3,3);
		floor = Instantiate (floor,new Vector3(0, 0, 0), new Quaternion(-1,0,0,1));
		for (int i = 0; i < 6; i++) {
			Instantiate (tree,new Vector3(x, 1, y), new Quaternion(-1,0,0,1));
			x = random.Next(-3,3);
			y = random.Next(-3,3);
		}
		x = random.Next(-2,2);
		y = random.Next(-2,2);
		Instantiate (hovel, new Vector3 (x, 2, y), new Quaternion (-1, 0, 0, 1));*/

		//Instantiate (hovel,new Vector3(0, 0, 4), new Quaternion(0,0,0,1),floor.transform);
		//Instantiate (water);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (this.prefab.name != obj.name) {
			Instantiate (prefab);
			obj = prefab;
		}*/
	}
}
