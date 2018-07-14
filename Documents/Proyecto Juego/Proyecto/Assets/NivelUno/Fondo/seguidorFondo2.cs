using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguidorFondo2 : MonoBehaviour {
    public GameObject seguir;
    private float seguidor = 1.5f;
    void Start()
    {

    }

    void Update()
    {
        float posX = seguir.transform.position.x / seguidor + 20;
        posX = Mathf.Clamp(posX, 20, 200);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
