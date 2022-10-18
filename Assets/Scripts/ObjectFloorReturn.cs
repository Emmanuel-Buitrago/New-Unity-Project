using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectFloorReturn : MonoBehaviour

{
    public GameObject bandeja;
    private Vector3 posicion;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("el objeto "+other.name+" salio del espacio de juego");
        posicion = bandeja.transform.position;
        other.GetComponent<Collider>().gameObject.transform.position = posicion;
        other.gameObject.GetComponent<Rigidbody>().velocity = posicion;
    }
}
