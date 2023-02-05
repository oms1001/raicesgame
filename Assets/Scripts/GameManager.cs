using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject objectToSpawn;
    public Sprite[] sprites;

    List<GameObject> piezas = new List<GameObject>();
    public GameObject selectedPiece;

    public int piezasRestantes;
    // Start is called before the first frame update
    void Start()
    {
        piezas.Add(GameObject.Find("Pieza"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && piezasRestantes>0 && selectedPiece!=null)
        {
            int direction = selectedPiece.GetComponent<ChangeSprite>().direction;
            if (direction!=0 && allowedMove(direction))
            {
                piezasRestantes--;
                selectedPiece.GetComponent<ChangeSprite>().selected = false;
                selectedPiece.GetComponent<ChangeSprite>().updateState();
                selectedPiece = Instantiate(objectToSpawn,selectedPiece.transform.position,selectedPiece.transform.rotation);
                piezas.Add(selectedPiece);
                selectedPiece.GetComponent<ChangeSprite>().selected = true;

                if (direction == 2)
                {
                    selectedPiece.transform.position += Vector3.right;
                    selectedPiece.GetComponent<ChangeSprite>().initSprite(8);
                }
                else if (direction == 8)
                {
                    selectedPiece.transform.position += Vector3.left;
                    selectedPiece.GetComponent<ChangeSprite>().initSprite(2);

                }
                else if (direction == 1)
                {
                    selectedPiece.transform.position += Vector3.up;
                    selectedPiece.GetComponent<ChangeSprite>().initSprite(4);

                }
                else if (direction == 4)
                {
                    selectedPiece.transform.position += Vector3.down;
                    selectedPiece.GetComponent<ChangeSprite>().initSprite(1);

                }

                GameObject.Find("Selector").transform.position = selectedPiece.transform.position;
                Debug.Log(selectedPiece.transform.position);
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
            piezasRestantes+=10;
            Destroy(rayo.collider.gameObject);
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
            Debug.Log(obj);
            obj.GetComponent<ChangeSprite>().restart();
        }
        selectedPiece.GetComponent<ChangeSprite>().selected = true;
    }
}
