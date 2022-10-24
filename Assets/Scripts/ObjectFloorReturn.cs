using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectFloorReturn : MonoBehaviour

{
    public GameObject posicionReinicio;
    private Vector3 posicion;
    private void Start()
    {
        posicion = posicionReinicio.transform.position;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Floor (1)") 
        {
            Debug.Log("el objeto " + other.name + " salio del espacio de juego");

            other.GetComponent<Collider>().gameObject.transform.position = posicion;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
