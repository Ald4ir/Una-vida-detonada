using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revisarPiso : MonoBehaviour {

    private controlesJugador jugador;

	// Use this for initialization
	void Start () {
        jugador = GetComponentInParent<controlesJugador>();

	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "suelo")
        {
            jugador.pisando = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "suelo")
        {
            jugador.pisando = false;
        }
    }
}
