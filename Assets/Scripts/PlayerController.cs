using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool selected = false;
    SpriteRenderer render;
    GameManager gm;
    int actualState = 0;
    int nextState = 0;
    public int direction = 0;
    public bool jugador1;

    void Awake()
    {
        //Debug.Log(gameObject);
        gm = GameObject.Find("Puzzle").GetComponent<GameManager>();
        render = GetComponent<SpriteRenderer>();
    }

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
        if (jugador1 == gm.turnoJugador1)
        {
            GameObject.Find("Selector").transform.position = transform.position;
            gm.selectedPiece = gameObject;
            gm.seleccionarPieza();

        }
    }

    public void updateState()
    {
        actualState = nextState;
        this.direction = 0;
    }

    public void initSprite(int newState)
    {
        render.sprite = gm.sprites[newState];
        actualState = newState;
    }

    public void restart()
    {
        selected = false;
        render.sprite = gm.sprites[actualState];
    }
}
