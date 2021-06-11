using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    float rotacionEnX;
    float SensitividadMouse = 90f;
    public Transform jugador;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * SensitividadMouse;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * SensitividadMouse;

        rotacionEnX -= mouseY;
        rotacionEnX = Mathf.Clamp(rotacionEnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotacionEnX, 0f, 0f);

        jugador.Rotate(Vector3.up * mouseX);

    }
}
