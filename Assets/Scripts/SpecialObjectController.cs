using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjectController : MonoBehaviour
{
    public int type;
    public Sprite planta;
    public Sprite agua;
    public Sprite sequia;

    void Start()
    {
        if (type==1)
        {
            tag = "powerUp";
            GetComponent<SpriteRenderer>().sprite = planta;
        }
        else if (type==2)
        {
            tag = "powerUp2";
            GetComponent<SpriteRenderer>().sprite = agua;
        } else if (type == 3)
        {
            tag = "trap";
            GetComponent<SpriteRenderer>().sprite = sequia;
        }
    }

}
