using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public GameObject gameObjectManager;
    public NivelManager nivel;
    public Swipe swipe;
    [Space]
    public float velocidad;
    public string direccion;
    public string tagCentro;
    public bool activar;

    GameObject[] target;
    int targetAleatorio;

    bool noMover;

    void Start()
    {
        gameObjectManager = GameObject.Find("MANAGERS");
        swipe = gameObjectManager.GetComponent<Swipe>();
        nivel = gameObjectManager.GetComponent<NivelManager>();

        target = GameObject.FindGameObjectsWithTag(tagCentro);
        targetAleatorio = Random.Range(0, target.Length);
    }

    void Update()
    {
        if (!noMover)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[targetAleatorio].transform.position, velocidad * Time.deltaTime);

            if (transform.position == target[targetAleatorio].transform.position)
            {
                nivel.activarTemporizador = true;
                activar = true;
                noMover = true;
            }
        }

        if (activar)
        {
            if (!nivel.desactivar)
            {
                if (swipe.activar)
                {
                    if (direccion == swipe.direccion)
                    {
                        nivel.Victoria(direccion);
                        activar = false;
                    }
                    else
                    {
                        nivel.Derrota();
                        activar = false;
                    }

                    swipe.activar = false;
                }
            }               
        }
    }      
}
