using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellController : MonoBehaviour
{
    public Color cellClicked;

    private bool clickHolding=false;
    private RaycastHit hit;
    [HideInInspector]
    public Color playerColor;
    [HideInInspector]
    public string selectedCell;
    private bool whoIsPlaying = true;

    private void Start() { selectedCell = ""; }

    void Update()
    {
        if (!clickHolding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                selectedCell = "";

                if ((hit.transform != null) && ((!hit.transform.tag.Equals("O")) && (!hit.transform.tag.Equals("X"))))
                {
                    updateSelectedCell(hit.transform.name);

                    if (Input.GetMouseButton(0))
                    {
                        hit.transform.gameObject.GetComponent<Outline>().OutlineColor = cellClicked;
                        clickHolding = true;
                    }
                }
                else
                { updateSelectedCell("null"); selectedCell = ""; }
            }
            else
            { updateSelectedCell("null"); selectedCell = ""; }
        }
        else
        {
            placingCell();
        }
    }

    public void placingCell()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selectedCell = hit.transform.name;

            if (whoIsPlaying) { hit.transform.tag = "X"; whoIsPlaying = false; }
            else { hit.transform.tag = "O"; whoIsPlaying = true; }

            clickHolding = false;
        }
    }

    public void placingCell(Transform cell)
    {
        selectedCell = cell.transform.name;

        if (whoIsPlaying) { cell.transform.tag = "X"; whoIsPlaying = false; }
        else { cell.transform.tag = "O"; whoIsPlaying = true; }

        clickHolding = false;
    }

    void updateSelectedCell(string selectedCell)
    {
        foreach (Transform cell in transform)
        {
            try 
            {
                if (cell.name.Equals(selectedCell))
                {
                    cell.gameObject.GetComponent<Outline>().OutlineColor = playerColor;
                    cell.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                    cell.gameObject.GetComponent<Outline>().enabled = false;
            }
            catch (Exception e) { }
        }
        
    }
}
