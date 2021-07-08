using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoColliderScript : MonoBehaviour
{
    public GameObject tutoManaguer;
    void Start()
    {
        tutoManaguer = GameObject.Find("Tutorial Managuer");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            tutoManaguer.GetComponent<TutorialScript>().tutoStatus++;
            tutoManaguer.GetComponent<TutorialScript>().TutorialStatus();

            Destroy(gameObject);
        }
    }

}
