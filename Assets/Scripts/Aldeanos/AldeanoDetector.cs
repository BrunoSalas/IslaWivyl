using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldeanoDetector : MonoBehaviour
{
    public ModeloJugador ml;
    public GameObject player;
    public GameObject Hand;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        ml = player.GetComponent<ModeloJugador>();

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z+1.5f);
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            ml.UiManaguer.ActivarTeclaInteractuar();
            Debug.Log("POGGG");
            ml.aldeanoEnRango = true;
            ml.aldeanoInteractuable = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("POGGG");
            ml.aldeanoEnRango = false;
            ml.aldeanoInteractuable = null;
            ml.UiManaguer.DesactivarTeclaInteractuar();
        }
    }
}
