using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float distancia;
    RaycastHit visto;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Interactuar()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distancia, Color.red);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(visto.collider.tag == "Aldeano")
            {
                Debug.Log("Ya veremos que pasa");
            }
        }
    }
}
