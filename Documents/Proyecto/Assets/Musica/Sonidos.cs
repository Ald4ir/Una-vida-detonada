using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour {
    public AudioClip Gun,Rifle;
    AudioSource Fuente;
	// Use this for initialization
	void Start () {
        Fuente = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Fuente.clip = Gun;
            Fuente.Play();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Fuente.clip = Rifle;
                Fuente.Play();
            }
        }
	}
}
