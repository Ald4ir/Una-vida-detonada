using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorContenedor : MonoBehaviour {
    public GameObject seguir;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float posX = seguir.transform.position.x - 7;
        float posY = seguir.transform.position.y + 4;
        transform.position = new Vector3(posX,posY,transform.position.z);
    }
}
