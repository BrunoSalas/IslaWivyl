using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManaguer : MonoBehaviour
{
    public Slider barraDeSalud;
    public ModeloJugador mJ;
    public GameObject teclaInteractuar;
    public PowerDucks pD;
    public Text pato1Text;
    public Text pato2Text;
    public Text pato3Text;
    public GameObject EFFCura;
    public GameObject EFFVelocidad;
    public GameObject EFFDano;
    // Start is called before the first frame update
    void Start()
    {
        //EFFCura = GameObject.Find("Cura EFF");
        //EFFVelocidad = GameObject.Find("Velocidad EFF");
        PrepararBarraDeVida();
        DesactivarTeclaInteractuar();
        ActualizarPatos();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarBarraDeVida();
    }

    public void ActivarTeclaInteractuar()
    {
        teclaInteractuar.SetActive(true);
    }
    public void DesactivarTeclaInteractuar()
    {
        teclaInteractuar.SetActive(false);
    }

    public void ActualizarPatos()
    {
        pato1Text.text = ("x" + pD.patos1);
        pato2Text.text = ("x" + pD.patos2);
        pato3Text.text = ("x" + pD.patos3);
    }
    public void PrepararBarraDeVida()
    {
        barraDeSalud.maxValue = mJ.maximaVida;
        mJ.vida = mJ.maximaVida;
    }

    public void ActualizarBarraDeVida()
    {
        barraDeSalud.value = mJ.vida;
    }
}
