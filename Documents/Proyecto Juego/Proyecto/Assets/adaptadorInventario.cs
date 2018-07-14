using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adaptadorInventario : MonoBehaviour {
    RectTransform ubicacion;
    public GameObject cuadricula;
    private float top, bottom, right, left, width, heigh;
	// Use this for initialization
	void Start () {
        ubicacion = GetComponent<RectTransform>();
        width =  Screen.width;
        heigh = Screen.height;
        this.cambio();
    }
	
	// Update is called once per frame
	void Update () {
		if(Screen.width != width || Screen.height != heigh)
        {
            cambio();
        }
	}

    private void cambio()
    {
        float w = Screen.width;
        float h = Screen.height;
        left = w * 0.390625f;
        right = -left;
        top = -(h * 0.3148148148f);
        bottom = h * 0.29629629629f;
        ubicacion.offsetMin = new Vector2(left, bottom);//left,bottom
        ubicacion.offsetMax = new Vector2(right, top);//-right, -top
        cuadricula.transform.localScale = new Vector3(w / 1920, h / 1080, cuadricula.transform.localScale.z);
    }
}
