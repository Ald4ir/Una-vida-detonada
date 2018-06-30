using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguidorInventario : MonoBehaviour {
    public GameObject mono;
    private float posX, posY;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        posX = mono.transform.position.x;
        posY = mono.transform.position.y + 4;
        transform.position = new Vector3(
            posX,
            posY,
            transform.position.z
            );
	}
    
}
