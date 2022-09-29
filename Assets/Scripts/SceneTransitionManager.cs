using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    private void Start()
    {
        fadeScreen= GameObject.Find("Fade").GetComponent<FadeScreen>();
    }
    public void SceneTransition(string NombreS) 
    {
        StartCoroutine(GoToSceneRoutine(NombreS));
    }

    IEnumerator GoToSceneRoutine(string NombreS)
    {

        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);


        SceneManager.LoadScene(NombreS);
    }
}
