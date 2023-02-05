using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GlobalState : MonoBehaviour
{
    public int puntaje = 0;
    public int cantidad_intentos = 0;
    public int max_intentos = 5;
    // Start is called before the first frame update
    void Start()
    {
        var raiz = GameObject.Find("Ra�z");
        //Debug.Log(raiz.GetComponent<DragAndDrop>().tipoDeRaiz);
        var Mapa = GameObject.Find("Canvas");
        var elementos = Mapa.GetComponentsInChildren<Transform>(true);
        int numero_celda = 1;
        foreach (var ob in elementos)

        {
         if (ob != transform) {
                if (ob.tag == "Holder")
                {
                    ob.GetComponent<LugarMapa>().numero_de_celda = numero_celda;
                    numero_celda++;

                }
                //Debug.Log(ob.GetComponent<LugarMapa>().numero_de_celda);
        }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
