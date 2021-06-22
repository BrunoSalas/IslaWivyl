using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public string gameplayScene;
    public string mainMenuScene;
    public string perdisteScene;
    public string ganasteScene;
    public string creditosScene;
    public bool pausado = false;
    public GameObject menuDePausa;

    // Start is called before the first frame update
    void Start()
    {

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
        SceneManager.LoadScene(gameplayScene);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
    public void ToPerdisteScene()
    {
        SceneManager.LoadScene(perdisteScene);
    }
    public void ToGanasteScene()
    {
        SceneManager.LoadScene(ganasteScene);
    }
    public void ToCreditosScene()
    {
        SceneManager.LoadScene(creditosScene);
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
    }

    public void Resumir()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menuDePausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;


    }
}
       
