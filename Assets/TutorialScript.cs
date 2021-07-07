using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public static bool tutorialActivado;
    public int tutoStatus;
    public GameObject tutoCanvas;
    public GameObject tutoTexto1;
    public GameObject tutoTexto2;
    public GameObject tutoTexto3;

    // Start is called before the first frame update
    void Start()
    {
        TutorialSetUp();

    }
    public void TutorialSetUp()
    {
        if (tutorialActivado)
        {
            tutoStatus = 1;
            TutorialStatus();


        }
        else
        {
            tutoCanvas.SetActive(false);
        }
    }
    public void TutorialStatus()
    {
        switch (tutoStatus)
        {
            case 1:
                tutoCanvas.SetActive(true);
                tutoTexto1.SetActive(true);
                tutoTexto2.SetActive(false);
                tutoTexto3.SetActive(false);
                break;
            case 2:

                break;
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
