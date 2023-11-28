using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour
{ 
    public FinalManager finalManager;

    void OnTriggerStay(Collider other)
    {
        if (finalManager.destruir)
        {
            if (other.gameObject.CompareTag("Ingrediente"))
            {
                other.gameObject.GetComponent<Ingrediente>().Destroy();
            }
            finalManager.destruir = false;
        }
    }
}
