using System;
using UnityEngine;
using UnityEngine.UI;

public class PlaceHolder : MonoBehaviour
{ 
    public Image sprite;
    public static PlaceHolder current;
    void Start () {
        if (current != null)
            Destroy(gameObject);
        sprite = GetComponent<Image>();
        current = this;
	}
}