using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// ----------
/// GENERAL PURPOSE SCRIPT FOR CHANGING OBJECT/PART OF OBJECT'S COLORS USING HEXADECIMAL
/// ----------
public class ChangeColorObject : MonoBehaviour
{
    Color newColor; // stores color
    Image newImage; // stores image

    // set the hexadecimal value of the color that is being set (do before setting a color to an object)
    public void setChangedColorHex(string colorHex) {
        // used documentation: https://docs.unity3d.com/ScriptReference/ColorUtility.TryParseHtmlString.html
        ColorUtility.TryParseHtmlString("#" + colorHex, out newColor);
    }

    // USED SOURCE: https://answers.unity.com/questions/1121691/how-to-modify-images-coloralpha.html

    // make an image fully visible/fully opaque
    public void makeImageFullyVisible(GameObject imgObject) {
        newImage = imgObject.GetComponent<Image>();
        newImage.color = new Color(newImage.color.r, newImage.color.g, newImage.color.b, 255f);
        Debug.Log("Aa: " + newImage.color.a + "FOR: " + imgObject.name);
    }

    // make an image invisible
    public void makeImageInvisible(GameObject imgObject)
    {
        newImage = imgObject.GetComponent<Image>();
        newImage.color = new Color(newImage.color.r, newImage.color.g, newImage.color.b, 0f);
        Debug.Log("A: " + newImage.color.a + "FOR: " + imgObject.name);
    }
}
