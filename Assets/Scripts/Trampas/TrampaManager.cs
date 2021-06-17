using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaManager : MonoBehaviour
{
    
    public int numeroTrampa = 0; //Modificar la variable desde el player por colision con cada trampa
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
                Debug.Log("trampa 1 activada");
                numeroTrampa = 0;
                break;

            case 2:
                Debug.Log("trampa 2 activada");
                numeroTrampa = 0;
                break;

            case 3:
                Debug.Log("trampa 3 activada");
                numeroTrampa = 0;
                break;

        }
    }

    
}
