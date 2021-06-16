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
    public bool tienepato1;
    public bool tienepato2;
    public bool tienepato3;
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
        if(!ListoPato1)
        {
            cooldownPatosTimer -= Time.deltaTime;
            if(cooldownPatosTimer <=0)
            {
                ListoPato1 = true;
                cooldownPatosTimer = originalCooldownPato1Timer;
            }
        }

        if(onEffPato1)
        {
            effPato1Timer -= Time.deltaTime;
            if(effPato1Timer<=0)
            {
                onEffPato1 = false;
                effPato1Timer = originalEffPato1Timer;
            }
        }

        if (tiempoVelocidadDuracion == true)
        {
            tiempo = tiempo + 1 * Time.deltaTime;

            if (tiempo >= limite)
            {
                modeloJugador.velocidadMov = velocidadGuardado;//Herencia de la clase modeloJugador

                tiempo = 0;

                tiempoVelocidadDuracion = false;

                usos = 1;
            }
        }
    }

    public IEnumerator patosCooldown()
    {
        yield return 10f;
        patosListos = true;
    }
    public IEnumerator patoCura()
    {
        modeloJugador.vida += 5;
        if(modeloJugador.vida>modeloJugador.maximaVida)
        {
            modeloJugador.vida = modeloJugador.maximaVida;
        }
        yield return 5f;
        modeloJugador.vida += 5;
        if (modeloJugador.vida > modeloJugador.maximaVida)
        {
            modeloJugador.vida = modeloJugador.maximaVida;
        }
        yield return 5f;
        modeloJugador.vida += 5;
        if (modeloJugador.vida > modeloJugador.maximaVida)
        {
            modeloJugador.vida = modeloJugador.maximaVida;
        }
        

    }

}
