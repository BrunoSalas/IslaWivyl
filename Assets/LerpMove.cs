using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove : MonoBehaviour
{
    public Transform inicio;
    public Transform final;
    public float velocidad;
    public float tiempo;
    public float recorrido;
    
    void Start()
    {
        
        tiempo= Time.time;
        recorrido = Vector3.Distance(inicio.position, final.position);

    }

    // Update is called once per frame
    void Update()
    {
        float distanciaRecorrida = (Time.time - tiempo)*velocidad;
        float porcionRecorrida = distanciaRecorrida / recorrido;
        transform.position = Vector3.Lerp (inicio.position, final.position,porcionRecorrida);
    }

    
}
