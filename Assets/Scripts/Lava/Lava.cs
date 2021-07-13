using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float fuerza;
    Vector3 posicionTemporal;
    public float tiempo;
    public float tiempoDano;
    public float cantidadDano = 20;
    public ModeloJugador modeloJugador;
    public ControladorJugador controladorJugador;
    void Start()
    {
        
    }

    
    void Update()
    {
        posicionTemporal = transform.localScale;
        posicionTemporal.z += Time.deltaTime;
        transform.localScale = posicionTemporal;
    }


    private void OnTriggerStay(Collider dano)
    {
        if(dano.gameObject.tag == "Player")
        {
            if(tiempo >= tiempoDano)
            {
                tiempo -= tiempoDano;
                modeloJugador.vida -= cantidadDano;
                controladorJugador.Morir();

            }
            tiempo += Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider dano)
    {
        if (dano.gameObject.tag == "Player")
        {
            tiempo = 0;
        }
    }


}
