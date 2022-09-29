using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloorReturn : MonoBehaviour
{
    public Vector3 posicion = new Vector3(-0.942f, 0.67535f, 0.384f);
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
            other.GetComponent<Collider>().gameObject.transform.position = posicion;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
