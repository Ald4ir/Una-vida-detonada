using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguidorFondo3 : MonoBehaviour {

    public GameObject seguir;
    private float seguidor = 1.3f;
    void Start()
    {

    }

    void Update()
    {
        float posX = seguir.transform.position.x / seguidor + 45;
        posX = Mathf.Clamp(posX, 20, 200);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
