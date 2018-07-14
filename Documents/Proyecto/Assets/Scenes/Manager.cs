using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    [System.Serializable]
    public struct ObjetoInventarioId
    {
        public int id;
        public int cantidad;

        public ObjetoInventarioId(int id, int cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;
        }
    }

    public BD baseDatos;
    public List<ObjetoInventarioId> inventario;

    public void AgregarAlgoAlInventario(int id, int cantidad)
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].id == id)
            {
                inventario[i] = new ObjetoInventarioId(inventario[i].id, inventario[i].cantidad + cantidad);
                ActualizarInventario();
                return;
            }
        }
        inventario.Add(new ObjetoInventarioId(id, cantidad));
        ActualizarInventario();
    }
    public void EliminarAlgoDeInventario(int id, int cantidad)
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].id == id)
            {
                inventario[i] = new ObjetoInventarioId(inventario[i].id, inventario[i].cantidad - cantidad);
                if (inventario[i].cantidad <= 0)
                    inventario.Remove(inventario[i]);
                ActualizarInventario();
                return;
            }
        }
        Debug.LogError("No existe el objeto a eliminar");
    }
    
    public void IntercambiarPuestos(int i1 , int i2)
    {
        ObjetoInventarioId i = inventario[i1];
        inventario[i1] = inventario[i2];
        inventario[i2] = i;
        ActualizarInventario();
    }

    public void Start()
    {
        ActualizarInventario();
    }
    
    public InventarioOIPH prefab;
    public Transform inventarioUI;
    List<InventarioOIPH> pool = new List<InventarioOIPH>();

    public void ActualizarInventario()
    {
        print("Inventario Actualizado");
        for (int i = 0; i < pool.Count; i++)
        {
            if (i < inventario.Count)
            {
                ObjetoInventarioId o = inventario[i];
                pool[i].sprite.sprite = baseDatos.baseDatos[o.id].sprite;
                pool[i].cantidad.text = o.cantidad.ToString();
                pool[i].id = i;

                pool[i].boton.onClick.RemoveAllListeners();
                pool[i].boton.onClick.AddListener(() => gameObject.SendMessage(baseDatos.baseDatos[o.id].funcion, SendMessageOptions.DontRequireReceiver));

                pool[i].gameObject.SetActive(true);
            }
            else
            {
                pool[i].gameObject.SetActive(false);
            }
        }
        if (inventario.Count > pool.Count)
        {
            for (int i = pool.Count; i < inventario.Count; i++)
            {
                InventarioOIPH oi = Instantiate(prefab, inventarioUI);
                pool.Add(oi);

                oi.transform.position = Vector3.zero; // 
                oi.transform.localScale = Vector3.one;

                ObjetoInventarioId o = inventario[i];
                pool[i].sprite.sprite = baseDatos.baseDatos[o.id].sprite;
                pool[i].cantidad.text = o.cantidad.ToString();
                pool[i].id = i;
                pool[i].manager = this;

                pool[i].boton.onClick.RemoveAllListeners();
                pool[i].boton.onClick.AddListener(() => gameObject.SendMessage(baseDatos.baseDatos[o.id].funcion, SendMessageOptions.DontRequireReceiver));

                pool[i].gameObject.SetActive(true);
            }
        }
    }
    
    public void Pocion()
    {
        print("Pocion usada");
        EliminarAlgoDeInventario(0, 1);
    }
    public void pistol()
    {
        print("Pistola tirada");
        EliminarAlgoDeInventario(1, 1);
    }
}