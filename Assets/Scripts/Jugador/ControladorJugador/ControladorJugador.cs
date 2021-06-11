
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladorJugador : MonoBehaviour
{
    public ModeloJugador modeloJugador;
    private PowerDucks powerDucks;
    private TrampaCuevaPiedras trampaPiedras;

    void Start()
    {
        modeloJugador.vida = modeloJugador.maximaVida;
        modeloJugador = GetComponent<ModeloJugador>();
        powerDucks = GetComponent<PowerDucks>();

        trampaPiedras = GetComponent<TrampaCuevaPiedras>();
    }


    void Update()
    {
        Movimiento();
        Correr();
        UsoDePower();
        Trampas();

    }
    //Función para modificar la vida
    void ModificadorVida(bool aumento,float valor)
    {
        if(aumento)
        {
            modeloJugador.vida += valor;
            if(modeloJugador.vida>modeloJugador.maximaVida)
            {
                modeloJugador.vida = modeloJugador.maximaVida;
            }
        }
        else
        {
            modeloJugador.vida -= valor;
            if(modeloJugador.vida<0)
            {
                modeloJugador.gameplayManaguer.GetComponent<GameplayControlador>().Perdiste();
            }
        }


    }

    public void UsoDePower()
    {
        if (Input.GetKeyDown(KeyCode.Q) && modeloJugador.patos >= 1)//Herencia de la clase ModeloJugador
        {
            powerDucks.PoderDos();//Herencia de la clase PowerDucks
            powerDucks.PoderUno();//Herencia de la clase PowerDucks
            
        }
            
    }

    
    public void Trampas()
    {
        if (modeloJugador.encimaDeTrampa == true)
        {
            trampaPiedras.TrampaSegundo();//Herencia de la clase TrampaCuevaPiedras
            modeloJugador.encimaDeTrampa = false;//Herencia de la clase ModeloJugador
        }
    }
    
    void Movimiento()
    {
        Rigidbody rb_mj = modeloJugador.rb; //Herencia de la clase ModeloJugador
        float velocidadMov_mj = modeloJugador.velocidadMov; //Herencia de la clase ModeloJugador
        float movHorizontal = Input.GetAxisRaw("Horizontal");
        float movVertical = Input.GetAxisRaw("Vertical");

        if (movHorizontal != 0.0f || movVertical != 0.0f)
        {
             Vector3 direccion = transform.forward * movVertical + transform.right * movHorizontal;

           rb_mj.MovePosition(transform.position + direccion* velocidadMov_mj * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            modeloJugador.enElSuelo = false; //Herencia de la clase ModeloJugador
            rb_mj.AddForce(0, modeloJugador.empujeSalto, 0, ForceMode.Impulse);

        }
    }

    void Correr()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            modeloJugador.velocidadMov += modeloJugador.aceleracion;
        }
    }
    void AldeanoPatoProbabilidad()
    {
        if (Random.Range(1f, 100f) < modeloJugador.AldeanoRNG)
        {
            Debug.Log("Aldeano me dio pato");
        }
        else
        {
            Debug.Log("Aldeano NO me dio pato");
        }
    }

  

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            modeloJugador.enElSuelo = true;//Herencia de la clase ModeloJugador
        }
        if (other.gameObject.CompareTag("Trampa1"))
        {
            Debug.Log("Ya veremos");
        }
        if (other.gameObject.CompareTag("Trampa2"))
        {
            Debug.Log("Ya veremos");
        }
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            modeloJugador.spawnPoint = modeloJugador.objCheckpoint.transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trampa"))
        {
            modeloJugador.encimaDeTrampa = true;//Herencia de la clase ModeloJugador
        }
        if(other.gameObject.CompareTag("Aldeano"))
        {
            Destroy(other);
            AldeanoPatoProbabilidad();
        }
    }
  
}