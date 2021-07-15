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
    Vector3 impulso;
    void Start()
    {
        trampas = GameObject.FindGameObjectsWithTag ("SpawnTrampas");
        impulso = new Vector3 (0,5,0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            EscogerSpawn ();

            if (timer>6)
            {
                timer = 0;
                CrearPiedras();
            }
        }
    }


    public void CrearPiedras (){
        GameObject piedrasTemporales = Instantiate(piedras);
        piedrasTemporales.transform.position = trampaEscogida.transform.position;
        Vector3 piedrasTemp = piedrasTemporales.transform.position;
        piedrasTemp += impulso;
        
    }

    void EscogerSpawn  (){
        i = Random.Range (0,trampas.Length);
        trampaEscogida = trampas [i];
    }
}
