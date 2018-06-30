using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa:MonoBehaviour
{
    bool Active;
    Canvas canvas;
    // Use this for initialization
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Active = !Active;
            canvas.enabled = Active;
            Time.timeScale = (Active) ? 0 : 1f;
        }
    }
}
