using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    private GameObject reference = null;
    private GameController controller;
    private int matrixX;
    private int matrixY;
    private bool attack = false;
    private Chess chess;

    [SerializeField] private SpriteRenderer rend;

    private void Awake()
    {
        controller = GameController.instance;
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (attack)
        {
            rend.color = new Color(1f, 0f, 0f, 1f);
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
        chess = reference.GetComponent<Chess>();

        controller.SetPositionEmpty(chess.GetXBoard(), chess.GetYBoard());

        chess.SetXBoard(matrixX);
        chess.SetYBoard(matrixY);
        chess.SetCoords();

        controller.SetPosition(reference);

        controller.NextTurn();

        chess.DestroyMovePlates();
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

    public void SetAttack()
    {
        attack = true;
    }
}
