using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EphimeralScript : MonoBehaviour
{
    public float destruirEnSegundos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Autodestrucci�n()
    {
        yield return new WaitForSeconds(destruirEnSegundos);
    }
}
