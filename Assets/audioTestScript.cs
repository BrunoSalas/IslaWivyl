using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioTestScript : MonoBehaviour
{
    public AudioSource bonk;
    // Start is called before the first frame update
    void Start()
    {
        bonk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            bonk.Play();
            Debug.Log("Sonando");
        }
    }
}
