using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeloJugador : MonoBehaviour
{
    public GameObject gameplayManaguer;
    //public Rigidbody rb;
    public LayerMask groundMask;

    public GameObject muroPrefab;
    public Animator anima;
    public float vida;
    public float maximaVida;
    public float velocidadMov;
    public float velocidadMovCorrer; // se usa para multiplicar la velocidad mientras se presiona shift
    public float maxVelocidad;
    public float gravedad = 2f;
    public float empujeSalto = 10;
    public bool enElSuelo;
    public bool poderUsable;
    public bool encimaDeTrampa; // variable para detectar trampa
    public UIManaguer UiManaguer;
    public bool aldeanoEnRango;
    public GameObject aldeanoInteractuable;
    public GameObject pasos;
    public float aldeanosAgarrados = 0;
    public float aldeanosRequeridos;

    public Vector3 spawnPoint;
    public GameObject objCheckpoint;
    public float aceleracion;
    public bool lanzallamas;
    public bool cuerpoaCuerpo;
    public bool requisitoBool = false;
    void Start()
    {
        enElSuelo = true;
        
       
    }

    
}
