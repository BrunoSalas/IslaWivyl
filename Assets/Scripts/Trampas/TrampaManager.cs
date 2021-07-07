using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaManager : MonoBehaviour

{
    public CharacterController controller;
    public GameObject player;
    public SceneMaster scenemaster;
    public Trampa1 trampa;
    public GameObject tronco;
    public GameObject SonidoTrampa3;
    public int numeroTrampa = 0; //Modificar la variable desde el player por colision con cada trampa
    //public GameObject[] coco;
    //int i;
    //public GameObject jugador;
    //public Rigidbody rb;
    void Start()
    {
        //Jugador = GameObject.Find("Player");
        //rb = jugador.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        tronco = GameObject.FindGameObjectWithTag("TroncoTrampa1");
        //trampa = tronco.GetComponent<Trampa1>();
    }


    void Update()
    {
        UsoTrampa();
    }

    void UsoTrampa()
    {
        switch (numeroTrampa)
        {
            case 1:
                Debug.Log("trampa 1 activada");
                //trampa.MovimientoTronco();
                //TrampaUno();
                numeroTrampa = 0;
                break;

            case 2:
                Debug.Log("trampa 2 activada");
                Cursor.lockState = CursorLockMode.None;
                scenemaster.ToMainMenu();

                numeroTrampa = 0;
                break;

            case 3:
                Debug.Log("trampa 3 activada");
                GameObject sonido = Instantiate(SonidoTrampa3);
                sonido.transform.position = player.transform.position;
                StartCoroutine(Congelar());
                numeroTrampa = 0;
                controller.enabled = false;
                break;

        }
    }

    /*void TrampaUno()
    {
        for (i = 0; i<= arboles.Length; i++)
        {
            GameObject temporalArbol = coco[i].GetComponent<RigidBody>();
            temporalArbol.gravityScale = 9.81;
        }
    }*/

    /*void TrampaTres()
    {
        IEnumerator Congelar() {
            Vector3 velocidadLineal = rb.rigidbody.velocity;
            Vector3 velocidadAngular = rb.rigidbody.angularVelocity;
            rb.rigidbody.velocity = Vector3.zero
            rb.rigidbody.angularVelocity = Vector3.zero;
            rb.rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            yield return new WaitForSeconds(3);
            rb.rigidbody.constraints = RigidbodyConstraints.None;
            rb.rigidbody.velocity = velocidadLineal;
            rb.rigidbody.angularVelocity = velocidadAngular;
    
        }
    } */
    IEnumerator Congelar()
    {
        yield return new WaitForSeconds(3);
        controller.enabled = true;
    }
}
