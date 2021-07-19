using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    
 
    public bool pausado = false;
    public GameObject menuDePausa;
    public static int continueValue = 1;
    public UIManaguer uiManaguer;


    // Start is called before the first frame update
    void Start()
    {
        uiManaguer = GameObject.Find("UI Managuer").GetComponent<UIManaguer>();
        //QualitySettings.SetQualityLevel("Low", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Resumir();
            }
            else
            {
                Pausar();
            }
        }

    }



    public void ToGameplay()
    {
        
        continueValue = 1;
        SceneManager.LoadScene(continueValue);
        
        
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        continueValue = 1;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ToPerdisteScene()
    {
        
        SceneManager.LoadScene("Perdiste Scene");
        Debug.Log("Perdiste Papuh");
        Cursor.lockState = CursorLockMode.None;


    }
    public void ToContinueScene()
    {
        SceneManager.LoadScene(continueValue);
        Debug.Log("Continue");
    }
    public void ToGanasteScene()
    {
        
        continueValue++;
        if(continueValue==4)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        SceneManager.LoadScene(continueValue);
        //Para que funcione, en el index de build debe ir as�
        // nivel 0 = 1;
        // Nivel 1 = 2;
        // Nivel 2 = 3;
        //Ganaste = 4;

    }
    public void ToCreditosScene()
    {
        SceneManager.LoadScene("CreditosScene");
    }
    public void EndGame()
    {
        Application.Quit();
    }

    void Pausar()
    {
        Cursor.lockState = CursorLockMode.None;
        menuDePausa.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
        uiManaguer.calidadSlider.value = PlayerPrefs.GetInt("Calidad");
    }

    public void Resumir()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menuDePausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
        uiManaguer.CambiarValorCalidad();
    }
    
    public void Escribir()
    {
        Debug.Log("Presionado");
    }
}
       
