using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    [SerializeField] private GameObject controller;

    private GameObject reference = null;

    private int matrixX;
    private int matrixY;

    public bool attack = false;

    void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        }
    }

    private void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if (attack)
        {
            GameObject gc = controller.GetComponent<GameController>().GetPosition(matrixX, matrixY);

            if (gc.name == "white_king") controller.GetComponent<GameController>().Winner("black");
            if (gc.name == "black_king") controller.GetComponent<GameController>().Winner("white");

            Destroy(gc);
        }

        controller.GetComponent<GameController>().SetPositionEmpty(reference.GetComponent<Chess>().GetXBoard(),
            reference.GetComponent<Chess>().GetYBoard());

        reference.GetComponent<Chess>().SetXBoard(matrixX);
        reference.GetComponent<Chess>().SetYBoard(matrixY);
        reference.GetComponent<Chess>().SetCoords();

        controller.GetComponent<GameController>().SetPosition(reference);

        controller.GetComponent<GameController>().NextTurn();

        reference.GetComponent<Chess>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
