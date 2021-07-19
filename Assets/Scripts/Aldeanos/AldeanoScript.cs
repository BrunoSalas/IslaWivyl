using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldeanoScript : MonoBehaviour
{
    public float probabilidadesPatoCura;
    public float probabilidadesPatoVeloz;
    public float probabilidadesPatoMuro;
    public float probabilidadesNada;

    public GameObject patoCuraUp;
    public GameObject patoVelozUp;
    public GameObject patoMuroUp;

    int rngCalculator;
    public bool recogido;
    public Animator anim;
    void Start()
    {
        recogido = false;
        anim = GetComponent<Animator>();
    }
    void Update()
    {

    }
	void Morir()
    {
        
        Debug.Log ("Gaa");
    }

    public void PatoRng(PowerDucks ducks, ModeloJugador model)
    {
        if (!recogido)
        {
            Debug.Log("RNG");
            model.aldeanosAgarrados++;

            rngCalculator = Random.Range(1, 4);
            Debug.Log(rngCalculator);
            switch (rngCalculator)
            {
                case 1:
                    Debug.Log("1");
                    //ducks.patos1++;
                    //ducks.ActualizarPatos();
                    //Instantiate(patoCuraUp);
                    StartCoroutine(RecogerAldeano());
                    break;
                case 2:
                    Debug.Log("2");
                    //ducks.patos2++;
                    //ducks.ActualizarPatos();
                    //Instantiate(patoVelozUp);
                    StartCoroutine(RecogerAldeano());
                    break;
                case 3:
                    Debug.Log("3");
                    ducks.patos3++;
                    ducks.ActualizarPatos();
                    Instantiate(patoVelozUp);
                    StartCoroutine(RecogerAldeano());
                    break;
                case 4:
                    Debug.Log("4");
                    Debug.Log("Unlucky");
                    StartCoroutine(RecogerAldeano());
                    break;
                case 0:
                    Debug.Log("NANI");
                    StartCoroutine(RecogerAldeano());
                    break;



            }
        }
        recogido = true;
    }
     IEnumerator RecogerAldeano()
    {
        anim.SetBool ("Ga",true);
        yield return new WaitForSeconds (3f);

        Destroy(gameObject);
    }
}
