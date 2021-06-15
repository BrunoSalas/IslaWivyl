using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject targetJugador;
    public GameObject rocaVolcanica;
    public GameObject targerAdelante;
    public ModeloJugador modeloJugador;
    private int creado;
    private int parado;
    private float targetAdelanteX;
    private float targetAdelanteY;
    private float targetAdelanteZ;
    public float targetJugadorX;
    public float targetJugadorY;
    public float targetJugadorZ;
    private float tiempo = 1;
    private float tiempoGuardado;
    private int tiempoAtaqueCuerpoaCuerpo;
    private float couldwCuerpoaCuerpo;
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemigo;
    public bool colliderCuerpoCuerpo;
    public bool colliderLanzaLlama;
    public float GuardadoX;
    public float GuardadoY;
    public float GuardadoZ;
    private bool mortero;
    private bool lanzallamas;
    private bool cuerpoCuerpo;
    private float tiempoDeAtaques;

    private void Start()
    {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
   
    }

    private void Update()
    {
        AtaqueLejano();
        AtaqueCercano();
        AtaqueCuerpoCuerpo();
        Seguimiento();
        SistemaDeAtaques();

    }

    public void AtaqueLejano()
    {
        targetAdelanteX = targerAdelante.transform.position.x;
        targetAdelanteY = targerAdelante.transform.position.y;
        targetAdelanteZ = targerAdelante.transform.position.z;

        targetJugadorX = targetJugador.transform.position.x;
        targetJugadorY = targetJugador.transform.position.y;
        targetJugadorZ = targetJugador.transform.position.z;

        tiempo = tiempo + 1 * Time.deltaTime;

        tiempoGuardado = tiempoGuardado + 1 * Time.deltaTime;

        if (tiempoGuardado >= 3f)
        {
            GuardadoX = targetJugadorX;
            GuardadoY = targetJugadorY;
            GuardadoZ = targetJugadorZ;

            tiempoGuardado = 0;
        }

        if (GuardadoX == targetJugadorX && GuardadoY == targetJugadorY && GuardadoZ == targetJugadorZ)
        {
            parado = 1;
        }

        else
        {
            parado = 2;
        }

        switch (parado)
        {
            case 1:
                if (tiempo <= 1)
                {
                    Vector3 RocaVolcanica = new Vector3(targetJugadorX, targetJugadorY + 10, targetJugadorZ);

                    if (creado == 1)
                    {
                        Instantiate(rocaVolcanica, RocaVolcanica, transform.rotation);

                        creado = 2;
                    }
                }

                else if(tiempo >= 3)
                {
                    tiempo = 0;

                    creado = 1;
                }
                break;

            case 2:
                if (tiempo <= 1)
                {
                    Vector3 RocaVolcanica = new Vector3(targetAdelanteX, targetAdelanteY + 10, targetAdelanteZ);

                    if (creado == 1)
                    {
                        Instantiate(rocaVolcanica, RocaVolcanica, transform.rotation);

                        creado = 2;
                    }
                }

                else if (tiempo >= 3)
                {
                    tiempo = 0;

                    creado = 1;
                }

                break;
        }
    }

    public void SistemaDeAtaques()
    {
        tiempoDeAtaques = tiempoDeAtaques + 1;

        colliderLanzaLlama = modeloJugador.lanzallamas;
        colliderCuerpoCuerpo = modeloJugador.cuerpoaCuerpo;

        bool cinco = false;
        bool seis = false;
        bool dos = false;

        if (tiempoDeAtaques % 6 == 0 && cinco == false && dos == false)
        {
            lanzallamas = true;

            seis = true;
        }

        else
        {
            lanzallamas = false;

            seis = false;

        }

        if (tiempoDeAtaques % 5 == 0 && dos == false && seis == false)
        {
            mortero = true;

            cinco = true;
        }

        else
        {
            mortero = false;

            cinco = false;
        }

        if (tiempoDeAtaques % 2 == 0 && seis == false && cinco == false)
        {
            cuerpoCuerpo = true;

            dos = true;
        }
        else
        {
            cuerpoCuerpo = false;

            dos = false;
        }
    }

    public void AtaqueCercano()
    {
        if (cuerpoCuerpo == false)
        { }

    }

    public void AtaqueCuerpoCuerpo()
    {
        if (colliderCuerpoCuerpo == true && cuerpoCuerpo == true)
        {
            tiempoAtaqueCuerpoaCuerpo = tiempoAtaqueCuerpoaCuerpo + 1;

            if (tiempoAtaqueCuerpoaCuerpo <= 2f)
            {
                modeloJugador.maximaVida = modeloJugador.maximaVida - 10;

                couldwCuerpoaCuerpo = 0;

            }

            else
            {

                couldwCuerpoaCuerpo = couldwCuerpoaCuerpo + 1 * Time.deltaTime;

                if (couldwCuerpoaCuerpo >= 2f)
                {
                    tiempoAtaqueCuerpoaCuerpo = 0;

                }
            }

            //enemigo.destination = this.transform.position;
        }

        else
        {
            cuerpoCuerpo = false;
        }

    }

    public void Seguimiento()
    {
        if (colliderCuerpoCuerpo == false)
        {
            enemigo.destination = jugador.position;
        }

    }

    /*
    public GameObject parteNucleo;
    public GameObject targetAdel;
    public GameObject targetJuga;
    public float time;
    public int sale;
    public int parado;

    public float targetAdelX;
    public float targetAdelY;
    public float targetAdelZ;

    public float targetJugaX;
    public float targetJugaY;
    public float targetJugaZ;

    public float T;

    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ataque();


    }

    public void ataque()
    {
        //target jugador cambio
        targetAdelX = targetAdel.transform.position.x;
        targetAdelY = targetAdel.transform.position.y;
        targetAdelZ = targetAdel.transform.position.z;

        targetJugaX = targetJuga.transform.position.x;
        targetJugaY = targetJuga.transform.position.y;
        targetJugaZ = targetJuga.transform.position.z;

        //ultTim = ultTim + 1 * Time.deltaTime;


        T = T + 1 * Time.deltaTime;

        time = time + Time.deltaTime * 1;

        if (T >= 3f)
        {
            x = targetJugaX;
            y = targetJugaY;
            z = targetJugaZ;

            T = 0;
        }

        if (x == targetJugaX && y == targetJugaY && z == targetJugaZ)
        {
            parado = 1;


        }
        else
        {
            parado = 2;
        }

        switch (parado)
        {
            case 1:

                if (time <= 1)
                {
                    Vector3 spawnNucleo = new Vector3(targetJugaX, targetJugaY + 10, targetJugaZ);

                    if (sale == 1)
                    {
                        Instantiate(parteNucleo, spawnNucleo, transform.rotation);

                        //T = 0;


                        sale = 2;
                    }
                }
                else if (time >= 3)
                {
                    time = 0;

                    //B = false;
                    sale = 1;

                    Debug.Log("b");
                }
                break;

            case 2:

                if (time <= 1)
                {
                    Vector3 spawnNucleo = new Vector3(targetAdelX, targetAdelY + 10, targetAdelZ);

                    if (sale == 1)
                    {
                        Instantiate(parteNucleo, spawnNucleo, transform.rotation);

                        // T = 0;
                        sale = 2;
                    }
                }
                else if (time >= 3)
                {
                    time = 0;

                    Debug.Log("D");
                    sale = 1;
                }
                break;
        }
    }
    */
}
