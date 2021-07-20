
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
    public BossPoderes boss;

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
        velocidadCorrerMult = modeloJugador.velocidadMovCorrer;

    }
    void Update()
    {


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
            modeloJugador.anima.SetBool("Corriendo", false);
        }
        else
        {
            modeloJugador.pasos.SetActive(true);
            modeloJugador.anima.SetBool("Corriendo", true);
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
        if (Input.GetKeyDown(KeyCode.E) && (powerDucks.patosListos) && (powerDucks.patos3 > 0))
        {
            powerDucks.patos3--;
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
            modeloJugador.aldeanoInteractuable.GetComponent<AldeanoScript>().PatoRng(powerDucks,modeloJugador);
            //modeloJugador.aldeanosAgarrados += 1;
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
        if(other.gameObject.CompareTag("RocaVolcanica")){
            modeloJugador.vida -=100;
            Morir();
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
        if (other.gameObject.CompareTag("Trigger1")){
            Debug.Log ("Bruh");
            boss.lanzar = true;
            boss.numeroObjetivo = 1;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger2")){
            boss.lanzar = true;
            boss.numeroObjetivo = 2;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger3")){
            boss.lanzar = true;
            boss.numeroObjetivo = 3;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger4")){
            boss.lanzar = true;
            boss.numeroObjetivo = 4;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger5")){
            boss.lanzar = true;
            boss.numeroObjetivo = 5;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger6")){
            boss.lanzar = true;
            boss.numeroObjetivo = 6;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger7")){
            boss.lanzar = true;
            boss.numeroObjetivo = 7;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger8")){
            boss.lanzar = true;
            boss.numeroObjetivo = 8;
            Destroy(other);
        }
        if (other.gameObject.CompareTag("Trigger9")){
            boss.lanzar = true;
            boss.numeroObjetivo = 9;
            Destroy(other);
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
        if(other.gameObject.CompareTag("Lanzallama")){
            modeloJugador.vida -= 2f;
            Morir();
        }
    }
    public void Morir()
    {
        StartCoroutine(EffDano());
        if (modeloJugador.vida <= 0)
        {
            
            Cursor.lockState = CursorLockMode.None;
            powerDucks.PatosCero();
            sceneMaster.ToPerdisteScene();
        }
    }
    public IEnumerator EffDano()
    {
        modeloJugador.UiManaguer.EFFDano.SetActive(true);
        yield return new WaitForSeconds(1f);
        modeloJugador.UiManaguer.EFFDano.SetActive(false);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Trampolin":
                movedire.y = 0.4f;
                modeloJugador.anima.SetTrigger("Saltar");
                break;
            case "Piso":
                movedire.y = 0f;
                break;
        }
    }
}