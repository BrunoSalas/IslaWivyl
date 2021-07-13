using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    float rotacionEnX;
    public float SensitividadMouseY = 50f;
    public float SensitividadMouseX = 50f;
    public Transform jugador;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        transform.rotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {

        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * (SensitividadMouseX *1.5f);
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * SensitividadMouseY;

        rotacionEnX -= mouseY;
        rotacionEnX = Mathf.Clamp(rotacionEnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotacionEnX, 0f, 0f);

        jugador.Rotate(Vector3.up * mouseX);
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            SensitividadMouseX = PlayerPrefs.GetFloat("Sensitivity");
            SensitividadMouseY = PlayerPrefs.GetFloat("Sensitivity");
        }
    }
}
