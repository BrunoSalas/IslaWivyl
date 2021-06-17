using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float fuerza;
    Vector3 posicionTemporal;
    public float tiempo;
    public float tiempoDa�o;
    public float cantidadDa�o = 20;
    public ModeloJugador modeloJugador;

    void Start()
    {
        
    }

    
    void Update()
    {
        posicionTemporal = transform.localScale;
        posicionTemporal.z += 3 * Time.deltaTime;
        transform.localScale = posicionTemporal;
    }


    private void OnTriggerStay(Collider dano)
    {
        if(dano.gameObject.tag == "Player")
        {
            if(tiempo >= tiempoDa�o)
            {
                tiempo -= tiempoDa�o;
                modeloJugador.vida -= cantidadDa�o;
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
