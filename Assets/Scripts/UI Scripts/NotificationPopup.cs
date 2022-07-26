using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationPopup : MonoBehaviour
{
    public CanvasGroup notifUIGroup;
    public TMP_Text notifText;

    float trancparencyNum;
    float speedNum = 0;

    void Update()
    {
        // make text more transparent over time (simulate "fade")
        trancparencyNum -= 0.0001f * speedNum;
        speedNum += 0.05f;
        notifUIGroup.alpha = trancparencyNum;
        // set the notification popup inactive if it gets too transparent
        if (trancparencyNum <= 0.1f)
        {
            gameObject.SetActive(false);
        }
    }

    public void activateNotif(string displayText)
    {
        // initialize "speed" (arbitrary, got number from trial and error)
        speedNum = 0;
        // initialize completely visible text
        trancparencyNum = 1f;
        notifUIGroup.alpha = trancparencyNum;
        notifText.text = displayText;
        gameObject.SetActive(true);
    }
}
