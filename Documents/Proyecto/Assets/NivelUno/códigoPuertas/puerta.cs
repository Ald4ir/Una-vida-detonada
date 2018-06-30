using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour {

    private bool tocando;
    public GameObject circulo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Función sin uso
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tocando = true;
        circulo.transform.position = new Vector3(transform.position.x - .075f, transform.position.y, circulo.transform.position.z);
        circulo.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tocando = false;
        circulo.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tocando)
        {
            print("Has entrado");
        }
    }
}
