using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaCuevaPiedras : MonoBehaviour
{
    private ModeloJugador modeloJugador;
    public float da�o;
    public float reduccionVelocidad;
    public float velocidadGuardado;
    public int unaPiedra = 0;
    // Start is called before the first frame update
    void Start()
    {
        modeloJugador = GetComponent<ModeloJugador>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void TrampaSegundo()
    {
     modeloJugador.maximaVida = modeloJugador.maximaVida - da�o;//Herencia de modeloJugador

    }
}
