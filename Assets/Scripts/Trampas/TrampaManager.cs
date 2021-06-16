using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaManager : MonoBehaviour
{
    
    int numeroTrampa = 0; //Modificar la variable desde el player por colision con cada trampa
    void Start()
    {
        
    }

    
    void Update()
    {
        UsoTrampa();
    }
    
    void UsoTrampa()
    {
        switch (numeroTrampa)
        {
            case 1:
                Debug.Log("Instanciar cocos que hagan daño al chocar con el collider del arbol");
                break;

            case 2:
                Debug.Log("Buscar la manera de pasar el daño ya puesto por collision en player a aca");
                break;

            case 3:
                Debug.Log("Al pasar por collider con tag de t3 hacer todo lo acordado");
                break;

        }
    }

    
}
