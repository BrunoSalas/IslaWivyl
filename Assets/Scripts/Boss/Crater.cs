using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crater : MonoBehaviour
{
    private float tiempoDestruccion;
    private bool activarDestruccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destruir();
    }

    public void Destruir()
    {
      tiempoDestruccion = tiempoDestruccion + 1 * Time.deltaTime;
       if (tiempoDestruccion >= 4f)
       {
        Destroy(gameObject);
       }
    }
}
