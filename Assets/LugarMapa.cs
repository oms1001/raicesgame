using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LugarMapa : MonoBehaviour, IDropHandler
{

    [SerializeField] private GameObject mapa;

    public int numero_de_celda = 0;
    public string contenido_celda = "Vacío";
    public int arriba_izquierda;
    public int arriba_centro;
    public int arriba_derecha;
    public int izquierda;
    public int derecha;
    public int abajo_izquierda;
    public int abajo_centro;
    public int abajo_derecha;



    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("Objeto droppeado");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            // Debug.Log(eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz);
            arriba_izquierda = numero_de_celda - 11;
            arriba_centro = numero_de_celda - 10;
            arriba_derecha = numero_de_celda - 9;
            izquierda = numero_de_celda - 1;
            derecha = numero_de_celda + 1;
            abajo_izquierda = numero_de_celda + 9;
            abajo_centro = numero_de_celda + 10;
            abajo_derecha = numero_de_celda + 12;

            abajo_derecha = numero_de_celda + 1;
            var celda_mapas = mapa.GetComponentsInChildren<Transform>(true);


            contenido_celda = eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz;

            foreach (var ob in celda_mapas)

            {
                if (ob != transform)
                {
                    // Debug.Log(ob.name);
                    if (ob.tag == "Holder")
                    {
                        //if ()
                        if (contenido_celda.Contains("entrada_arriba_salida_abajo")) { 
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == arriba_derecha)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.blue;
                        }
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == arriba_centro)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.red;
                            if (tipo_celda.Contains("salida_abajo"))
                            {
                                Debug.Log("Celda aprobada");
                            }
                            else {
                                Debug.Log("Celda rechazada");
                            }
                        }
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == arriba_izquierda)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.blue;
                        }
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == izquierda)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.green;
                        }
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == derecha)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.green;
                        }
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == abajo_derecha)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.blue;
                        }
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == abajo_centro)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.red;
                        }
                        if (ob.GetComponent<LugarMapa>().numero_de_celda == abajo_izquierda)
                        {
                            var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                            ob.GetComponent<Image>().color = Color.blue;
                        }

                    }
                    }
                }
            }

            // var raiz_ultima = eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz;
        }
        
    }

}
