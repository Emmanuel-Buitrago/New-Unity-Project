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

    public GameObject posicionReinicio;
    private Vector3 initialPos;
    public int nameCount;

    void Start()
    {
        initialPos = posicionReinicio.transform.position;

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
            Efectos(true);
            cont.Change(nameCount);

        }
        else
        {
            if (m_SpherePresent == true && valorCollider.findList(valorSphere)==false)
            {
                m_SpherePresent = false;
                Debug.Log("Respuesta incorrecta");
                gameObject.GetComponent<XRExclusiveSocketInteractor>().socketActive = false;
                other.gameObject.transform.position = initialPos;
                Debug.Log("Cambio de posicion");
                StartCoroutine(IncorrectAnw(other));
            }
        }
    }
    IEnumerator IncorrectAnw(Collider other)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<XRExclusiveSocketInteractor>().socketActive = true;
        Efectos(false);
    }

    public void SetFalsePresentSphere()
    {
        m_SpherePresent = false;
        cont.Rest(nameCount);
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
