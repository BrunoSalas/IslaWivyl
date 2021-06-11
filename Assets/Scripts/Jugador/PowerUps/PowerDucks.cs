using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDucks : MonoBehaviour
{
    private ModeloJugador modeloJugador;

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
    }

    // Update is called once per frame
    void Update()
    {
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

    public void PoderUno()
    {
        if (modeloJugador.habilidad == 1)
        {
            if (modeloJugador.maximaVida < 100)
            {
                modeloJugador.maximaVida = modeloJugador.maximaVida + curacion;//Herencia de la clase modeloJugador


                modeloJugador.patos = modeloJugador.patos - 1;//Herencia de la clase modeloJugador
            }
        }
    }

    public void PoderDos()
    {
        if (modeloJugador.habilidad == 2 && usos == 1)
        {
            velocidadGuardado = modeloJugador.velocidadMov;//Herencia de la clase modeloJugador

            modeloJugador.velocidadMov = modeloJugador.velocidadMov + velocidadAumentada;//Herencia de la clase modeloJugador

            tiempoVelocidadDuracion = true;

            usos = 2;


            modeloJugador.patos = modeloJugador.patos - 1;//Herencia de la clase modeloJugador

        }
    }
}
