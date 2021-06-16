using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float fuerza = 15;
    public Transform objetivo;
    public float tiempo;
    public float tiempoDa�o;
    public float cantidadDa�o = 20;
    
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
