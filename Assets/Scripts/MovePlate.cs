using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    private GameObject reference = null;

    private GameController controller;

    private int matrixX;
    private int matrixY;

    public bool attack = false;

    private void Awake()
    {
        controller = GameController.instance;
    }

    void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        }
    }

    private void OnMouseUp()
    {
        if (attack)
        {
            GameObject cp = controller.GetPosition(matrixX, matrixY);

            if (cp.name == "white_king") controller.Winner("black");
            if (cp.name == "black_king") controller.Winner("white");

            Destroy(cp);
        }

        controller.SetPositionEmpty(reference.GetComponent<Chess>().GetXBoard(),
            reference.GetComponent<Chess>().GetYBoard());

        reference.GetComponent<Chess>().SetXBoard(matrixX);
        reference.GetComponent<Chess>().SetYBoard(matrixY);
        reference.GetComponent<Chess>().SetCoords();

        controller.SetPosition(reference);

        controller.NextTurn();

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
