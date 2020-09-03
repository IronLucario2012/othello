using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCounterWinScript : MonoBehaviour
{
    public Text WinMovesText;
    public Text MoveCounter;

    public string MoveCounterText = "Moves Made: ";

    public void UpdateAllCounters(int movesMade)
    {
        UpdateMoveCounter(movesMade, WinMovesText);
        UpdateMoveCounter(movesMade, MoveCounter);
    }

    public void UpdateMoveCounter(int movesMade, Text box)
    {
        if (movesMade < 1000)
        {
            box.text = MoveCounterText + movesMade;
        }
        else
        {
            box.text = MoveCounterText + "999+";
        }
    }


}
