using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaSanMarquina : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad;
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {    
        transform.position = Vector3.MoveTowards (transform.position, objetivo.transform.position, velocidad * Time.deltaTime);
        transform.up = objetivo.position - transform.position;    
    }

    /*private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag ("Obstaculo")){
            Debug.Log ("Pls");
            Destroy(gameObject);
        }
        

    }*/
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag ("Obstaculo")){
            Debug.Log ("Pls");
            Destroy(gameObject);
            }
    }
    


}
