using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguidorFondo1 : MonoBehaviour {
    public GameObject seguir;
    private float seguidor = 1.7f;
    void Start()
    {

    }

    void Update()
    {
        float posX = seguir.transform.position.x / seguidor + 40;
        posX = Mathf.Clamp(posX, 5, 200);
        transform.position = new Vector3(posX,transform.position.y, transform.position.z);
    }
}
