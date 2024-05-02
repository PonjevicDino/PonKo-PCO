# Lecture 03 - 02.05.2024 - Lab Records:
This process is described [here](/Teamfolder/exercises/exercise03/README.md) more detailly.

## Overview
1. [Project Story](/Dino/exercises/exercise03/README.md#Project_Story)
2. [What is MQTT](/Dino/exercises/exercise03/README.md#What_is_MQTT)
3. [Use of MQTT](/Dino/exercises/exercise03/README.md#Use_of_MQTT) 
4. [Working with a Raspberry Pi](/Dino/exercises/exercise03/README.md#Working_with_a_Raspberry_Pi)

## Project Story
The decription of the project and a simple playtrough/story is located
[here](/Dino/reflections/reflection03/README.md#Project_Story)

## What is MQTT
MQTT enables the transmittion of Telemety-Data over any network, even if the latency is high or the network is congested. MQTT uses
the Ports 1883 and 8883, which are reserved by the IANA (Internet Assigned Numbers Authority). TLS is optional, but can be used.

The MQTT-Server (called "Broker"), holds the current state of all its clients, therefore it may be used as a simple database. A
typlical client would be a temperature sensor on an actuator.

To call any client, the server has to send the message in a hierarchial way. I.e. "Car/Tyre/FL/Pressure". MQTT uses QOS (Quality
of service), which can show how important any message is.

### How to stop the MQTT Broker
"/etc/int.d/mqttbroker stop"

## Use of MQTT
We used the mqttsuite, which we installed on the WiFi Router and we installed "Mosquitto" for
Windows, to be able to push and listen to messages on the MQTT Server. After me made sure that the
messages can be transmitted and recieved correctly via the command line, we changed the
LED-Example from the second lecture, so that it works with MQTT and not with simple HTTP requests.

## Working with a Raspberry Pi
Then, we downloaded and installed Pi-OS to a Raspberry 4 Kit. This included the initial setup in 
the PI-Manager and installing the updates for the system via a SSH connection and the "apt update"/
"apt upgrade" command.

At the end of this lecture, we installed "Node-RED" to the Raspberry Kit.