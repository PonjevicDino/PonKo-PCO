using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;



public class BluetoothLoRa : MonoBehaviour
{
    private string[] deviceNames = {"HideFromLoRa_C01", "HideFromLoRa_C02"};
    private string dataToSend = "Hi!";
    private bool IsConnected;
    public static string dataRecived = "";

    [SerializeField] private SecLocationUpdater secLocationUpdater;

    [SerializeField] private GameObject connectionTimeOutWindow;

    private int connectionTimeOut = 500;

    // Start is called before the first frame update
    void Start()
    {
    #if UNITY_2020_2_OR_NEWER
        #if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation)
          || !Permission.HasUserAuthorizedPermission(Permission.FineLocation)
          || !Permission.HasUserAuthorizedPermission("android.permission.BLUETOOTH_SCAN")
          || !Permission.HasUserAuthorizedPermission("android.permission.BLUETOOTH_ADVERTISE")
          || !Permission.HasUserAuthorizedPermission("android.permission.BLUETOOTH_CONNECT"))
                    Permission.RequestUserPermissions(new string[] {
                        Permission.CoarseLocation,
                            Permission.FineLocation,
                            "android.permission.BLUETOOTH_SCAN",
                            "android.permission.BLUETOOTH_ADVERTISE",
                             "android.permission.BLUETOOTH_CONNECT"
                    });
        #endif
    #endif

        IsConnected = false;
        BluetoothService.CreateBluetoothObject();
       
    }

    void FixedUpdate()
    {
        connectionTimeOut--;
        if (connectionTimeOut < 0)
        {
            connectionTimeOutWindow.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsConnected) {
            try
            {
                string datain =  BluetoothService.ReadFromBluetooth();
                if (datain.Length > 1)
                {
                    dataRecived = datain;
                    print(dataRecived);
                    secLocationUpdater.BTtoLatLon(dataRecived);
                    connectionTimeOut = 500;
                }

            }
            catch (Exception e)
            {
                Debug.LogError(e);
                BluetoothService.Toast("Error in connection");
            }
        }
        
    }

    public void GetDevicesButton()
    {
       string[] devices = BluetoothService.GetBluetoothDevices();

        foreach(var d in devices)
        {
            Debug.Log(d);
        }
    }

    public void StartButton(int index)
    {
        if (!IsConnected)
        {
            IsConnected = BluetoothService.StartBluetoothConnection(deviceNames[index-1]);
            BluetoothService.Toast(deviceNames[index-1]+" status: " + IsConnected);
        }
    }

    public void SendButton()
    {
        if (IsConnected && (dataToSend.ToString() != "" || dataToSend.ToString() != null))
            BluetoothService.WritetoBluetooth(dataToSend);
        else
            BluetoothService.WritetoBluetooth("Not connected");
    }

    public void SendText(string input)
    {
        dataToSend = input;
        SendButton();
    }


    public void StopButton()
    {
        if (IsConnected)
        {
            BluetoothService.StopBluetoothConnection();
        }
        Application.Quit();
    }
}
