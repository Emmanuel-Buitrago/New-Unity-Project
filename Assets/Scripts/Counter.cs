using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public int contador =0;
    public string NombreScene;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Change()
    {
        contador += 1;
        Debug.Log("La Respuesta total es " + contador);
        if (GameObject.Find("Sphere") ==false)
        {
            GameObject.Find("SceneTransitionManager").GetComponent<SceneTransitionManager>().SceneTransition(NombreScene);
        }
    }
    
}
