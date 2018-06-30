using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirPersonaje : MonoBehaviour {

    public GameObject seguir;
    public Vector2 posMin, posMax;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = seguir.transform.position.x;
        float posY = seguir.transform.position.y;

        transform.position = new Vector3(
            Mathf.Clamp(posX, posMin.x, posMax.x),
            Mathf.Clamp(posY, posMin.y, posMax.y), 
            transform.position.z);
    }
}
