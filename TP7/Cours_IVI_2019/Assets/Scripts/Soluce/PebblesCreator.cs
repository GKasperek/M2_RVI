using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebblesCreator : MonoBehaviour
{

    public Material pebbleMaterial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateCube(float x, float y, float z)
    {
        GameObject go = new GameObject("Mon Cube");
        var mf = go.AddComponent<MeshFilter>();
        var mr = go.AddComponent<MeshRenderer>();

        mf.sharedMesh = MeshGenerator.GetCustomCube(x,y,z, 0.25f);
        mr.material = pebbleMaterial;
        mr.material.color = Random.ColorHSV();

        var mc = go.AddComponent<MeshCollider>();
        mc.convex = true;

        return go;
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            var cube = CreateCube(Random.Range(0.3f, 2), Random.Range(0.3f, 2), Random.Range(0.3f, 2));
            cube.transform.position = Random.insideUnitSphere * 5f + Vector3.up * 7f + transform.position;
            cube.transform.eulerAngles = Random.insideUnitSphere * 360f;
            cube.AddComponent<Rigidbody>();
        }
    }
}
