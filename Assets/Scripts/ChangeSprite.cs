using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    SpriteRenderer render;
    public Sprite[] sprites;
    int next = 0;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //Debug.Log("OnMouseDown");
        if (next == sprites.Length)
            next = 0;
        render.sprite = sprites[next];
        next++;
    }
}
