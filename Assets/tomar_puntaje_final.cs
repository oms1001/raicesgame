using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tomar_puntaje_final : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var globalState = GameObject.Find("Canvas");
        int puntaje_final = globalState.GetComponent<GlobalState>().puntaje;
        GetComponent<TextMeshProUGUI>().text = puntaje_final.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        var globalState = GameObject.Find("Canvas");
        int puntaje_final = globalState.GetComponent<GlobalState>().puntaje;
        puntaje_final = puntaje_final * 10;
        GetComponent<TextMeshProUGUI>().text = puntaje_final.ToString();
    }
}
