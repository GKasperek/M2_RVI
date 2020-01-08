using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    // start et end 
    public static Mesh GetCustomCube(float x, float y, float z, float deformation) {

        // min 10 cm wall length
        //if (Vector3.Distance(start, end) < 0.1f) return new List<Vector3>();

        float ra = Random.Range(-deformation, deformation);
        float rb = Random.Range(-deformation, deformation);
        float rc = Random.Range(-deformation, deformation);
        float rd = Random.Range(-deformation, deformation);
        float re = Random.Range(-deformation, deformation);
        float rf = Random.Range(-deformation, deformation);
        float rg = Random.Range(-deformation, deformation);
        float rh = Random.Range(-deformation, deformation);

        Vector3 a = new Vector3(-x / 2f + ra, -y / 2f + rb, z / 2f + rc);
        Vector3 b = new Vector3(x / 2f + rb, -y / 2f + rd, z / 2f + re);
        Vector3 c = new Vector3(x / 2f + rg, -y / 2f+rf, -z / 2f+ra);
        Vector3 d = new Vector3(-x / 2f+rh, -y / 2f+rg, -z / 2f+rf);

        Vector3 e = new Vector3(-x / 2f+rd, y / 2f+ra, z / 2f+re);
        Vector3 f = new Vector3(x / 2f+re,  y / 2f+rh, z / 2f+rb);
        Vector3 g = new Vector3(x / 2f+rf, y / 2f+rf, -z / 2f+rb);
        Vector3 h = new Vector3(-x / 2f+rc,  y / 2f+rh, -z / 2f+ra);

        Vector3[] vertices = new Vector3[]
        {
            // down
            a,b,c,d,
            // left
            h,e,a,d,
            // front
            e,f,b,a,
            // back
            g,h,d,c,
            // right
            f,g,c,b,
            // up
            h,g,f,e
        };

        // SENS DES AIGUILLES D'UNE MONTRE !!!
        int[] triangles = new int[]
        {
            // Cube Bottom Side Triangles
            3 + 4 * 0, 1 + 4 * 0, 0 + 4 * 0,
            3 + 4 * 0, 2 + 4 * 0, 1 + 4 * 0,  
            // Cube Left Side Triangles
            3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
            3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
            // Cube Front Side Triangles
            3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
            3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
            // Cube Back Side Triangles
            3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
            3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
            // Cube Rigth Side Triangles
            3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
            3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
            // Cube Top Side Triangles
            3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
            3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
        };

        //Vector3[] normals = new Vector3[]
        //{
        //    // down
        //    Vector3.down,Vector3.down,Vector3.down,Vector3.down,
        //    //left
        //    Vector3.left,Vector3.left,Vector3.left,Vector3.left,
        //    //front
        //    Vector3.forward,Vector3.forward,Vector3.forward,Vector3.forward,
        //    //back
        //    Vector3.back,Vector3.back,Vector3.back,Vector3.back,
        //    //right
        //    Vector3.right,Vector3.right,Vector3.right,Vector3.right,
        //    //up
        //    Vector3.up,Vector3.up,Vector3.up,Vector3.up
        //};

        Vector3[] normals = new Vector3[]
        {

        };

        Mesh mesh = new Mesh();

        // Sommets
        mesh.vertices = vertices;

        // Faces
        mesh.triangles = triangles;

        // Normales
        mesh.normals = normals;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return mesh;
    }
}
