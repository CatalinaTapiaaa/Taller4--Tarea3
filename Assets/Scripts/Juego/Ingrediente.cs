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
    public bool activar;
    public bool noMover;

    GameObject target;
    int targetAleatorio;


    void Start()
    {
        gameObjectManager = GameObject.Find("MANAGERS");
        swipe = gameObjectManager.GetComponent<Swipe>();
        nivel = gameObjectManager.GetComponent<NivelManager>();

        target = GameObject.FindGameObjectWithTag("Central");
    }

    void Update()
    {
        if (!noMover)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocidad * Time.deltaTime);

            if (transform.position == target.transform.position)
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

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
