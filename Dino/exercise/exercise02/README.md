# Lecture 02 - 29.04.2024 - Lab Records:
This process is described [here](/Teamfolder/exercises/exercise02/README.md) more detailly.

## Overview
1. [The ESP32](/Dino/exercises/exercise02/README.md#The_ESP32)
2. [Working with LEDs](/Dino/exercises/exercise02/README.md#Working_with_LEDs)
3. [Simple Web Requests](/Dino/exercises/exercise02/README.md#Simple_Web_Requests)

## The ESP32
We learned about the features and the possibilites of the ESP32.
The pin layout of the Wemos D1 ESP32 can be found [here](/Teamfolder/pictures/exercise02/ESP).
Furthermore, we talked about bus systems - a short summary of the IPS-System is described 
[here](/Dino/researches/research02/README.md#IPS)

## Working with LEDs
We started by connecting the ESP32 to a breadboard with a LED respectively. Then, we made sure,
that all cables are connected to the correct pins and we flashed the "Blink-Example" to the ESP32.

After this step was working, we worked with a button to be able to toggle the state of the LED by
a click/press. To accomplish this, we used the DigitalRead and DigitalWrite Methods of the ESP32.
We learned (the hard way), why "INPUT_PULLUP" or "INPUT_PULLDOWN" may be more usefull than just 
"INPUT" - It maps the values inbetween to either the on or the off state.

## Simple Web Requests
We've extended the provided Server-Example of the ESP32 to provide two additional endpoints -
an "LED-on" and an "LED-off" endpoint. This endpoint than changes the state of the LED if a request
gets sent to it. I.e. by typing "192.168.20.208/on" in the browsers URL bar.

Furthermore, we created an simple "Button-Client" on a second ESP32 and another "Toggle" endpoint.
This button then triggers a request on the second ESP32 which calls the endpoint of the "server".
At the end, we extended that to a third ESP32, so that we had a simple "Flip-Flop" switch. (One
LED, but two individual power switches.)