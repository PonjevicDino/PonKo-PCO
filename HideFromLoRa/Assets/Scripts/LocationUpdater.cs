using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LocationUpdater : MonoBehaviour
{
    [SerializeField] private GameObject gpsLocationPointer;
    [SerializeField] private GoogleMapsHandler googleMaps;
    [SerializeField] private TextMeshProUGUI gpsPosText;
    [SerializeField] private Toggle alignMapToPos;
    [SerializeField] private BluetoothLoRa bluetoothLoRa;
    private float gpsPositionLat;
    private float gpsPositionLon;
    private int updatecounterGPS = 5;
    private int updatecounterBT = 5;
    private PingHandler pingHandler;

    void Start()
    {
        pingHandler = GameObject.Find("PingHandler").gameObject.GetComponent<PingHandler>();    
    }

    void FixedUpdate()
    {
        if (updatecounterGPS <= 0)
        {
            StartCoroutine(UpdateGPSMarker());
            updatecounterGPS = 5;
        }
        else updatecounterGPS--;

        if (updatecounterBT <= 0)
        {
            SendLocToBT();
            updatecounterBT = 150;
        }
        else updatecounterBT--;

    }

    private IEnumerator UpdateGPSMarker()
    {
        gpsPositionLat = Input.location.lastData.latitude;
        gpsPositionLon = Input.location.lastData.longitude;

        if (alignMapToPos.isOn)
        {
            googleMaps.lat = gpsPositionLat;
            googleMaps.lon = gpsPositionLon;
        }

        yield return new WaitForNextFrameUnit();

        float gpsLatDiff = gpsPositionLat - googleMaps.lat;
        float gpsLonDiff = gpsPositionLon - googleMaps.lon;

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

        gpsPosText.text = "Lat GPS:" + gpsPositionLat + "\n" +
                          "Lon GPS:" + gpsPositionLon;/* + "\n" +
                          "\n" +
                          "UnityPosLat:" + gpsLatDiff * 21296.0f * Mathf.Pow(2, googleMaps.zoom - 12) + "\n" +
                          "UnityPosLon:" + gpsLonDiff * 21296.0f * Mathf.Pow(2, googleMaps.zoom - 12) + "\n" +
                          "\n" +
                          "DiffLat:" + gpsLatDiff + "\n" +
                          "DiffLon:" + +gpsLonDiff;*/
    }

    private void SendLocToBT() {
        string sIsPlayerPinged;

        switch (pingHandler.isPlayerPinged)
        {
            case true: sIsPlayerPinged = "T"; break;
            default: sIsPlayerPinged = "F"; break;
        }

        string btString = "Lat:#" + gpsPositionLat + "#, Lon:#" + gpsPositionLon + "#, Ping:#" + sIsPlayerPinged + "# ";
        bluetoothLoRa.SendText(btString);
    }
}
