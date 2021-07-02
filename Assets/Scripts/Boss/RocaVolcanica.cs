using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaVolcanica : MonoBehaviour
{
    public GameObject grieta;
    public bool aparecerGrieta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Grieta();
    }

    public void Grieta()
    {
        if (aparecerGrieta == true)
        {
            Vector3 Grieta = new Vector3(transform.position.x, transform.position.y - 0.4f,transform.position.z);
            
            Instantiate(grieta, Grieta, transform.rotation);

            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag( "Piso"))
        {
            aparecerGrieta = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Limites"))
        {
            Destroy(gameObject);
        }
    }
}
