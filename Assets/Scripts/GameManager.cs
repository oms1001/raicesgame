using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public Sprite[] sprites;

    List<GameObject> piezas = new List<GameObject>();
    public GameObject selectedPiece;

    public int piezasRestantes;
    public bool turnoJugador1;

    //public Vector2[] objetosEspeciales;

    public GameObject specialObject;

    GameObject turno;
    GameObject puntaje;
    GameObject GO;
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        turno = GameObject.Find("Turno");
        puntaje = GameObject.Find("Puntaje");
        GO = GameObject.Find("GameOver");
        panel = GameObject.Find("Panel");
        GO.SetActive(false);
        piezas.Add(GameObject.Find("Jugador1"));
        piezas.Add(GameObject.Find("Jugador2"));

        //foreach (Vector2 pos in objetosEspeciales)
        //{
        //    GameObject newSpecialObject = Instantiate(specialObject, pos, specialObject.transform.rotation);
        //    float prob = Random.value;
        //    newSpecialObject.GetComponent<SpecialObjectController>().type = prob<0.3? 1: prob<0.6? 2: 3;
        //}

        for (int i = -16; i <= 16; i++)
        {
            for (int j = -9; j <= 9; j++)
            {
                if ((i+j)%2==0 && i != 0)
                {
                    Vector2 pos = new Vector2(i,j);
                    GameObject newSpecialObject = Instantiate(specialObject, pos, specialObject.transform.rotation);
                    float prob = Random.value;
                    newSpecialObject.GetComponent<SpecialObjectController>().type = prob < 0.3 ? 1 : prob < 0.6 ? 2 : 3;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && piezasRestantes>0 && selectedPiece!=null)
        {
            int direction = selectedPiece.GetComponent<PlayerController>().direction;
            if (direction!=0 && allowedMove(direction))
            {
                piezasRestantes--;
                selectedPiece.GetComponent<PlayerController>().selected = false;
                selectedPiece.GetComponent<PlayerController>().updateState();
                selectedPiece = Instantiate(selectedPiece,selectedPiece.transform.position,selectedPiece.transform.rotation);
                piezas.Add(selectedPiece);
                selectedPiece.GetComponent<PlayerController>().selected = true;

                if (direction == 2)
                {
                    selectedPiece.transform.position += Vector3.right;
                    selectedPiece.GetComponent<PlayerController>().initSprite(8);
                }
                else if (direction == 8)
                {
                    selectedPiece.transform.position += Vector3.left;
                    selectedPiece.GetComponent<PlayerController>().initSprite(2);

                }
                else if (direction == 1)
                {
                    selectedPiece.transform.position += Vector3.up;
                    selectedPiece.GetComponent<PlayerController>().initSprite(4);

                }
                else if (direction == 4)
                {
                    selectedPiece.transform.position += Vector3.down;
                    selectedPiece.GetComponent<PlayerController>().initSprite(1);

                }

                GameObject.Find("Selector").transform.position = selectedPiece.transform.position;
                //Debug.Log(selectedPiece.transform.position);

                if (piezasRestantes == 0)
                {
                    cambioDeJugador();
                }
                Debug.Log(puntaje.GetComponent<TextMeshProUGUI>().text);
                puntaje.GetComponent<TextMeshProUGUI>().text = ("Movimientos restantes:        " + piezasRestantes);

            }
        }

    }

    bool allowedMove(int direction)
    {
        RaycastHit2D rayo = Physics2D.Raycast(selectedPiece.transform.position, 
            direction == 1? Vector2.up: 
            direction == 2? Vector2.right:
            direction == 4? Vector2.down:
            direction == 8? Vector2.left:
            Vector2.zero, 1);
        if (!rayo)
        {
            return true;
        }
        else if (rayo.collider.tag == "powerUp")
        {
            piezasRestantes*=2;
            Destroy(rayo.collider.gameObject);
            return true;
        }
        else if (rayo.collider.tag == "powerUp2")
        {
            piezasRestantes += 2;
            Destroy(rayo.collider.gameObject);
            return true;
        }
        else if (rayo.collider.tag == "trap")
        {
            piezasRestantes = 1;
            Destroy(rayo.collider.gameObject);
            return true;
        } 
        else if (rayo.collider.tag == "victoria")
        {
            gameOver(selectedPiece);
            return true;
        }
        else
        {
            return false;
        }

        
    }

    public void seleccionarPieza()
    {
        foreach (GameObject obj in piezas)
        {
            //Debug.Log(obj);
            obj.GetComponent<PlayerController>().restart();
        }
        selectedPiece.GetComponent<PlayerController>().selected = true;
    }

    void cambioDeJugador()
    {
        turnoJugador1 = !turnoJugador1;
        selectedPiece.GetComponent<PlayerController>().selected = false;
        selectedPiece = null;
        GameObject.Find("Selector").transform.position+=Vector3.right*500;
        piezasRestantes = Random.Range(1,7);
        turno.GetComponent<TextMeshProUGUI>().text = "Turno: 		   		Jugador " + (turnoJugador1? 1:2);
    }

    void gameOver(GameObject ganador)
    {
        Debug.Log("Terminó el juego, gana el jugador " + (turnoJugador1 ? 1 : 2));
        turno.SetActive(false);
        puntaje.SetActive(false);
        panel.SetActive(true);
        GO.SetActive(true);
        GO.GetComponent<TextMeshProUGUI>().text = "Game Over\r\nGanó el Jugador " + ((turnoJugador1 ? 1 : 2));
    }
}
