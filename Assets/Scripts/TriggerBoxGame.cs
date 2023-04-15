using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxGame : MonoBehaviour
{
    public ParticleSystem[] SparkleVFX;
    
    private Counter cont;
    public string TagVariableName;
    public GameObject position;
    private Vector3 Reposicion;

    // Start is called before the first frame update
    void Start()
    {
        Reposicion = position.transform.position;
        cont = GameObject.Find("Counter").GetComponent<Counter>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {        
        if (other.GetComponent<Collider>().gameObject.CompareTag(TagVariableName))
        {
            other.GetComponent<Collider>().gameObject.SetActive(false);
            int aux = int.Parse(other.GetComponent<Collider>().gameObject.name);
            Contador(aux);
            Efectos();

        }else{
            Reposicionar(other);

        }

    }
    public void Contador(int id)
    {
        cont.Change(id);
    }
    private void Efectos()
    {
        foreach(var s in SparkleVFX)
        {
            s.Play();
        }
    }
    private void Reposicionar(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name== "Sphere") 
        { 
            other.GetComponent<Collider>().gameObject.transform.position = Reposicion;
        }
    }
}
