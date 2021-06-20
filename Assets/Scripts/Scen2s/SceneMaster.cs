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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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



}
