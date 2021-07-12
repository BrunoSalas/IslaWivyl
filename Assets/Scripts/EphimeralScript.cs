using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EphimeralScript : MonoBehaviour
{
    public float destruirEnSegundos;
    void Start()
    {
        StartCoroutine(Autodestrucción());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Autodestrucción()
    {
        yield return new WaitForSeconds(destruirEnSegundos);
        Destroy(gameObject);
    }
}
