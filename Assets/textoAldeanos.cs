using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textoAldeanos : MonoBehaviour
{
    public ModeloJugador modeloJugador;
    public Text texto;
    public GameObject requisito;
    void Update()
    {
        texto.text = modeloJugador.aldeanosAgarrados+"/"+ modeloJugador.aldeanosRequeridos + " Aldedanos Requeridos";
       
        if (modeloJugador.requisitoBool == true){
            requisito.SetActive(true);
        }

        if (modeloJugador.requisitoBool == false){
            requisito.SetActive(false);
        }
        
    }
}
