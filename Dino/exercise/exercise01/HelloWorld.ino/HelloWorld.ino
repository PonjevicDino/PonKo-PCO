void setup() {
  // put your setup code here, to run once:
   Serial.begin(9600);
}

float count = 1;

void loop() {
  // put your main code here, to run repeatedly:
  Serial.print("Hello World! "); Serial.println(count);
  count *= 1.01f;
}
