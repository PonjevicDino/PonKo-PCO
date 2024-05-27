using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SecLocationUpdater : MonoBehaviour
{
    [SerializeField] private GameObject gpsLocationPointer;
    [SerializeField] private GoogleMapsHandler googleMaps;
    [SerializeField] private TextMeshProUGUI secGpsPosText;
    [SerializeField] private TextMeshProUGUI signalText;
    private float secGpsPositionLat;
    private float secGpsPositionLon;
    private int updatecounter = 50;

    private int updateCounter = 0;

    private PingHandler pingHandler;

    void Start()
    {
        pingHandler = GameObject.Find("PingHandler").gameObject.GetComponent<PingHandler>();
    }

    public void BTtoLatLon(string input)
    {
        // Lat:#00.00000#,Lon:#00.00000# - RSSI....
        Debug.LogWarning(input);
        string latString = input.Split('#')[1];
        string lonString = input.Split('#')[3];
        pingHandler.ShowPing(input.Split('#')[5]);
        signalText.text = input.Split('#')[6].Substring(8);

        secGpsPositionLat = float.Parse(latString);
        secGpsPositionLon = float.Parse(lonString);
    }

    private void UpdateDemoSecGPS()
    {
        if (updateCounter < 20)
        {
            secGpsPositionLat -= 0.0005f;
            updateCounter++;
        }
        else if (updateCounter < 40)
        {
            secGpsPositionLon -= 0.0005f;
            updateCounter++;
        }
        else if (updateCounter < 60)
        {
            secGpsPositionLat += 0.0005f;
            updateCounter++;
        }
        else if (updateCounter < 80)
        {
            secGpsPositionLon += 0.0005f;
            updateCounter++;
        }
        else updateCounter = 0;
    }

    void FixedUpdate()
    {
        if (updatecounter <= 0)
        {
            StartCoroutine(UpdateGPSMarker());
            updatecounter = 20;
        }
        else updatecounter--;
    }

    private IEnumerator UpdateGPSMarker()
    {
        //UpdateDemoSecGPS();

        yield return new WaitForNextFrameUnit();

        float gpsLatDiff = secGpsPositionLat - googleMaps.lat;
        float gpsLonDiff = secGpsPositionLon - googleMaps.lon;

        switch (googleMaps.zoom)
        {
            case 12: 
                gpsLocationPointer.transform.SetLocalPositionAndRotation(new Vector3(gpsLonDiff * 14182.0f, gpsLatDiff * 21296.0f, 0.0f), Quaternion.identity);
                break;
            case 13:
                gpsLocationPointer.transform.SetLocalPositionAndRotation(new Vector3(gpsLonDiff * 14182.0f * 2.0f, gpsLatDiff * 21296.0f * 2.0f, 0.0f), Quaternion.identity);
                break;
            case 14:
                gpsLocationPointer.transform.SetLocalPositionAndRotation(new Vector3(gpsLonDiff * 14182.0f * 4.0f, gpsLatDiff * 21296.0f * 4.0f, 0.0f), Quaternion.identity);
                break;
            case 15:
                gpsLocationPointer.transform.SetLocalPositionAndRotation(new Vector3(gpsLonDiff * 14182.0f * 8.0f, gpsLatDiff * 21296.0f * 8.0f, 0.0f), Quaternion.identity); 
                break;
            case 16:
                gpsLocationPointer.transform.SetLocalPositionAndRotation(new Vector3(gpsLonDiff * 14182.0f * 16.0f, gpsLatDiff * 21296.0f * 16.0f, 0.0f), Quaternion.identity); 
                break;
            case 17:
                gpsLocationPointer.transform.SetLocalPositionAndRotation(new Vector3(gpsLonDiff * 14182.0f * 32.0f, gpsLatDiff * 21296.0f * 32.0f, 0.0f), Quaternion.identity);
                break;
            case 18:
                gpsLocationPointer.transform.SetLocalPositionAndRotation(new Vector3(gpsLonDiff * 14182.0f * 64.0f, gpsLatDiff * 21296.0f * 64.0f, 0.0f), Quaternion.identity);
                break;
        }

        secGpsPosText.text = "Lat GPS:" + secGpsPositionLat + "\n" +
                             "Lon GPS:" + secGpsPositionLon + "\n" +
                             "\n" +
                             "UnityPosLat:" + gpsLatDiff * 21296.0f * Mathf.Pow(2, googleMaps.zoom - 12) + "\n" +
                             "UnityPosLon:" + gpsLonDiff * 21296.0f * Mathf.Pow(2, googleMaps.zoom - 12) + "\n" +
                             "\n" +
                             "DiffLat:" + gpsLatDiff + "\n" +
                             "DiffLon:" + +gpsLonDiff;
    }
}
