using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloorReturn : MonoBehaviour
{
    public GameObject col;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name == col.name)
        {
            other.GetComponent<Collider>().gameObject.transform.position = new Vector3(0.679f, 0.554f, -6.019f);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
