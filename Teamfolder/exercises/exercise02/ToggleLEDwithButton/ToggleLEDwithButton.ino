/*
  DigitalReadSerial

  Reads a digital input on pin 2, prints the result to the Serial Monitor

  This example code is in the public domain.

  https://www.arduino.cc/en/Tutorial/BuiltInExamples/DigitalReadSerial
*/

// digital pin 5 has a pushbutton attached to it. Give it a name:
int pushButton = D0;

// digital pin 3 has the LED attached to it:
int LED = D6;

// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
  // make the pushbutton's pin an input:
  pinMode(pushButton, INPUT_PULLDOWN);

  pinMode(LED, OUTPUT);
}

// the loop routine runs over and over again forever:
void loop() {
  // read the input pin:
  int buttonState = digitalRead(pushButton);
  // print out the state of the button:
  Serial.print(buttonState);

  if (buttonState == 1) {
    digitalWrite(LED, HIGH);
    Serial.println(" --> LED ON");
  }

  else {
    digitalWrite(LED, LOW);
    Serial.println(" --> LED OFF");
  }

  delay(1);  // delay in between reads for stability
}
