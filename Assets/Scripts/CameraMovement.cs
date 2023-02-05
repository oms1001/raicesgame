using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    bool click = false;
    Vector3 posInicial;
    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            //Debug.Log("MouseDerecho");
            if (!click)
            {
                posInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 diff = newPos - posInicial;
            if (Math.Abs(transform.position.x - diff.x) > 7)
                diff.x = 0;
            if (Math.Abs(transform.position.y - diff.y) > 7)
                diff.y = 0;

            transform.position = transform.position - diff;

            
        }
        click = Input.GetMouseButton(1);

    }


}
