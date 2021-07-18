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
    public bool lanzar = false;
    
    public float timer;
    
    public int i;
    public AudioSource sonido;
    public Animator animator;
    void Start()
    {
        trampas = GameObject.FindGameObjectsWithTag ("SpawnTrampas");
        sonido = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
     

            if (timer>10)
            {
                
                animator.SetTrigger ("Rugido");
                sonido.Play();
                CrearPiedras();
                timer = 0;
                lanzar = true;
            }
            if (timer>4 && lanzar == true)
            {
                SanMarquino();
                lanzar = false;
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

    }

}
