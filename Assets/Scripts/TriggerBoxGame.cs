using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxGame : MonoBehaviour
{
    public Counter cont;
    public string TagVariableName;
    private int counter;


    // Start is called before the first frame update
    void Start()
    {
        counter =0;
        cont = GameObject.Find("======= VR MANAGEMENT ======").GetComponent<Counter>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {        
        if (other.GetComponent<Collider>().gameObject.CompareTag(TagVariableName))
        {
            other.GetComponent<Collider>().gameObject.SetActive(false);
            Contador();
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
    private void Reposicionar(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name== "Sphere" || other.GetComponent<Collider>().gameObject.layer == LayerMask.NameToLayer("Floor")) 
        { 
            other.GetComponent<Collider>().gameObject.transform.position = new Vector3(0.679f, 1.453999f, -6.019f);
        }
    }
}
