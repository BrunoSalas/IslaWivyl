using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaManager : MonoBehaviour
{
    
    public int numeroTrampa = 0; //Modificar la variable desde el player por colision con cada trampa
    //public GameObject[] coco;
    //int i;
    //public GameObject jugador;
    //public Rigidbody rb;
    void Start()
    {
        //Jugador = GameObject.Find("Player");
        //rb = jugador.GetComponent<Rigidbody>();
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
                //TrampaUno();
                numeroTrampa = 0;
                break;

            case 2:
                Debug.Log("trampa 2 activada");
                numeroTrampa = 0;
                break;

            case 3:
                Debug.Log("trampa 3 activada");
                //StartCoroutine(Congelar());
                numeroTrampa = 0;
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
        
        yield return new WaitForSeconds (3);
        rb.rigidbody.constraints = RigidbodyConstraints.None;
        rb.rigidbody.velocity = velocidadLineal;
        rb.rigidbody.angularVelocity = velocidadAngular;
    */
}
