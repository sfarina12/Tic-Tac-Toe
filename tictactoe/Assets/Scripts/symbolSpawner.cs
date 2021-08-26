using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbolSpawner : MonoBehaviour
{   
    [Header("Players")]
    public playerController player1;
    public playerController player2;

    [Header("Players symbols")]
    public Transform X;
    public Transform O;

    private cellController cellcontroller;
    private GameObject selectedCell;
    private Transform board;

    private void Start()
    {
        board = transform;
        cellcontroller = board.GetComponent<cellController>();
    }

    void Update()
    {
        if (!cellcontroller.selectedCell.Equals(""))
        {
            selectedCell = GameObject.Find(cellcontroller.selectedCell);

            Vector3 act_pos = new Vector3(selectedCell.transform.localPosition.x, 10f, selectedCell.transform.localPosition.z);
            Vector3 act_rot = new Vector3(Random.RandomRange(0, 30), 45, Random.RandomRange(0, 30));

            if (player1.isPlaying)
                Instantiate(X, act_pos, Quaternion.Euler(act_rot)).GetComponent<Rigidbody>().useGravity=true;
            else
                Instantiate(O, act_pos, Quaternion.Euler(act_rot)).GetComponent<Rigidbody>().useGravity = true;

            board.GetComponent<playerSwitcher>().switchPlayer();
        }
    }

    public void manualSpawnSymbol(string cellName)
    {
        selectedCell = GameObject.Find(cellName);

        Vector3 act_pos = new Vector3(selectedCell.transform.localPosition.x, 10f, selectedCell.transform.localPosition.z);
        Vector3 act_rot = new Vector3(Random.RandomRange(0, 30), 45, Random.RandomRange(0, 30));

        if (player1.isPlaying)
            Instantiate(X, act_pos, Quaternion.Euler(act_rot)).GetComponent<Rigidbody>().useGravity = true;
        else
            Instantiate(O, act_pos, Quaternion.Euler(act_rot)).GetComponent<Rigidbody>().useGravity = true;

        board.GetComponent<playerSwitcher>().switchPlayer();
    }
}
