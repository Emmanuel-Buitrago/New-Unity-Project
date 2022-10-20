using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public static class Extensions
{
    public static bool findList<T>(this List<T> list, T target)
    {
        return list.Contains(target);
    }
}

public class TabOperadoresLogica : MonoBehaviour
{

    public ParticleSystem[] SparkleFuseTrueVFX;
    public ParticleSystem[] SparkleFuseFalseVFX;
    private Counter cont;

    private string valorSphere;
    public List<string> valorCollider;

    private bool m_SpherePresent = false;

    private Vector3 initialPos = new Vector3(0.302f, 0.78f, -6.213f);

    void Start()
    {
        cont = GameObject.Find("Counter").GetComponent<Counter>();
    }

    // Cuando la esfera entra en contacto con el socket
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Se ingreso la esfera ");
        valorSphere = ""+other.gameObject.name;
    }

    // Cuando la esfera se mantiene en el socket
    void OnTriggerStay(Collider other)
    {
        if (m_SpherePresent == true &&  valorCollider.findList(valorSphere))
        {
            m_SpherePresent = false;

            Debug.Log("Respuesta correcta");
            StartCoroutine(CorrectAnw(other));

        }
        else
        {
            if (m_SpherePresent == true && valorCollider.findList(valorSphere)==false)
            {
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
        Debug.Log("Posicion freezeada");
        //desactivar other.script XR Grab interactor
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
