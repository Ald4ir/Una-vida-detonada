using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnaPared : MonoBehaviour {
    public GameObject cambio, reja;
    public Collider2D[] objetos = new Collider2D[18];
    public Collider2D columnaIzd, columnaDcha;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cambio.transform.position = new Vector3(
            cambio.transform.position.x,
            cambio.transform.position.y,
            2
            );
        reja.transform.position = new Vector3(
            reja.transform.position.x,
            reja.transform.position.y,
            1
            );
        ;
        for(int i = 0; i < 18; i++)
        {
            objetos[i].enabled = false;
        }
        columnaIzd.isTrigger = false;
        columnaDcha.enabled = false;
    }
}
