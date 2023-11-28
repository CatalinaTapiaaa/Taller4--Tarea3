using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelManager : MonoBehaviour
{
    public GameObject[] ingredientes;
    public Transform[] pivotsSpawn;
    [Header("Barra Temporizador")]
    public Image barra;
    public float velocidadTiempo;
    public bool activarTemporizador;
    bool desactivarTemporizador;

    [Header("Derrota")]
    public GameObject panelMenu;
    public GameObject pan;
    public Transform centro;
    public bool desactivar;

    [Header("Frenetico")]
    public Animator aniCamara;
    public Transform camara;
    public Transform posicionCamara;
    public float velocidad;
    public bool comer;

    PuntuacionManager puntuacionManager;
    float t = 100;

    void Update()
    {
        if (!desactivarTemporizador)
        {
            if (activarTemporizador)
            {
                t -= velocidadTiempo * Time.deltaTime;
            }
            if (!activarTemporizador)
            {
                t += 50 * Time.deltaTime;
            }
            if (t <= 0)
            {
                Derrota();
                desactivarTemporizador = true;
            }
        }       

        if (comer)
        {
            camara.position = Vector3.MoveTowards(camara.position, posicionCamara.position, velocidad * Time.deltaTime);
            aniCamara.SetBool("Activar", true);
            GameObject[] items = GameObject.FindGameObjectsWithTag("Ingrediente");
            foreach (var item in items)
            {
                Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

                if (itemRigidbody != null)
                {
                    itemRigidbody.useGravity = true;
                }
            }
        }

        barra.fillAmount = t / 100;
    }

    public void Victoria(string direccion)
    {
        Debug.Log("Victoria");
        activarTemporizador = false;
        transform.position += new Vector3(0,0,-0.5f);
        int aleatorio = Random.Range(0, ingredientes.Length);

        if (direccion == "Derecha")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[0].position, Quaternion.identity);
        }
        if (direccion == "Izquierda")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[1].position, Quaternion.identity);
        }
        if (direccion == "Arriba")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[2].position, Quaternion.identity);
        }
        if (direccion == "Abajo")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[3].position, Quaternion.identity);
        }

        if (direccion == "Arriba Derecha")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[4].position, Quaternion.identity);
        }
        if (direccion == "Arriba Izquierda")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[5].position, Quaternion.identity);
        }

        if (direccion == "Abajo Derecha")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[6].position, Quaternion.identity);
        }
        if (direccion == "Abajo Izquierda")
        {
            Instantiate(ingredientes[aleatorio], pivotsSpawn[7].position, Quaternion.identity);
        }

        desactivar = false;
    }  
    public void Derrota()
    {
        Debug.Log("Derrota");
        desactivar = false;
        desactivarTemporizador = true;
        transform.position += new Vector3(0, 0, -0.5f);
        StartCoroutine(Frenetico());
    }

    IEnumerator Frenetico()
    {
        Instantiate(pan, centro.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        comer = true;
    }

}
