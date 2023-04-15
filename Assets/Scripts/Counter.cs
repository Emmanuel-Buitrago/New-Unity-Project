using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public int contador =0;
    public int limite;
    public string NombreScene;
    private bool[] objects ;

// Start is called before the first frame update

    void Start()
    {
        objects = new bool[limite];
        for (int i = 0; i < limite; i++) { objects[i]=false; }
    }
    // Update is called once per frame
    private int CountObj()
    {
        int aux=0;
        foreach (var obj in objects) { 
            if (obj) { aux++; }
        }
        return aux;
    }
    public void Change(int i )
    {
        objects[i]=true;
        contador = CountObj();
        Debug.Log("La Respuesta total es " + contador);
        if (contador>=limite)
        {
            GameObject.Find("SceneTransitionManager").GetComponent<SceneTransitionManager>().SceneTransition(NombreScene);
            contador=0;
        }
    }
    public void Rest(int i)
    {
        objects[i] = false;
        contador = CountObj();
        Debug.Log("La Respuesta total es " + contador);
    }

}
