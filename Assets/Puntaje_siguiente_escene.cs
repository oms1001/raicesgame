using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Puntaje_siguiente_escene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var global_state = GameObject.FindGameObjectWithTag("Canvas");
        int puntaje = global_state.GetComponent<GlobalState>().puntaje;
        var puntaje_ui = GameObject.Find("Puntaje");
        puntaje_ui.GetComponent<TextMeshProUGUI>().text = puntaje.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
