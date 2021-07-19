using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDucks : MonoBehaviour
{
    private ModeloJugador modeloJugador;
    private CharacterController control;

    public bool patosListos;

    public float effPato1Timer;
    private float originalEffPato1Timer;
    public bool onEffPato1;
    public float cooldownPatosTimer;
    private float originalCooldownPato1Timer;
    public float multiplicadorVelocidadPato1;
    public bool ListoPato1;
    public float velocidadPato1Mult = 1f;
    public int patos1;
    public int patos2;
    public int patos3;
    public static int patos1Acum;
    public static int patos2Acum;
    public static int patos3Acum;
    public float curacion;
    public float velocidadAumentada;
    public float velocidadGuardado;
    public float tiempo;
    public float limite;
    public int usos = 1;
    bool tiempoVelocidadDuracion = false;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
        modeloJugador = GetComponent<ModeloJugador>();
        originalCooldownPato1Timer = cooldownPatosTimer;
        originalEffPato1Timer = effPato1Timer;
        ResetPatos();
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public IEnumerator patosCooldown()
    {
        patosListos = false;
        yield return new WaitForSeconds(5f) ;
        patosListos = true;
    }
    public IEnumerator patoCura()
    {
        modeloJugador.vida += 5;
        modeloJugador.UiManaguer.EFFCura.SetActive(true);
        if(modeloJugador.vida>modeloJugador.maximaVida)
        {
            modeloJugador.vida = modeloJugador.maximaVida;
        }
        yield return new WaitForSeconds(5f);
        modeloJugador.vida += 5;
        if (modeloJugador.vida > modeloJugador.maximaVida)
        {
            modeloJugador.vida = modeloJugador.maximaVida;
        }
        yield return new WaitForSeconds(5f);
        modeloJugador.vida += 5;
        modeloJugador.UiManaguer.EFFCura.SetActive(false);
        if (modeloJugador.vida > modeloJugador.maximaVida)
        {
            modeloJugador.vida = modeloJugador.maximaVida;
        }
    }
    public IEnumerator patoVeloz()
    {
        velocidadPato1Mult = 2;
        modeloJugador.UiManaguer.EFFVelocidad.SetActive(true);
        yield return new WaitForSeconds(5f);
        modeloJugador.UiManaguer.EFFVelocidad.SetActive(false);
        velocidadPato1Mult = 1;
    }

    public void patoMuro()
    {
        /*control.enabled = false;
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
        GameObject muro = Instantiate(modeloJugador.muroPrefab);
        muro.transform.position = new Vector3(transform.position.x, transform.position.y-2, transform.position.z);
        control.enabled = true;*/

    }
    public void ResetPatos()
    {
        patos1 = patos1Acum;
        patos2 = patos2Acum;
        patos3 = patos3Acum;
    }
    public void ActualizarPatos()
    {
        patos1Acum = patos1;
        patos2Acum = patos2;
        patos3Acum = patos3;
    }
    public void PatosCero()
    {
        patos1 = 0;
        patos2 = 0;
        patos3 = 0;
        patos1Acum = patos1;
        patos2Acum = patos2;
        patos3Acum = patos3;

    }

}
