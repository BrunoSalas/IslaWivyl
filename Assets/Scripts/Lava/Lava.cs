using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float fuerza = 15;
    public Transform objetivo;
    public float tiempo;
    public float tiempoDaño;
    public float cantidadDaño = 20;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //Vector3 transformLava = transform.position;
        //Vector3 transformObjetivo = objetivo.position;
        //transform.position = Vector3.MoveTowards(transformLava, transformObjetivo, fuerza);
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
