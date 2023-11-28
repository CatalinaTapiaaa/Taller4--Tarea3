using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PuntuacionManager : MonoBehaviour
{
    public Animator animacionPuntuacion;
    public TextMeshProUGUI puntuacion;
   
    public void Start()
    {
        DataManager.data.puntuacion = 0;
        DataManager.Save();
    }
    void Update()
    {
        puntuacion.text = DataManager.data.puntuacion.ToString();
    }
    public void SumarPuntaje()
    {
        StartCoroutine(AniPuntaje());
        DataManager.data.puntuacion += 1;
        DataManager.Save();
    }

    IEnumerator AniPuntaje()
    {
        animacionPuntuacion.SetBool("Activar", true);
        yield return new WaitForSeconds(0.30f);
        animacionPuntuacion.SetBool("Activar", false);
    }
}
