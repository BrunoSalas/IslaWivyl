using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManaguer : MonoBehaviour
{
    public Slider barraDeSalud;
    public ModeloJugador mJ;
    public GameObject teclaInteractuar;
    // Start is called before the first frame update
    void Start()
    {
        PrepararBarraDeVida();
        DesactivarTeclaInteractuar();
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
