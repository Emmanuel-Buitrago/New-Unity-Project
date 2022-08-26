using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{

    void Update()
    {
        gameObject.transform.LookAt(GameObject.Find("Main Camera").transform, Vector3.zero);

    }
}
