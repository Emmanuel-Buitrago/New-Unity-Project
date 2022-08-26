using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabVerdLogica : MonoBehaviour
{
    public ParticleSystem[] SparkleFuseVFX;

    public bool respuesta=false;
    private bool valorSphere=true;
    public bool ValorCollider=true;
    private bool TiempoController=false ;

    private bool m_SpherePresent;

    private Vector3 initialPos = new Vector3(0.302f, 0.78f, -6.213f);

    // Cuando la esfera entra en contacto con el socket
    void OnTriggerEnter(Collider other)
    {
        if (m_SpherePresent) {
            if (other.gameObject.name == "True")
            {
                Debug.Log("Se ingreso la esfera True");
                valorSphere = true;
            }
            else
            {
                if (other.gameObject.name == "False")
                {
                    Debug.Log("Se ingreso la esfera False");
                    valorSphere = false;
                }
            }
        }


    }

    // Cuando la esfera se mantiene en el socket
    void OnTriggerStay(Collider other)
    {
        if (m_SpherePresent && respuesta)
        {
            other.gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePosition;
            Debug.Log("Posicion freezeada");
            //desactivar script XR Grab interactor
        }
        else {
            if (respuesta==false) {
                other.gameObject.transform.position = initialPos;
                Debug.Log("Cambio de posicion");
            }
        }
    }
    // Cuando la esfera Sale del socket

    void OnTriggerExit(Collider other)
    {
        m_SpherePresent = false;
    }
    public void BooleanSocketed()
    {
        m_SpherePresent = true;
        if (valorSphere == ValorCollider)
        { 
            respuesta = true;
            Debug.Log("Respuesta correcta");
            Efectos();
        }
        else { respuesta = false;
            Debug.Log("Respuesta incorrecta");
        }

    }
    public void Efectos()
    {
        foreach (var s in SparkleFuseVFX)
        {
            s.Play();
        }
    }
}
    