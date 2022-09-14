using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public Vector3 rotacionExtra;

    void Update()
    {
        gameObject.transform.LookAt(GameObject.Find("Main Camera").transform);
        gameObject.transform.localEulerAngles+=rotacionExtra;

    }
}
