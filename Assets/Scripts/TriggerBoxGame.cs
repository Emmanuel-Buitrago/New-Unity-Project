using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxGame : MonoBehaviour
{
    public ParticleSystem[] SparkleVFX;
    
    public Counter cont;
    public string TagVariableName;
    private int counter;
    public Vector3 Reposicion;


    // Start is called before the first frame update
    void Start()
    {
        counter =0;
        cont = GameObject.Find("Counter").GetComponent<Counter>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {        
        if (other.GetComponent<Collider>().gameObject.CompareTag(TagVariableName))
        {
            other.GetComponent<Collider>().gameObject.SetActive(false);
            Contador();
            Efectos();
            Debug.Log("Score "+TagVariableName+" : " + counter);

        }else{
            Reposicionar(other);

        }

    }
    public int Contador()
    {
        counter += 1;
        cont.Change();
        return counter;

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
