#include "BluetoothSerial.h"
#include <SPI.h>
#include <LoRa.h>

//define the pins used by the transceiver module
#define ss 5
#define rst 16
#define dio0 17

int counter = 0;

BluetoothSerial SerialBT;

void setup() {
  Serial.begin(115200);
  SerialBT.begin("HideFromLoRa_C01"); //Name des ESP32
  while (!Serial);
  Serial.println("LoRa Transceiver");

  //setup LoRa transceiver module
  LoRa.setPins(ss, rst, dio0);

  if (!LoRa.begin(866E6)) {
    Serial.println(".");
    delay(500);
  }
  
  // Change sync word (0xF3) to match the receiver
  // The sync word assures you don't get LoRa messages from other LoRa transceivers
  // ranges from 0-0xFF
  LoRa.setSyncWord(0xF3);
  Serial.println("LoRa Initializing OK!");
}

void loop() {
  // LoRa -> BT
  int packetSize = LoRa.parsePacket();
  if (packetSize) {
    String LoRaData;

    // read packet
    while (LoRa.available()) {
      LoRaData = LoRa.readString();
    }

    LoRaData = LoRaData + "- with RSSI:" + LoRa.packetRssi() + ", SNR:" + LoRa.packetSnr(); 
    SerialBT.println(LoRaData);
  }

  // BT -> LoRa
  else if (SerialBT.available()) {
    // send packet
    LoRa.beginPacket();
    while (SerialBT.available()) LoRa.print((char) SerialBT.read());
    LoRa.endPacket();

    //Serial.write(SerialBT.read());
  }
  delay(25);
}