using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public bool selected = false;
    SpriteRenderer render;
    GameManager gm;
    int actualState = 0;
    int nextState = 0;
    public int direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject);
        gm = GameObject.Find("Puzzle").GetComponent<GameManager>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction = 1;
                nextState=actualState|direction;
                render.sprite = gm.sprites[nextState];
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction=2;
                nextState=actualState|direction;
                render.sprite = gm.sprites[nextState];
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = 4;
                nextState=actualState|direction;
                render.sprite = gm.sprites[nextState];
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction = 8;
                nextState=actualState|direction;
                render.sprite = gm.sprites[nextState];
            }

        }
    }

    void OnMouseDown()
    {
        GameObject.Find("Selector").transform.position = transform.position;
        gm.selectedPiece = gameObject;
        gm.seleccionarPieza();
        //Debug.Log("OnMouseDown");
        //if (nextState == sprites.Length)
        //    nextState = 0;
        //render.sprite = sprites[nextState];
        //nextState++;
    }

    public void updateState()
    {
        actualState = nextState;
        this.direction = 0;
    }

    public void initSprite(int newState)
    {
        Start();
        render.sprite = gm.sprites[newState];
        actualState = newState;
    }

    public void restart()
    {
        Start();
        selected = false;
        render.sprite = gm.sprites[actualState];
    }
}
