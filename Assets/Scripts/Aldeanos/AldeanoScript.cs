using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldeanoScript : MonoBehaviour
{
    public float probabilidadesPatoCura;
    public float probabilidadesPatoVeloz;
    public float probabilidadesPatoMuro;
    public float probabilidadesNada;
    int rngCalculator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
	void Morir()
    {
        //Destroy(gameObject, 6f);
        Debug.Log ("Gaa");
    }

    public void PatoRng(PowerDucks ducks)
    {
        Debug.Log("RNG");
        rngCalculator = Random.Range(1, 4);
        Debug.Log(rngCalculator);
        switch (rngCalculator)
        {
            case 1:
                Debug.Log("1");
                ducks.patos1++;
                //codigo de animacion
                //Play.Animation("Agradecimiento");
                //Destroy(gameObject,4.5f);
                Destroy(gameObject);
                break ;
            case 2:
                Debug.Log("2");
                ducks.patos2++;
                //codigo de animacion
                //Play.Animation("Agradecimiento");
                //Destroy(gameObject,4.5f);
                Destroy(gameObject);
                break;
            case 3:
                Debug.Log("3");
                ducks.patos3++;
                //codigo de animacion
                //Play.Animation("Agradecimiento");
                //Destroy(gameObject,4.5f);
                Destroy(gameObject);
                break;
            case 4:
                Debug.Log("4");
                Debug.Log("Unlucky");
                //codigo de animacion
                //Play.Animation("Agradecimiento");
                //Destroy(gameObject,4.5f);
                Destroy(gameObject);
                break;
            case 0:
                Debug.Log("NANI");
                //codigo de animacion
                //Play.Animation("Agradecimiento");
                //Destroy(gameObject,4.5f);
                Destroy(gameObject);
                break;



        }
    }
}
