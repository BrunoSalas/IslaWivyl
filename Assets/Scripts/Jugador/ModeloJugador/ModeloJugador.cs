using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeloJugador : MonoBehaviour
{
    public GameObject gameplayManaguer;
    public Rigidbody rb;
    public float AldeanoRNG;
    public int habilidad;
    public int patos;
    public float vida;
    public float maximaVida;
    public float velocidadMov;
    public float salto = 0.4f;
    public float empujeSalto = 10;
    public bool enElSuelo;
    public bool poderUsable;
    public bool encimaDeTrampa; // variable para detectar trampa
    public Vector3 spawnPoint;
    public GameObject objCheckpoint;
    public float aceleracion;
    void Start()
    {
        enElSuelo = true;
    }

    
}
