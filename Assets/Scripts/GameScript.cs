using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject GameBoard;

    public GameObject[] GameRows;

    public Button[,] Buttons;

    public int numberOfRows = 8, numberOfColumns = 8;

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

    }

    public void CallButton(int x, int y)
    {
        if(x >= 0 && x < numberOfColumns && y >= 0 && y < numberOfRows)
        {
            ButtonScript bs = Buttons[x, y].GetComponent<ButtonScript>();
            bs.ChangeColour();
        }
    }

}
