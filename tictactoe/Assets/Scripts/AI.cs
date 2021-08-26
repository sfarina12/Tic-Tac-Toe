using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public playerController p2;
    public float waitTimeBeforeMooves=0f;

    private float act_time=0;
    private void Start() { act_time = waitTimeBeforeMooves; }
    void Update()
    {
        if (p2.isPlaying)
        {
            if (act_time <= 0)
            {
                List<Transform> cells = new List<Transform>();

                foreach (Transform cell in transform)
                    cells.Add(cell);

                List<int> freeCells = new List<int>();

                int i = 0;
                foreach (Transform cell in cells)
                {
                    if (cell.tag.Equals("Untagged"))
                        freeCells.Add(i);
                    i++;
                }

                int value = Random.RandomRange(0, freeCells.Count);

                Transform choosenCell = cells[freeCells[value]];
                transform.gameObject.GetComponent<cellController>().placingCell(choosenCell);

                transform.GetComponent<symbolSpawner>().manualSpawnSymbol(choosenCell.name);

                act_time = waitTimeBeforeMooves;
            }
            else
            {
                act_time -= Time.deltaTime;
            }
        }
    }
}
