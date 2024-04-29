#include <WiFi.h>
#include <WiFiClient.h>
#include <WebServer.h>
#include <ESPmDNS.h>

const char* ssid = "PonKo-2.4G";
const char* password = "ToDi-PCO";

WebServer server(80);

const int led = D3;
bool ledStatus = false;

void handleRoot() {
  digitalWrite(led, 1);
  server.send(200, "text/plain", "hello from esp32!");
  digitalWrite(led, 0);
}

void handleNotFound() {
  digitalWrite(led, 1);
  String message = "File Not Found\n\n";
  message += "URI: ";
  message += server.uri();
  message += "\nMethod: ";
  message += (server.method() == HTTP_GET) ? "GET" : "POST";
  message += "\nArguments: ";
  message += server.args();
  message += "\n";
  for (uint8_t i = 0; i < server.args(); i++) {
    message += " " + server.argName(i) + ": " + server.arg(i) + "\n";
  }
  server.send(404, "text/plain", message);
  digitalWrite(led, 0);
}

void setup(void) {
  pinMode(led, OUTPUT);
  digitalWrite(led, 0);
  Serial.begin(115200);
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);
  Serial.println("");

  // Wait for connection
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  if (MDNS.begin("esp32")) {
    Serial.println("MDNS responder started");
  }

  server.on("/", handleRoot);

  server.on("/inline", []() {
    server.send(200, "text/plain", "this works as well");
  });

  server.onNotFound(handleNotFound);

  server.begin();
  Serial.println("HTTP server started");

  //Added Endpoints
  server.on("/on", []() {
    server.send(200, "text/plain", "LED should now be on!");
    digitalWrite(led, 1);
    ledStatus = true;
  });

  server.on("/off", []() {
    server.send(200, "text/plain", "LED should now be off!");
    digitalWrite(led, 0);
    ledStatus = false;
  });

  server.on("/toggle", []() {
  server.send(200, "text/plain", "LED should change the mode now!");
    if (ledStatus) {
      digitalWrite(led, 0);
      ledStatus = false;
    }
    else {
      digitalWrite(led, 1);
      ledStatus = true;
    }
  });
}

void loop(void) {
  server.handleClient();
  delay(2);//allow the cpu to switch to other tasks
}
