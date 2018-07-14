using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class controlStamina : MonoBehaviour {
    private controlesJugador estado;
    public GameObject segStamina;
    private float limitesStamina;
    private static int bajandoStamina = 15, subiendoStamina = 8;
	// Use this for initialization
	void Start () {
        estado = GetComponentInParent<controlesJugador>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (estado.corriendo)
        {
            estado.stamina -= (Time.deltaTime * bajandoStamina);

            limitesStamina = Mathf.Clamp(
                segStamina.transform.localScale.x - ((Time.deltaTime * bajandoStamina) / 100),
                0,
                1
                );
            segStamina.transform.localScale = new Vector3(
                limitesStamina,
                segStamina.transform.localScale.y,
                segStamina.transform.localScale.z
                );
        }
        else
        {
            estado.stamina += (Time.deltaTime * subiendoStamina);
            limitesStamina = Mathf.Clamp(
                segStamina.transform.localScale.x + ((Time.deltaTime * subiendoStamina) / 100),
                0,
                1
                );
            segStamina.transform.localScale = new Vector3(
                limitesStamina,
                segStamina.transform.localScale.y,
                segStamina.transform.localScale.z
                );
        }
        if(estado.stamina <= 25 && estado.pisando && estado.corriendo)
        {
            estado.reducirVelocidad();
        }
        if(estado.stamina <= 2 && estado.pisando)
        {
            estado.cambiarEstado(estado.corriendo);
        }
        estado.stamina = Mathf.Clamp(estado.stamina, 1, 100);
	}
}
