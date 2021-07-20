using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaSanMarquina : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad;
    public BossPoderes lanzar;
    public SphereCollider esferaCollider;
    

    public int i;
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag ("Obstaculo").GetComponent<Transform>();
        esferaCollider = GetComponent<SphereCollider>();
        
    }

   
    void Update()
    {    
      
            SanMarquinoActive(); 
        
        
    }

   
    /*private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag ("Piso")){
            Debug.Log ("Pls");
            Destroy(gameObject);
            }
    }*/
    
    
    public void SanMarquinoActive (){
        transform.position = Vector3.MoveTowards (transform.position, objetivo.transform.position, velocidad * Time.deltaTime);
        transform.up = objetivo.position - transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log ("TriggerPiso");
        if(other.gameObject.CompareTag ("Piso")){
            esferaCollider.isTrigger = false;
        }    
    }


}
