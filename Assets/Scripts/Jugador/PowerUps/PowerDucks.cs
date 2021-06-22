using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDucks : MonoBehaviour
{
    private ModeloJugador modeloJugador;

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
        modeloJugador = GetComponent<ModeloJugador>();
        originalCooldownPato1Timer = cooldownPatosTimer;
        originalEffPato1Timer = effPato1Timer;
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
        if (modeloJugador.vida > modeloJugador.maximaVida)
        {
            modeloJugador.vida = modeloJugador.maximaVida;
        }
    }
    public IEnumerator patoVeloz()
    {
        velocidadPato1Mult = 2;
        yield return new WaitForSeconds(5f);
        velocidadPato1Mult = 1;
    }

    public void patoMuro()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
        GameObject muro = Instantiate(modeloJugador.muroPrefab);
        muro.transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);

    }

}
