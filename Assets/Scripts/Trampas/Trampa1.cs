using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa1 : MonoBehaviour
{
    public float velocidad;
    void Update()
    {
        transform.Rotate(new Vector3(-90f, 0f, 0f) * velocidad * Time.deltaTime);
    }
    public void MovimientoTronco()
    {
        Debug.Log("Luana");
        //StartCoroutine(MoverTronco());
        //transform.Rotate(new Vector3(90f, 0f, 0f) * Time.deltaTime);
    }

    IEnumerator MoverTronco()
    {
        float rotacion = 90.0f;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotacion, transform.eulerAngles.z) * Time.deltaTime;
        yield return new WaitForSeconds(3.0f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, -rotacion, transform.eulerAngles.z) * Time.deltaTime;
    }
}
