
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;


public class ControladorJugador : MonoBehaviour
{
    public ModeloJugador modeloJugador;
    public TrampaManager trampaManager;
    private PowerDucks powerDucks;
    private Transform groundCheck;
    private float groundRad = 0.4f;
    private float velocidadCorreroriginal;
    private float velocidadCorrerMult=1f;
    
    
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
        Interactuar();

    }
    private void FixedUpdate()
    {
        modeloJugador.enElSuelo = Physics.CheckSphere(groundCheck.position, groundRad, modeloJugador.groundMask);
        //float velocidadMov_mj = modeloJugador.velocidadMov; //Herencia de la clase ModeloJugador
        float movHorizontal = Input.GetAxisRaw("Horizontal") * modeloJugador.velocidadMov * velocidadCorrerMult * powerDucks.velocidadPato1Mult;
        float movVertical = Input.GetAxisRaw("Vertical") * modeloJugador.velocidadMov * velocidadCorrerMult * powerDucks.velocidadPato1Mult;

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

        if (Input.GetKeyDown(KeyCode.Q) && (powerDucks.patosListos)) // && modeloJugador.patos >= 1)//Herencia de la clase ModeloJugador
        {
            StartCoroutine(powerDucks.patosCooldown());
            StartCoroutine(powerDucks.patoCura());
            Debug.Log("PatoCurar");
        }
        if (Input.GetKeyDown(KeyCode.E) && (powerDucks.patosListos))
        {
            StartCoroutine(powerDucks.patosCooldown());
            StartCoroutine(powerDucks.patoVeloz());
            Debug.Log("PatoVElocidad");
        }
                   
    }

    public void Interactuar()
    {
        if(Input.GetKeyDown(KeyCode.F) && modeloJugador.aldeanoEnRango)
        {
            modeloJugador.aldeanoInteractuable.GetComponent<AldeanoScript>().PatoRng(powerDucks);
            Destroy(modeloJugador.aldeanoInteractuable);
            modeloJugador.UiManaguer.DesactivarTeclaInteractuar();
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
            trampaManager.numeroTrampa = 1;
        }
        if (other.gameObject.CompareTag("Trampa2"))
        {
            trampaManager.numeroTrampa = 2;
        }

        if (other.gameObject.CompareTag("Trampa3"))
        {
            trampaManager.numeroTrampa = 3;
        }

        if (other.gameObject.CompareTag("CheckPoint"))
        {
            modeloJugador.spawnPoint = modeloJugador.objCheckpoint.transform.position;
        }

        if (other.gameObject.CompareTag("RocaVolcanica"))
        {
            modeloJugador.maximaVida = modeloJugador.maximaVida - 100;
        }

        /*if (other.gameObject.CompareTag("MetaFinal"))
        {
            SceneManager.LoadScene("Ganar");
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trampa"))
        {
            modeloJugador.encimaDeTrampa = true;//Herencia de la clase ModeloJugador
        }
        /*if (other.gameObject.CompareTag("TrampaFoso"))
        {
            modeloJugador.vida -= 100;
            
        }
        */
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Crater"))
        {
            modeloJugador.vida -= 10;
        }
        
    }

    /* private void Morir ()
     {
        if (modelojugador.vida = 0)
        {
            SceneManager.LoadScene("Perder");
    */

}