using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;

    public void ChangeColour()
    {
        var colours = button.colors;
        colours.normalColor = InvertColour(colours.normalColor);
        colours.highlightedColor = InvertColour(colours.highlightedColor);
        colours.disabledColor = InvertColour(colours.disabledColor);
        colours.pressedColor = InvertColour(colours.pressedColor);
        colours.selectedColor = InvertColour(colours.selectedColor);
        button.colors = colours;
    }

    Color InvertColour(Color ColourToInvert)
    {
        const int RGBMAX = 1;
        return new Color(RGBMAX - ColourToInvert.r, RGBMAX - ColourToInvert.g, RGBMAX - ColourToInvert.b);
    }
}
