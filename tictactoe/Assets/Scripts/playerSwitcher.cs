using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwitcher : MonoBehaviour
{
    public playerController player1;
    public playerController player2;

    public void switchPlayer()
    {
        if (player1.isPlaying)
        {
            player1.isPlaying = false;
            player2.isPlaying = true;
        }
        else
        {
            player1.isPlaying = true;
            player2.isPlaying = false;
        }
    }
}
