
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;


public class ControladorJugador : MonoBehaviour
{
    public ModeloJugador modeloJugador;
    public TrampaManager trampaManager;
    public SceneMaster sceneMaster;
    private PowerDucks powerDucks;
    private Transform groundCheck;

    public lav lavaTrigger;

    Vector3 movedire;
    private float groundRad = 0.4f;
    private float velocidadCorreroriginal;
    private float velocidadCorrerMult = 1f;
    CharacterController controller;
    private RaycastHit aldeano;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //rb_mj = modeloJugador.rb;
        velocidadCorreroriginal = modeloJugador.velocidadMovCorrer;
        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
        modeloJugador.vida = modeloJugador.maximaVida;
        modeloJugador = GetComponent<ModeloJugador>();
        powerDucks = GetComponent<PowerDucks>();
        modeloJugador.anima = GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadCorrerMult = modeloJugador.velocidadMovCorrer;
            modeloJugador.anima.SetBool("Corriendo", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadCorrerMult = 1;
            modeloJugador.anima.SetBool("Corriendo", false);
        }

        UsoDePower();
        Trampas();
        Interactuar();

    }
    private void FixedUpdate()
    {
        modeloJugador.enElSuelo = Physics.CheckSphere(groundCheck.position, groundRad, modeloJugador.groundMask);
        float movHorizontal = Input.GetAxisRaw("Horizontal"); //* modeloJugador.velocidadMov * velocidadCorrerMult * powerDucks.velocidadPato1Mult;
        float movVertical = Input.GetAxisRaw("Vertical"); //* modeloJugador.velocidadMov * velocidadCorrerMult * powerDucks.velocidadPato1Mult;
        if (movHorizontal == 0 && movVertical == 0)
        {
            modeloJugador.pasos.SetActive(false);
        }
        else
        {
            modeloJugador.pasos.SetActive(true);
        }
        Vector3 direction = new Vector3(movHorizontal, 0, movVertical);
        Vector3 movement = transform.TransformDirection(direction);
        Vector3 movimientoplano = modeloJugador.velocidadMov * velocidadCorrerMult * powerDucks.velocidadPato1Mult * Time.deltaTime * movement;
        movedire = new Vector3(movimientoplano.x, movedire.y, movimientoplano.z);
        if (salto)
        {
            movedire.y = modeloJugador.empujeSalto;
            modeloJugador.anima.SetTrigger("Saltar");

        }
        else if (modeloJugador.enElSuelo)
        {

            movedire.y = 0f;
        }
        else
        {
            movedire.y -= modeloJugador.gravedad * Time.deltaTime;


        }
        controller.Move(movedire);
    }
    void ModificadorVida(bool aumento, float valor)
    {
        if (aumento)
        {
            modeloJugador.vida += valor;
            if (modeloJugador.vida > modeloJugador.maximaVida)
            {
                modeloJugador.vida = modeloJugador.maximaVida;
            }
        }
        else
        {
            modeloJugador.vida -= valor;
            if (modeloJugador.vida < 0)
            {
                modeloJugador.gameplayManaguer.GetComponent<GameplayControlador>().Perdiste();
            }
        }


    }

    public void UsoDePower()
    {

        if (Input.GetKeyDown(KeyCode.Q) && (powerDucks.patosListos) && (powerDucks.patos1 > 0)) // && modeloJugador.patos >= 1)//Herencia de la clase ModeloJugador
        {
            powerDucks.patos1--;
            StartCoroutine(powerDucks.patosCooldown());
            StartCoroutine(powerDucks.patoCura());
            Debug.Log("PatoCurar");
            modeloJugador.UiManaguer.ActualizarPatos();
        }
        if (Input.GetKeyDown(KeyCode.E) && (powerDucks.patosListos) && (powerDucks.patos2 > 0))
        {
            powerDucks.patos2--;
            StartCoroutine(powerDucks.patosCooldown());
            StartCoroutine(powerDucks.patoVeloz());
            modeloJugador.UiManaguer.ActualizarPatos();
            Debug.Log("PatoVelocidad");
        }
        if (Input.GetKeyDown(KeyCode.R) && (powerDucks.patosListos) && (powerDucks.patos3 > 0))
        {
            powerDucks.patos3--;
            StartCoroutine(powerDucks.patosCooldown());
            powerDucks.patoMuro();
            modeloJugador.UiManaguer.ActualizarPatos();
            Debug.Log("PatoMuro");

        }

    }

    public void Interactuar()
    {
        if (Input.GetKeyDown(KeyCode.F) && modeloJugador.aldeanoEnRango)
        {
            modeloJugador.aldeanoInteractuable.GetComponent<AldeanoScript>().PatoRng(powerDucks);
            modeloJugador.aldeanosAgarrados += 1;
            //Destroy(modeloJugador.aldeanoInteractuable,3f);
            // modeloJugador.aldeanoInteractuable.GetComponent<Animator>().SetTrigger("TY");
            modeloJugador.UiManaguer.ActualizarPatos();
            modeloJugador.UiManaguer.DesactivarTeclaInteractuar();
            
        }
    }
    private bool salto => (modeloJugador.enElSuelo) && (Input.GetKey(KeyCode.Space));

    public void Trampas()
    {
        if (modeloJugador.encimaDeTrampa == true)
        {
            modeloJugador.encimaDeTrampa = false;//Herencia de la clase ModeloJugador
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            modeloJugador.enElSuelo = true;//Herencia de la clase ModeloJugador
        }

        /*
                if (other.gameObject.CompareTag("Trampa3"))
                {
                    trampaManager.numeroTrampa = 3;
                }
        */
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            modeloJugador.spawnPoint = modeloJugador.objCheckpoint.transform.position;
        }

        if (other.gameObject.CompareTag("RocaVolcanica"))
        {
            modeloJugador.maximaVida = modeloJugador.maximaVida - 100;
            Morir();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trampa"))
        {
            modeloJugador.encimaDeTrampa = true;//Herencia de la clase ModeloJugador
        }

        if (other.gameObject.CompareTag("Lanzallama"))
        {
            modeloJugador.lanzallamas = true;
        }

        if (other.gameObject.CompareTag("CuerpoaCuerpo"))
        {
            modeloJugador.cuerpoaCuerpo = true;
        }
        /* if (other.gameObject.CompareTag("Trampa1"))
         {
             trampaManager.numeroTrampa = 1;
             Debug.Log("Col Trampa 1");
         }*/
        if (other.gameObject.CompareTag("TroncoTrampa1"))
        {
            Debug.Log("Parfavar");
            modeloJugador.vida -= 100;
            Morir();
        }
        if (other.gameObject.CompareTag("Trampa3"))
        {
            trampaManager.numeroTrampa = 3;
            Destroy(other);
            Debug.Log("Chino");
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
        if (other.gameObject.CompareTag("LavaTrigger"))
        {
            lavaTrigger.fuerza = 0.047f;
        }
        if (other.gameObject.CompareTag("MetaFinal1") && modeloJugador.aldeanosAgarrados >= modeloJugador.aldeanosRequeridos)
        {
            sceneMaster.ToGanasteScene();
            modeloJugador.aldeanosRequeridos = 5;

        }
         if (other.gameObject.CompareTag("MetaFinal1") && modeloJugador.aldeanosAgarrados < modeloJugador.aldeanosRequeridos)
        {
           modeloJugador.requisitoBool = true;
        }
         if (other.gameObject.CompareTag("MetaFinal2") && modeloJugador.aldeanosAgarrados >= modeloJugador.aldeanosRequeridos)
        {
            sceneMaster.ToGanasteScene();
            modeloJugador.aldeanosRequeridos = 4;
            
        }
         if (other.gameObject.CompareTag("MetaFinal2") && modeloJugador.aldeanosAgarrados < modeloJugador.aldeanosRequeridos)
        {
           modeloJugador.requisitoBool = true;
           Debug.Log("Ga");
        }
         if (other.gameObject.CompareTag("MetaFinal3") && modeloJugador.aldeanosAgarrados >= modeloJugador.aldeanosRequeridos)
        {
            sceneMaster.ToGanasteScene();
        }
        //Activar el teto sobre requisito para pasar nivel
         if (other.gameObject.CompareTag("MetaFinal3") && modeloJugador.aldeanosAgarrados < modeloJugador.aldeanosRequeridos)
        {
           modeloJugador.requisitoBool = true;
        }

        if (other.gameObject.CompareTag("Trampa2"))
        {
            
            modeloJugador.vida -= 100;
            Morir();
        }
        if (other.gameObject.CompareTag("Requisito"))
        {
            
            modeloJugador.requisitoBool = false;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Crater"))
        {
            modeloJugador.vida -= 0.30f;
            Debug.Log("aa");
            Morir();
        }
        if (other.gameObject.CompareTag("DanoAura")){
            modeloJugador.vida -= 0.9f;
            Morir();
        }
    }
    public void Morir()
    {
        StartCoroutine(EffDano());
        if (modeloJugador.vida <= 0)
        {
            
            Cursor.lockState = CursorLockMode.None;
            sceneMaster.ToPerdisteScene();
        }
    }
    public IEnumerator EffDano()
    {
        modeloJugador.UiManaguer.EFFDano.SetActive(true);
        yield return new WaitForSeconds(1f);
        modeloJugador.UiManaguer.EFFDano.SetActive(false);
    }

}