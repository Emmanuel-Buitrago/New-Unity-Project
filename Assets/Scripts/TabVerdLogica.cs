using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TabVerdLogica : MonoBehaviour
{
    public ParticleSystem[] SparkleFuseTrueVFX;
    public ParticleSystem[] SparkleFuseFalseVFX;
    public Counter cont;

    private bool valorSphere;
    public bool valorCollider;

    private bool m_SpherePresent = false;

    private Vector3 initialPos = new Vector3(0.302f, 0.78f, -6.213f);

    void Start()
    {
        cont = GameObject.Find("Counter").GetComponent<Counter>();
    }
    // Cuando la esfera entra en contacto con el socket
    void OnTriggerEnter(Collider other)
    {
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

    // Cuando la esfera se mantiene en el socket
    void OnTriggerStay(Collider other)
    {   
        if (m_SpherePresent==true && valorSphere == valorCollider)
        {
            m_SpherePresent = false;

            Debug.Log("Respuesta correcta");
            StartCoroutine(CorrectAnw(other));

        }
        else {
            if (m_SpherePresent == true && valorSphere != valorCollider) {
                m_SpherePresent = false;
                Debug.Log("Respuesta incorrecta");
                gameObject.GetComponent<XRExclusiveSocketInteractor>().socketActive = false;
                StartCoroutine(IncorrectAnw(other));
            }
        }

    }
    IEnumerator IncorrectAnw(Collider other)
    {

        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<XRExclusiveSocketInteractor>().socketActive = true;
        other.gameObject.transform.position = initialPos;
        Debug.Log("Cambio de posicion");
        Efectos(false);
    }
    IEnumerator CorrectAnw(Collider other)
    {
        yield return new WaitForSeconds(0.1f);
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Debug.Log("Posicion freezeada");
        //desactivar other.script XR Grab interactor
        other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        //desactivar gameObject.XR exclusive Socket interactor
        gameObject.GetComponent<XRExclusiveSocketInteractor>().enabled = false;
        Efectos(true);
        cont.Change();
    }
    public void SetFalsePresentSphere()
    {
        m_SpherePresent = false;
    }
    public void BooleanSocketed()
    {
        m_SpherePresent = true;
    }
    public void Efectos(bool valorRespuesta)
    {
        if (valorRespuesta)
        {
            foreach (var s in SparkleFuseTrueVFX)
            {
                s.Play();
            }
        }
        else
        {
            foreach (var s in SparkleFuseFalseVFX)
            {
                s.Play();
            }
        }

    }
}
    