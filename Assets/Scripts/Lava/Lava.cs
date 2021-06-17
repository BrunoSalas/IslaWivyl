using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float fuerza = 15;
    Vector3 posicionTemporal;
    public float tiempo;
    public float tiempoDaño;
    public float cantidadDaño = 20;
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
            if(tiempo >= tiempoDaño)
            {
                tiempo -= tiempoDaño;
                ModeloJugador vida = dano.GetComponent<ModeloJugador>();
                vida.vida -= cantidadDaño;
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
