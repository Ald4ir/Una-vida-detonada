using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
public class InventarioOIPH : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Text cantidad;
    public Image sprite;
    public Button boton;
    public int id;
    
    public Manager manager;
    
    public static InventarioOIPH arrastrando;

    public void OnBeginDrag(PointerEventData eventData)
    {
        arrastrando = this;
       PlaceHolder.current.sprite.sprite = sprite.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
       PlaceHolder.current.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        arrastrando = null;

       PlaceHolder.current.transform.position = new Vector3(10000, 1000, 100);
    }

    public void OnDrop(PointerEventData data)
    {
        if (arrastrando == null)
            return;
        if (arrastrando == this)
            return;

       manager.IntercambiarPuestos(id, arrastrando.id);
    }
}