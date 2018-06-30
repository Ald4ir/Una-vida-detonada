using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorStamina : MonoBehaviour {
    public GameObject seguir;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        float posX = seguir.transform.position.x ;
        float posY = seguir.transform.position.y ;
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
