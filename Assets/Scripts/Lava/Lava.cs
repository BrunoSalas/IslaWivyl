using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float fuerza = 15;
    Vector3 posicionTemporal;
    public float tiempo;
    public float tiempoDa�o;
    public float cantidadDa�o = 20;
    public float gaa;
    
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
            if(tiempo >= tiempoDa�o)
            {
                tiempo -= tiempoDa�o;
                ModeloJugador vida = dano.GetComponent<ModeloJugador>();
                vida.vida -= cantidadDa�o;
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
