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
    public string contenido_celda = "Vac�o";
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
                        if (contenido_celda.Contains("entrada_arriba_salida_abajo_salida_derecha"))
                        {
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

                    }


                }
            }
        }

        // var raiz_ultima = eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz;
    }
    public void celda_rechazada(PointerEventData eventData) {

            Debug.Log("Celda Rechazada");
            contenido_celda = eventData.pointerDrag.GetComponent<DragAndDrop>().tipoDeRaiz;
            Debug.Log(contenido_celda);
            Sprite currentSprite = Sprites[2];

            GameObject NewObj = new GameObject(); //Create the GameObject
            Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = currentSprite; //Set the Sprite of the Image Component on the new GameObject
            NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            NewObj.SetActive(true); //Activate the GameObject


    }

    public void celda_aprobada()
    {

        Debug.Log("celda_aprobada");
        numero_de_raices++;
        Debug.Log(numero_de_raices);
    }

}

