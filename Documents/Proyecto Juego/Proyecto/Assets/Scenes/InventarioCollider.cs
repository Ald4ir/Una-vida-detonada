using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioCollider : MonoBehaviour {
    Manager m;
    void Start(){
        m = GetComponent<Manager>();
    }
	// Update is called once per frame
	void OnTriggerEnter (Collider col){
        if (col.GetComponent<Recogible>() != null){
            Recogible i = col.GetComponent<Recogible>();
            m.AgregarAlgoAlInventario(i.id, i.cantidad);
            Destroy(col.gameObject);
        }		
	}
}