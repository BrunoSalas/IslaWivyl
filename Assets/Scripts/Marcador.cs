using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcador : MonoBehaviour
{
    public float tiempo;
    private void Update()
    {
        tiempo = tiempo + 1 * Time.deltaTime;

        if (tiempo >= 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
