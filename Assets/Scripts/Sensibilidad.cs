using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensibilidad : MonoBehaviour
{
    public Slider sensibilidadRatonSlider;
    public bool inicializacion = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            sensibilidadRatonSlider.value = PlayerPrefs.GetFloat("Sensitivity");
            Debug.Log("Loaded a sensitivity of " + sensibilidadRatonSlider.value);
        }
        inicializacion = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SensibilidadRaton(float val)
    {
        if (!inicializacion) return;
        if (!Application.isPlaying) return;

        PlayerPrefs.SetFloat("Sensitivity", val);
        Debug.Log(" Set sensitivity to " + val);

    }
}
