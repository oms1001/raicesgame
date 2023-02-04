using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LugarMapa : MonoBehaviour, IDropHandler
{


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Objeto droppeado");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log(eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz);
        }
    }


}
