using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winningCheck : MonoBehaviour
{
    public Material p1;
    public Material p2;
    public TextMeshPro txt;
    public TextMeshProUGUI replay;

    void Update()
    {
        List<Transform> cells=new List<Transform>();

        foreach (Transform cell in transform)
            cells.Add(cell);

        List<int> winningCells;

        winningCells = rawCheck(cells);

        if(winningCells!=null)
            if (winningCells[1] >= 0)
            {
                cells[winningCells[0]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[1]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[2]].gameObject.GetComponent<Renderer>().material = p1;

                txt.text = "X WIN";
                replay.gameObject.SetActive(true);
            }
            else if (winningCells[1] <= 0)
            {
                cells[winningCells[0] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[1] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[2] * (-1)].gameObject.GetComponent<Renderer>().material = p2;

                txt.text = "O WIN";
                replay.gameObject.SetActive(true);
            }

        winningCells = columnCheck(cells);

        if (winningCells != null)
            if (winningCells[1] >= 0)
            {
                cells[winningCells[0]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[1]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[2]].gameObject.GetComponent<Renderer>().material = p1;

                txt.text = "X WIN";
                replay.gameObject.SetActive(true);
            }
            else if (winningCells[1] <= 0)
            {
                cells[winningCells[0] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[1] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[2] * (-1)].gameObject.GetComponent<Renderer>().material = p2;

                txt.text = "O WIN";
                replay.gameObject.SetActive(true);
            }

        winningCells = diagonalCheck(cells);

        if (winningCells != null)
            if (winningCells[1] >= 0)
            {
                cells[winningCells[0]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[1]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[2]].gameObject.GetComponent<Renderer>().material = p1;

                txt.text = "X WIN";
                replay.gameObject.SetActive(true);
            }
            else if (winningCells[1] <= 0)
            {
                cells[winningCells[0] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[1] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[2] * (-1)].gameObject.GetComponent<Renderer>().material = p2;

                txt.text = "O WIN";
                replay.gameObject.SetActive(true);
            }

        winningCells = reverseDiagonalCheck(cells);

        if (winningCells != null)
            if (winningCells[1] >= 0)
            {
                cells[winningCells[0]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[1]].gameObject.GetComponent<Renderer>().material = p1;
                cells[winningCells[2]].gameObject.GetComponent<Renderer>().material = p1;

                txt.text = "X WIN";
                replay.gameObject.SetActive(true);
            }
            else if (winningCells[1] <= 0)
            {
                cells[winningCells[0] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[1] * (-1)].gameObject.GetComponent<Renderer>().material = p2;
                cells[winningCells[2] * (-1)].gameObject.GetComponent<Renderer>().material = p2;

                txt.text = "O WIN";
                replay.gameObject.SetActive(true);
            }


    }

    //>0 X win, <0 O win
    private List<int> columnCheck(List<Transform> cells)
    {
        List<int> winningCells = new List<int>();

        for (int i = 0, fullColX = 0, fullColO = 0; i < cells.Count; i++)
        {
            winningCells = new List<int>();

            for (int j = i; (j <= i + 6) && (j < cells.Count); j += 3)
            {
                if (cells[j].tag.Equals("X"))
                {
                    fullColX++;
                    winningCells.Add(j);
                }
                else if (cells[j].tag.Equals("O"))
                { 
                    fullColO++;
                    winningCells.Add(j*(-1));
                }
            }

            if (fullColX == 3) return winningCells;
            else if (fullColO == 3) return winningCells;
            else
            {
                fullColX = 0;
                fullColO = 0;
            }
        }
        return null;
    }
    private List<int> rawCheck(List<Transform> cells)
    {
        List<int> winningCells = new List<int>();

        for (int i = 0, fullRawX = 0, fullRawO = 0; i < cells.Count; i += 3)
        {
            winningCells = new List<int>();

            for (int j = i; (j < i + 3) && (j < cells.Count); j++)
            {
                if (cells[j].tag.Equals("X"))
                { fullRawX++; winningCells.Add(j); }
                else if (cells[j].tag.Equals("O"))
                { fullRawO++; winningCells.Add(j * (-1)); }

            }

            if (fullRawX == 3) return winningCells;
            else if (fullRawO == 3) return winningCells;
            else
            {
                fullRawX = 0;
                fullRawO = 0;
            }
        }
        return null;
    }
    private List<int> diagonalCheck(List<Transform> cells)
    {
        List<int> winningCells = new List<int>();

        if (cells[0].tag.Equals("X") && cells[4].tag.Equals("X") && cells[8].tag.Equals("X"))
        {
            winningCells.Add(0);
            winningCells.Add(4);
            winningCells.Add(8);

            return winningCells;
        }   
        else if (cells[0].tag.Equals("O") && cells[4].tag.Equals("O") && cells[8].tag.Equals("O"))
        {
            winningCells.Add(0);
            winningCells.Add(-4);
            winningCells.Add(-8);

            return winningCells;
        }

        return null;
    }
    private List<int> reverseDiagonalCheck(List<Transform> cells)
    {
        List<int> winningCells = new List<int>();

        if (cells[2].tag.Equals("X") && cells[4].tag.Equals("X") && cells[6].tag.Equals("X"))
        {
            winningCells.Add(2);
            winningCells.Add(4);
            winningCells.Add(6);

            return winningCells;
        }
        else if (cells[2].tag.Equals("O") && cells[4].tag.Equals("O") && cells[6].tag.Equals("O"))
        {
            winningCells.Add(-2);
            winningCells.Add(-4);
            winningCells.Add(-6);

            return winningCells;
        }

        return null;
    }

}
