using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.EventSystems;



public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler

{
    [SerializeField] private Canvas canvas;
    public string tipoDeRaiz;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()

    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)

    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }



    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }



    public void OnEndDrag(PointerEventData eventData)

    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }
}