using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayControlador : MonoBehaviour
{
    public string escenaVictoria;
    public string escenaDerrota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Perdiste()
    {
        Debug.Log("Ir a escena de derrota");
        //SceneManager.LoadScene(escenaDerrota);
        

    }
    public void Ganaste()
    {
        Debug.Log("Cargar siguiente nivel");
        //SceneManager.LoadScene(escenaVictoria);
    }
}
