using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject targetJugador;
    public GameObject rocaVolcanica;
    public GameObject targerAdelante;
    //public GameObject colisionLanzallamas;
   // public GameObject colisionCuerpoaCuerpo;
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
    public float tiempoAtaqueCuerpoaCuerpo;
    private float tiempoAtaqueLanzallamas;
    public float couldwCuerpoaCuerpo;
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemigo;
    public bool colliderCuerpoCuerpo;
    public bool colliderLanzaLlama;
    public float GuardadoX;
    public float GuardadoY;
    public float GuardadoZ;
    public bool mortero;
    public bool lanzallamas;
    public bool cuerpoCuerpo;
   // private float tiempoDeAtaques;

    private void Start()
    {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
   
    }

    private void Update()
    {
        AtaqueLejano();
        AtaqueLanzallamas();
        AtaqueCuerpoCuerpo();
        Seguimiento();
        SistemaDeAtaques();

    }

    public void AtaqueLejano()
    {
        if (lanzallamas == false && cuerpoCuerpo == false)
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

                            mortero = true;

                            creado = 2;
                        }
                    }

                    else if (tiempo >= 5)
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

                            mortero = true;

                            creado = 2;
                        }
                    }

                    else if (tiempo >= 5)
                    {
                        tiempo = 0;

                        creado = 1;
                    }

                    break;

            }
        }
    }

    public void SistemaDeAtaques()
    {
       //tiempoDeAtaques = tiempoDeAtaques + 1;

        colliderLanzaLlama = modeloJugador.lanzallamas;
        colliderCuerpoCuerpo = modeloJugador.cuerpoaCuerpo;

        if (tiempoAtaqueLanzallamas < 9f && tiempoAtaqueLanzallamas > 4f)
        {
            lanzallamas = false;
            //colisionLanzallamas.SetActive(false);
        }
       /* else
        {
            colisionLanzallamas.SetActive(true);
        }
       */
        if (tiempo >= 1f && tiempo <= 5f)
        {
            mortero = false;
        }

    }

    public void AtaqueLanzallamas()
    {
        if (colliderLanzaLlama == true && cuerpoCuerpo == false && mortero == false)
        {

            tiempoAtaqueLanzallamas = tiempoAtaqueLanzallamas + 1 * Time.deltaTime;
            if (tiempoAtaqueLanzallamas >= 1f && tiempoAtaqueLanzallamas <= 4f)
            {
                modeloJugador.vida -= 10;
                lanzallamas = true;

            }

            else if (tiempoAtaqueLanzallamas >= 9f)
            {
                tiempoAtaqueLanzallamas = 0;

            }
        }

    }

    public void AtaqueCuerpoCuerpo()
    {
        if (colliderCuerpoCuerpo == true && lanzallamas == false && mortero == false)
        {

            tiempoAtaqueCuerpoaCuerpo = tiempoAtaqueCuerpoaCuerpo + 1;

            if (tiempoAtaqueCuerpoaCuerpo <= 2f)
            {
                modeloJugador.vida = modeloJugador.vida - 10;

                cuerpoCuerpo = true;

                couldwCuerpoaCuerpo = 0;

            }
        }
        else if (cuerpoCuerpo == true)
        {

            couldwCuerpoaCuerpo = couldwCuerpoaCuerpo + 1 * Time.deltaTime;

            if (couldwCuerpoaCuerpo >= 4f)
            {
                tiempoAtaqueCuerpoaCuerpo = 0;


                //colisionCuerpoaCuerpo.SetActive(true);

                tiempoAtaqueCuerpoaCuerpo = 0;

                cuerpoCuerpo = false;

            }


        }
    }

    public void Seguimiento()
    {
        if (colliderCuerpoCuerpo == false)
        {
            enemigo.destination = jugador.position;
        }

        else if (colliderCuerpoCuerpo == true)
        {
            enemigo.destination = this.transform.position;
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
