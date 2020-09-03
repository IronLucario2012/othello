using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject GameBoard;

    public GameObject[] GameRows;

    public Button[,] Buttons;

    public GameObject WinScreen;

    private MoveCounterWinScript Win;

    public int numberOfRows = 8, numberOfColumns = 8, movesMade = 0;

    private void Start()
    {
        Buttons = new Button[numberOfColumns, numberOfRows];
        for(int i=0;i<GameRows.Length;i++)
        {
            Button[] rowButtons = GameRows[i].GetComponentsInChildren<Button>();
            for(int j=0;j<rowButtons.Length;j++)
            {
                Buttons[j, i] = rowButtons[j];
            }
        }

        Win = GetComponentInParent<MoveCounterWinScript>();
    }

    public void ButtonPressed(int which)
    {
        int x = which % 8;
        int y = which / 8;

        CallButton(x, y);
        CallButton(x+1, y);
        CallButton(x-1, y);
        CallButton(x, y+1);
        CallButton(x, y-1);
        
        Win.UpdateAllCounters(++movesMade);

        if(CheckComplete())
        {
            WinScreen.gameObject.SetActive(WinScreen.gameObject.activeSelf);
        }
    }

    public void CallButton(int x, int y)
    {
        if(x >= 0 && x < numberOfColumns && y >= 0 && y < numberOfRows)
        {
            ButtonScript bs = Buttons[x, y].GetComponent<ButtonScript>();
            bs.ChangeColour();
        }
    }

    private bool CheckComplete()
    {
        bool isComplete = true;
        for (int i = 0; i < numberOfRows && isComplete; i++)
        {
            for (int j = 0; j < numberOfColumns && isComplete; j++)
            {
                if(!Buttons[j, i].GetComponent<ButtonScript>().GetIsOn())
                {
                    isComplete = false;
                }
            }
        }
        return isComplete;
    }

}
