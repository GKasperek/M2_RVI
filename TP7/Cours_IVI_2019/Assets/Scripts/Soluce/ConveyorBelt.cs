using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    float speed = 2.5f;
    Vector2 offset = new Vector2(0f, 0f);


    void OnCollisionStay(Collision obj)
    {
        if (obj.gameObject.GetComponent<Rigidbody>())
        {
            float beltVelocity = speed * Time.deltaTime;
            obj.gameObject.GetComponent<Rigidbody>().MovePosition(obj.transform.position + transform.right * -1f * beltVelocity);
        }
    }

    void Update()
    {
        offset += new Vector2(speed/21f, 0f) * Time.deltaTime;
        GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", offset);
    }
}