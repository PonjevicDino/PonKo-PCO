using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PingHandler : MonoBehaviour
{
    private int pingCount = 10;
    [SerializeField] private GameObject secPlayerPos;
    [SerializeField] private TextMeshProUGUI pingCountText;
    [SerializeField] private Image pingWarningImage;
    private int pingTimer = 250;
    public bool isPlayerPinged = false;

    void FixedUpdate()
    {
        if (secPlayerPos.GetComponent<Image>().enabled)
        {
            if (pingTimer > 0)
            {
                pingTimer--;
                pingCountText.text = (pingTimer / 100.0f * 2.0f).ToString("0.00") + "s";
            }
            else
            {
                secPlayerPos.GetComponent<Image>().enabled = false;
                pingTimer = 250;
                pingCountText.text = pingCount.ToString("00") + "x";
                isPlayerPinged = false;
            }
        }
    }

    public void PingPlayer()
    {
        if (pingCount > 0 && !secPlayerPos.GetComponent<Image>().enabled)
        {
            pingCount--;
            pingCountText.text = pingCount.ToString("00");
            secPlayerPos.GetComponent<Image>().enabled = true;
            isPlayerPinged = true;
        }
    }

    public void ShowPing(string isPlayerPinged)
    {
        switch (isPlayerPinged)
        {
            case "T": pingWarningImage.enabled = true; Handheld.Vibrate(); break;
            default: pingWarningImage.enabled = false; break;
        }
    }
}
