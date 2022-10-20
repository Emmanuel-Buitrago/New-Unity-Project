using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSelector : MonoBehaviour
{
    public void changeScene(string NombreScene)
    {
        GameObject.Find("SceneTransitionManager").GetComponent<SceneTransitionManager>().SceneTransition(NombreScene);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

}
