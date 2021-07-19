using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lav : MonoBehaviour
{
    public float fuerza;
    public Rigidbody rb;
    public Transform objetivo;
    public float tiempo;
    public float tiempoDao;
    public ModeloJugador modeloJugador;
    public ControladorJugador controladorJugador;
    public float cantidadDao;
    public SceneMaster sceneMaster;
    

    void Start()
    {

        

    }


    void Update()
    {
      
        if (sceneMaster.pausado == false)
        {
            MovimientoDeLava ();
        }

    }
    void MovimientoDeLava()
    {
        Vector3 transformLava = transform.position;
        Vector3 transformObjetivo = objetivo.position;
        transform.position = Vector3.MoveTowards(transformLava, transformObjetivo, fuerza);
              
    }

    private void OnTriggerStay(Collider dano)
    {
        if (dano.gameObject.tag == "Player")
        {
            if (tiempo >= tiempoDao)
            {
                tiempo -= tiempoDao;
                modeloJugador.vida -= cantidadDao;
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
