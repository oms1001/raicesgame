using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var raiz = GameObject.Find("Raíz");
        Debug.Log(raiz.GetComponent<DragAndDrop>().tipoDeRaiz);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
