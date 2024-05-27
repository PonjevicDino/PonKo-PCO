using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapMoverHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zoomLayerText;
    [SerializeField] private GoogleMapsHandler googleMapsHandler;

    void Start()
    {
        zoomLayerText.text = googleMapsHandler.zoom.ToString("00");
    }

    public void ZoomIn()
    {
        if (googleMapsHandler.zoom < 18)
        {
            googleMapsHandler.zoom++;
            zoomLayerText.text = googleMapsHandler.zoom.ToString("00");
        }
    }
    public void ZoomOut()
    {
        if (googleMapsHandler.zoom > 10)
        {
            googleMapsHandler.zoom--;
            zoomLayerText.text = googleMapsHandler.zoom.ToString("00");
        }
    }

    public void MoveUp()
    {
        switch (googleMapsHandler.zoom)
        {
            case 10: googleMapsHandler.lat += 0.05f * 2.0f * 2.0f; break;
            case 11: googleMapsHandler.lat += 0.05f * 2.0f; break;
            case 12: googleMapsHandler.lat += 0.05f; break;
            case 13: googleMapsHandler.lat += 0.05f / 2.0f; break;
            case 14: googleMapsHandler.lat += 0.05f / 2.0f / 2.0f; break;
            case 15: googleMapsHandler.lat += 0.05f / 2.0f / 2.0f / 2.0f; break;
            case 16: googleMapsHandler.lat += 0.05f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 17: googleMapsHandler.lat += 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 18: googleMapsHandler.lat += 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
        }
    }
    public void MoveDown()
    {
        switch (googleMapsHandler.zoom)
        {
            case 10: googleMapsHandler.lat -= 0.05f * 2.0f * 2.0f; break;
            case 11: googleMapsHandler.lat -= 0.05f * 2.0f; break;
            case 12: googleMapsHandler.lat -= 0.05f; break;
            case 13: googleMapsHandler.lat -= 0.05f / 2.0f; break;
            case 14: googleMapsHandler.lat -= 0.05f / 2.0f / 2.0f; break;
            case 15: googleMapsHandler.lat -= 0.05f / 2.0f / 2.0f / 2.0f; break;
            case 16: googleMapsHandler.lat -= 0.05f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 17: googleMapsHandler.lat -= 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 18: googleMapsHandler.lat -= 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
        }
    }
    public void MoveLeft()
    {
        switch (googleMapsHandler.zoom)
        {
            case 10: googleMapsHandler.lon -= 0.05f * 2.0f * 2.0f; break;
            case 11: googleMapsHandler.lon -= 0.05f * 2.0f; break;
            case 12: googleMapsHandler.lon -= 0.05f; break;
            case 13: googleMapsHandler.lon -= 0.05f / 2.0f; break;
            case 14: googleMapsHandler.lon -= 0.05f / 2.0f / 2.0f; break;
            case 15: googleMapsHandler.lon -= 0.05f / 2.0f / 2.0f / 2.0f; break;
            case 16: googleMapsHandler.lon -= 0.05f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 17: googleMapsHandler.lon -= 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 18: googleMapsHandler.lon -= 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
        }
    }
    public void MoveRight()
    {
        switch (googleMapsHandler.zoom)
        {
            case 10: googleMapsHandler.lon += 0.05f * 2.0f * 2.0f; break;
            case 11: googleMapsHandler.lon += 0.05f * 2.0f; break;
            case 12: googleMapsHandler.lon += 0.05f; break;
            case 13: googleMapsHandler.lon += 0.05f / 2.0f; break;
            case 14: googleMapsHandler.lon += 0.05f / 2.0f / 2.0f; break;
            case 15: googleMapsHandler.lon += 0.05f / 2.0f / 2.0f / 2.0f; break;
            case 16: googleMapsHandler.lon += 0.05f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 17: googleMapsHandler.lon += 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
            case 18: googleMapsHandler.lon += 0.05f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f / 2.0f; break;
        }
    }
}
