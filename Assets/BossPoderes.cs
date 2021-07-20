using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPoderes : MonoBehaviour
{
    public GameObject [] trampas;
    GameObject trampaEscogida;
    public GameObject piedras;
    public GameObject bola;
    public GameObject bolaSpawn;
    public bool lanzar;
    
    public float timer;
    
    public int i;
    public AudioSource sonido;
    public Animator animator;
    public GameObject objetivo1;
    public GameObject objetivo2;
    public GameObject objetivo3;
    public GameObject objetivo4;
    public GameObject objetivo5;
    public GameObject objetivo6;
    public GameObject objetivo7;
    public GameObject objetivo8;
    public GameObject objetivo9;
    public GameObject objetivo10;
    public int numeroObjetivo;
    void Start()
    {
        trampas = GameObject.FindGameObjectsWithTag ("SpawnTrampas");
        sonido = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        lanzar = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

            if (lanzar == true)
            {
                BuscarObjetivo();
                SanMarquino();
                
            }

            if (timer>10)
            {
                
                animator.SetTrigger ("Rugido");
                sonido.Play();
                CrearPiedras();
                timer = 0;
                //lanzar = true;
            }
        
    }


    public void CrearPiedras (){
       
       
        for (i=0 ; i<trampas.Length; i++){
            trampaEscogida = trampas [i];
            GameObject piedrasTemporales = Instantiate(piedras);
            piedrasTemporales.transform.position = trampaEscogida.transform.position;
            Destroy (piedrasTemporales , 6.6f);
        }
    }

    public void SanMarquino ()
    {
        animator.SetTrigger ("Lanzamiento");
        GameObject bolaTemporal = Instantiate (bola);
        bolaTemporal.transform.position = bolaSpawn.transform.position;
        lanzar = false;

    }

    public void BuscarObjetivo ()
    {
        switch (numeroObjetivo){

            case 1: 
                objetivo1.SetActive(true);
                //numeroObjetivo++;
                Destroy(objetivo1,4f);
                  
            break;
            case 2:
                
                objetivo2.SetActive(true);
                Destroy(objetivo2,4f);
            break;
            
            case 3:
                objetivo3.SetActive(true);
                Destroy(objetivo3,3f);
            break;

            case 4:
                objetivo4.SetActive(true);
                Destroy(objetivo4,4f);
            break;

            case 5:
                objetivo5.SetActive(true);
                Destroy(objetivo5,4f);
            break;

            case 6:
                objetivo6.SetActive(true);
                Destroy(objetivo6,4f);
            break;

            case 7:
                objetivo7.SetActive(true);
                Destroy(objetivo7,4f);
            break;

            case 8:
                objetivo8.SetActive(true);
                Destroy(objetivo8,4f);
            break;

            case 9:
                objetivo9.SetActive(true);
                Destroy(objetivo9,4f);
            break;
            case 10:
                objetivo10.SetActive(true);
                Destroy(objetivo10,4f);
            break;
         }
    }

}
