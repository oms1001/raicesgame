using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LugarMapa : MonoBehaviour, IDropHandler
{

    [SerializeField] private GameObject mapa;

    public int numero_de_celda = 0;
    public int numero_de_raices = 1;
    public string contenido_celda = "Vacio";
    public List<GameObject> raices_posibles;
    public int numero_de_raiz = 0;
    public int arriba_izquierda;
    public int arriba_centro;
    public int arriba_derecha;
    public int izquierda;
    public int derecha;
    public int abajo_izquierda;
    public int abajo_centro;
    public int abajo_derecha;
    // private bool primera_ficha = true;
    // public Vector2 initial_position;

    public List<Sprite> Sprites = new List<Sprite>(); //List of Sprites added from the Editor to be created as GameObjects at runtime
    public GameObject ParentPanel; //Parent Panel you want the new Images to be children of
    public Canvas canvas_mapa;
    // Use this for initialization

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
            abajo_derecha = numero_de_celda + 11;
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


                        // Comprobar celdas cercanas

                        if (contenido_celda.Contains("entrada_arriba_salida_abajo"))
                        {
                            numero_de_raiz = 0;
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
                                else
                                {
                                    celda_rechazada(eventData);
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




                        // Fin de comprobación de celdas

                        // Comprobar celdas cercanas _ Pieza con entrada arriba salida derecha

                        if (contenido_celda.Contains("entrada_arriba_salida_derecha"))
                        {
                            numero_de_raiz = 1;
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == arriba_centro)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_abajo"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }

                        }
                        // Inicio comprobación
                        if (contenido_celda.Contains("entrada_arriba_salida_abajo_salida_izquierda_salida_derecha"))
                        {
                            numero_de_raiz = 2;
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == arriba_centro)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_abajo"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }
                            else if (ob.GetComponent<LugarMapa>().numero_de_celda == derecha)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_derecha"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }
                            else if (ob.GetComponent<LugarMapa>().numero_de_celda == izquierda)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_salida"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }

                        }
                        // Fin comprobación
                        // Inicio comprobación
                        if (contenido_celda.Contains("entrada_arriba_salida_abajo_salida_derecha"))
                        {
                            numero_de_raiz = 3;
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == arriba_centro)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_abajo"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }

                        }
                        // Fin comprobación
                        // Inicio comprobación
                        if (contenido_celda.Contains("entrada_arriba_salida_derecha"))
                        {
                            numero_de_raiz = 4;
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == arriba_centro)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_abajo"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }

                        }
                        // Fin comprobación
                        // Inicio comprobación
                        if (contenido_celda.Contains("entrada_derecha_salida_abajo"))
                        {
                            numero_de_raiz = 5;
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == derecha)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_derecha"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }

                        }
                        // Fin comprobación
                        // Inicio comprobación
                        if (contenido_celda.Contains("entrada_derecha_salida_abajo"))
                        {
                            numero_de_raiz = 6;
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == derecha)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_derecha"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }

                        }
                        // Fin comprobación
                        // Inicio comprobación
                        if (contenido_celda.Contains("entrada_izquierda_salida_abajo"))
                        {
                            numero_de_raiz = 6;
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == derecha)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_derecha"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }
                            if (ob.GetComponent<LugarMapa>().numero_de_celda == izquierda)
                            {
                                var tipo_celda = ob.GetComponent<LugarMapa>().contenido_celda;
                                ob.GetComponent<Image>().color = Color.red;
                                if (tipo_celda.Contains("salida_izquierda") || tipo_celda.Contains("salida_derecha"))
                                {
                                    celda_aprobada();
                                }
                                else
                                {
                                    celda_rechazada(eventData);
                                }
                            }

                        }
                        // Fin comprobación

                    }


                }
            }
        }

        // var raiz_ultima = eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz;
    }
    public void celda_rechazada(PointerEventData eventData) {
            Debug.Log("Celda Rechazada");
            GameObject RespawnCelda = Instantiate(raices_posibles[numero_de_raiz], new Vector3(150, 150, 0), Quaternion.identity) as GameObject;
            RespawnCelda.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            RespawnCelda.GetComponent<DragAndDrop>().canvas = canvas_mapa;
            //RespawnCelda.GetComponent<DragAndDrop>().canvasGroup = canvas_mapa;
            contenido_celda = "Vacio";
            //contenido_celda = eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, 150, 0);
            Debug.Log(contenido_celda);      
    }

    public void celda_aprobada()
    {
        GameObject RespawnCelda = Instantiate(raices_posibles[Random.Range(0, raices_posibles.Count - 1)], new Vector3(150, 150, 0), Quaternion.identity) as GameObject;
        RespawnCelda.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        RespawnCelda.GetComponent<DragAndDrop>().canvas = canvas_mapa;
        Debug.Log("celda_aprobada");
        numero_de_raices++;
        Debug.Log(numero_de_raices);
    }

}

