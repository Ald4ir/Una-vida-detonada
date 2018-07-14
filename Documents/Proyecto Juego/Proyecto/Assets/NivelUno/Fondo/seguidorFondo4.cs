using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguidorFondo4 : MonoBehaviour {
    public GameObject seguir;
    private float seguidor = 1.1f;
    void Start () {
		
	}
	
	void Update () {
        float posX = seguir.transform.position.x / seguidor;
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
