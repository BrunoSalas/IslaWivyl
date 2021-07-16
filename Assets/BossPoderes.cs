using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPoderes : MonoBehaviour
{
    public GameObject [] trampas;
    GameObject trampaEscogida;
    public GameObject piedras;
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
     

            if (timer>6)
            {
                timer = 0;
                animator.SetTrigger ("Rugido");
                sonido.Play();
                CrearPiedras();
            }
        
    }


    public void CrearPiedras (){
        //GameObject piedrasTemporales = Instantiate(piedras);
        //piedrasTemporales.transform.position = trampaEscogida.transform.position;
        for (i=0 ; i<trampas.Length; i++){
            trampaEscogida = trampas [i];
            GameObject piedrasTemporales = Instantiate(piedras);
            piedrasTemporales.transform.position = trampaEscogida.transform.position;
            Destroy(piedrasTemporales, 5f);
        }
        
    }

    void EscogerSpawn  (){
        
        
        //trampaEscogida = trampas [0];
    }
}
