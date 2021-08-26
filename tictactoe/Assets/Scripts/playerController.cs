using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public cellController board;
    public bool isPlaying;
    public Color playerColor;


    void Update()
    {
        if (isPlaying)
            board.playerColor = playerColor;
    }
}
