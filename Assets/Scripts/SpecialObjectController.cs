using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjectController : MonoBehaviour
{
    public bool type;
    public Sprite bueno;
    public Sprite malo;

    void Start()
    {
        if (type)
        {
            tag = "powerUp";
            GetComponent<SpriteRenderer>().sprite = bueno;
        }
        else
        {
            tag = "trap";
            GetComponent<SpriteRenderer>().sprite = malo;
        }
    }

}
