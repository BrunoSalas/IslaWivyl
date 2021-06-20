using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldeanoDetector : MonoBehaviour
{
    public ModeloJugador ml;
    // Start is called before the first frame update
    void Start()
    {
        ml = GetComponentInParent<ModeloJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Aldeano"))
        {
            ml.UiManaguer.ActivarTeclaInteractuar();
            Debug.Log("POGGG");
            ml.aldeanoEnRango = true;
            ml.aldeanoInteractuable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Aldeano"))
        {
            Debug.Log("POGGG");
            ml.aldeanoEnRango = false;
            ml.aldeanoInteractuable = null;
            ml.UiManaguer.DesactivarTeclaInteractuar();
        }
    }
}
