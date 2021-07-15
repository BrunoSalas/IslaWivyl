using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstatuaHazard : MonoBehaviour
{
    public GameObject antorcha;
    public float timer;
    public bool activar = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       ActivarEstatua();
    }

    public void ActivarEstatua ()
    {
        timer += Time.deltaTime;

        if(timer >= 5){
            activar = true;
            if (timer >= 10){
                activar = false;
                timer = 0;
            }
        }


        if (activar == true){
            antorcha.SetActive(true);
           
        }
         if(activar == false){
                antorcha.SetActive(false);
            }
    }
}
