
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladorJugador : MonoBehaviour
{
    public ModeloJugador modeloJugador;
    private TrampaManager trampaManager;
    private PowerDucks powerDucks;
    private Transform groundCheck;
    private float groundRad = 0.4f;
    private float velocidadCorreroriginal;
    private float velocidadCorrerMult=1f;
    private float velocidadPato1Mult=1f;
    private RaycastHit aldeano;
    private Rigidbody rb_mj;

    void Start()
    {
        rb_mj = modeloJugador.rb;
        velocidadCorreroriginal = modeloJugador.velocidadMovCorrer;
        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
        modeloJugador.vida = modeloJugador.maximaVida;
        modeloJugador = GetComponent<ModeloJugador>();
        powerDucks = GetComponent<PowerDucks>();
        //trampaManager = GetComponent<TrampaManager>(); Falta probar por temas de mi visual crasheado

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadCorrerMult = modeloJugador.velocidadMovCorrer;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadCorrerMult = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && modeloJugador.enElSuelo)
        {
            rb_mj.AddForce(0, modeloJugador.empujeSalto, 0, ForceMode.Impulse);
        }
        UsoDePower();
        Trampas();

    }
    private void FixedUpdate()
    {
        modeloJugador.enElSuelo = Physics.CheckSphere(groundCheck.position, groundRad, modeloJugador.groundMask);
        //float velocidadMov_mj = modeloJugador.velocidadMov; //Herencia de la clase ModeloJugador
        float movHorizontal = Input.GetAxisRaw("Horizontal") * modeloJugador.velocidadMov * velocidadCorrerMult *velocidadPato1Mult;
        float movVertical = Input.GetAxisRaw("Vertical") * modeloJugador.velocidadMov * velocidadCorrerMult * velocidadPato1Mult;

        rb_mj.velocity = (transform.forward * movVertical) + (transform.right * movHorizontal) + (transform.up * rb_mj.velocity.y);


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

        if (Input.GetKeyDown(KeyCode.Q)&&(powerDucks.ListoPato1)) // && modeloJugador.patos >= 1)//Herencia de la clase ModeloJugador
        {
            powerDucks.onEffPato1 = true;
            powerDucks.ListoPato1 = false;
            //powerDucks.PoderDos();//Herencia de la clase PowerDucks 
            //powerDucks.PoderUno();//Herencia de la clase PowerDucks
            
        }
        if (powerDucks.onEffPato1)
        {
            velocidadPato1Mult = powerDucks.multiplicadorVelocidadPato1;
        }
        else
        {
            velocidadPato1Mult = 1;
        }
            
    }

    
    public void Trampas()
    {
        if (modeloJugador.encimaDeTrampa == true)
        {
            modeloJugador.encimaDeTrampa = false;//Herencia de la clase ModeloJugador
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
        if (other.gameObject.CompareTag("TrampaFoso"))
        {
            modeloJugador.vida -= 100;
            //trampaManager.numeroTrampa = 2; Falta probar por tema de unity crasheado
        }
        if (other.gameObject.CompareTag("Lanzallama"))
        {
            modeloJugador.lanzallamas = true;
        }

        if (other.gameObject.CompareTag("CuerpoaCuerpo"))
        {
            modeloJugador.cuerpoaCuerpo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Lanzallama"))
        {
            modeloJugador.lanzallamas = false;
        }

        if (other.gameObject.CompareTag("CuerpoaCuerpo"))
        {
            modeloJugador.cuerpoaCuerpo = false;
        }
    }

}