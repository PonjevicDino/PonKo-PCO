/*
  DigitalReadSerial

  Reads a digital input on pin 2, prints the result to the Serial Monitor

  This example code is in the public domain.

  https://www.arduino.cc/en/Tutorial/BuiltInExamples/DigitalReadSerial
*/

// digital pin 5 has a pushbutton attached to it. Give it a name:
int pushButton = D0;
bool buttonState = false;

// digital pin 3 has the LED attached to it:
int LED = D6;

#include <WiFi.h>
#include <PubSubClient.h>

const char* ssid = "PonKo-2.4G";
const char* password = "ToDi-PCO";
const char* mqtt_server = "192.168.20.1";

WiFiClient espClient;
PubSubClient client(espClient);

void setup_wifi() {

  delay(10);
  // We start by connecting to a WiFi network
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);

  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  randomSeed(micros());

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
  // make the pushbutton's pin an input:
  pinMode(pushButton, INPUT_PULLDOWN);

  pinMode(LED, OUTPUT);

  setup_wifi();
  client.setServer(mqtt_server, 1883);
  client.setCallback(callback);
}

void reconnect() {
  // Loop until we're reconnected
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    // Create a random client ID
    String clientId = "ESP32Client2-";
    clientId += String(random(0xffff), HEX);
    // Attempt to connect
    if (client.connect(clientId.c_str())) {
      Serial.println("connected");
      // Once connected, publish an announcement...
      client.publish("mqtt", "connected");
      // ... and resubscribe
      client.subscribe("mqtt");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}

void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  for (int i = 0; i < length; i++) {
    Serial.print((char)payload[i]);
  }
  Serial.println();


  // print out the state of the button:
  Serial.print(buttonState);

  if (payload) {
    buttonState = !buttonState;
    Serial.println(buttonState);
    Serial.println("changed");
  }

  if (buttonState == true) {
    digitalWrite(LED, HIGH);
    Serial.println(" --> LED ON");
  }

  else {
    digitalWrite(LED, LOW);
    Serial.println(" --> LED OFF");
  }

  delay(1);  // delay in between reads for stability

}

// the loop routine runs over and over again forever:
void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop();


}
