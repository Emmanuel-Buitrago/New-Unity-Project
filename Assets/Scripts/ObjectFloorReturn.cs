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
            other.GetComponent<Collider>().gameObject.transform.position = new Vector3(0.495999992f, 0.673999071f, -5.96400023f);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
