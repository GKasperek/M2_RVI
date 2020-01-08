using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyMeshGenerator  {

	public static Mesh GenerateChailloux(float x, float y, float z,float deform){

		float r1 = Random.Range (-deform, deform);
		float r2 = Random.Range (-deform, deform);
		float r3 = Random.Range (-deform, deform);

		float r4 = Random.Range (-deform, deform);
		float r5 = Random.Range (-deform, deform);
		float r6 = Random.Range (-deform, deform);

		float r7 = Random.Range (-deform, deform);
		float r8 = Random.Range (-deform, deform);
		float r9 = Random.Range (-deform, deform);

		Vector3 a = new Vector3(-x/2f + r1, -y/2f+r4, z/2f+r3);
		Vector3 b = new Vector3(x/2f+r5, -y/2f+r2, z/2f+r4);
		Vector3 c = new Vector3(x/2f+r6, -y/2f+r1, -z/2f+r7);
		Vector3 d = new Vector3(-x/2f+r3, -y/2f+r7, -z/2f+r5);
		Vector3 e = new Vector3(-x/2f+r2, y/2f+r6, z/2f+r8);
		Vector3 f = new Vector3(x/2f+r4, y/2f+r9, z/2f+r1);
		Vector3 g = new Vector3(x/2f+r7, y/2f+r8, -z/2f+r3);
		Vector3 h = new Vector3(-x/2f+r2, y/2f+r5, -z/2f+r6);

		Vector3[] faces = new Vector3[] {
			a,b,c,d,
			h,e,a,d,
			e,f,b,a,
			g,h,d,c,
			f,g,c,b,
			h,g,f,e
		};

		int[] indices = new int[] {
			3,1,0,
			3,2,1,

			3 +4*1,1 +4*1,0 +4*1,
			3 +4*1,2 +4*1,1 +4*1,

			3 +4*2,1 +4*2,0 +4*2,
			3 +4*2,2 +4*2,1 +4*2,

			3 +4*3,1 +4*3,0 +4*3,
			3 +4*3,2 +4*3,1 +4*3,

			3 +4*4,1 +4*4,0 +4*4,
			3 +4*4,2 +4*4,1 +4*4,

			3 +4*5,1 +4*5,0 +4*5,
			3 +4*5,2 +4*5,1 +4*5,
		};

		Vector3[] normales = new Vector3[] {
			Vector3.down,Vector3.down,Vector3.down,Vector3.down,

			Vector3.left,Vector3.left,Vector3.left,Vector3.left,

			Vector3.up,Vector3.up,Vector3.up,Vector3.up,

			Vector3.right,Vector3.right,Vector3.right,Vector3.right,

			Vector3.back,Vector3.back,Vector3.back,Vector3.back,

			Vector3.forward,Vector3.forward,Vector3.forward,Vector3.forward
		};

		Mesh chailloux = new Mesh ();
		chailloux.vertices = faces;
		chailloux.triangles = indices;
		chailloux.normals = normales;

		chailloux.RecalculateBounds();
		chailloux.RecalculateNormals();

		return chailloux;
	}
}
