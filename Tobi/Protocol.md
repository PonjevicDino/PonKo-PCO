# Personal Protocol - Tobias Kothbauer

## Day 1
#### intro
- choose partner
- introduction round (very diverse knowledge and many different prior experiences)
- setting up Git Repo was a little bit confusing but at the end it worked out
- getting to know to the Kit -> we went trough the most of the sensors and what they are for

#### research IoT:
- Definition IoT:
The Internet of Things (IoT) is the name given to the network of physical objects (“Things”) that are equipped with sensors, software and other technology to network them with other devices and systems over the Internet so that data can be transferred between the objects can be exchanged. These devices range from normal household items to sophisticated industrial tools. 
- Domains:
Home Automation Cities Environment, Energy, Retail, Logistics, Agriculture, Industry and Health & Lifestyle.
- commonly used (data protocols):
MQTT, HTTP, CoAP, AMQP, Websocket
- typical devices:
Arduino, Raspberry Pi



## Day 2
### research SPI Bus System:
[Notepad](/Notepad.docx)

### Exercises:
[Exercise2](/Teamfolder/exercises/exercise02/README.md)

####  ESP32
I already had some prior knowledge working with an ESP32 from the lecture in the last Semester "Physical Prototyping". But some features of the ESP32 we learned about were nevertheless new to me. We also worked with LED's, which we also have already done in "Physical Prototyping", but it was a good to refresh knowledge.
During the exercise we got a little bit stuck, because we were not aware of how to use "INPUT_PULLUP" or "INPUT_PULLDOWN" correctly. 

#### Web Requests
This was new to me and quite fun! We implement two additional endpoints to the Server-Example which allowed us to change the state of the LED when a request
gets sent to the provided endpoint. We also adapted this example to toggle the state via a button click - quite cool!


## Day 3
#### research MQTT:
- MQTT (Message Queuing Telemetry Transport) is a messaging protocol for constrained, low-bandwidth networks and extremely high-latency IoT devices.
- Ideal protocol for machine-to-machine ( M2M ) communications.
- MQTT works on the publisher/subscriber principle and is operated via a central broker. (sender and receiver have no d	irect connection)
- The data sources publish their data and all recipients who are interested in certain messages (“identified by the topic”) receive the data because they have registered as a subscriber.
- Wildcard charakters can be used to subscribe to multiple topics at once, eliminating the need to subscribe to each topic individually and reducing overhead. Can only be used for subscritpions and not for publishing. MQTT supports two types of wildcards: + (single-level) and # (multi-level).

I had no prior knowledge in MQTT so it was interesting to learn about it :)

#### exercise
Learning: Do not delete Firewall forwarding :D
[Exercise3](/Teamfolder/exercises/exercise03/README.md)


## Day 4
#### trying integrate mqtt within the toggle LED exercice (click button on one esp32 -> toggle LED on other esp32)
We had our problems with this task. Mainly because we didn't register the client with the "connect" action.
[Exercises](/Teamfolder/exercises/exercise03/MQTT-ToggleLEDwithButton)

#### Setting up project HideFromLoRaWan
A lot of time was used to install Unity and to let the project initially run. At the end everything worked and we could start with the project.
- problems: needed Unity Pro, wrong run configs


## Day 5
#### HideFromLoRaWan: GPS Signal in Unity
Getting the GPS Coordinates for the device was relatively easy, the challenging part was to map the coordinates to the 2D Google Maps picture we have in our game.

## Day 6, 7, 8, ...
#### HideFromLoRaWan - Learnings
- Basics in Unity
- Using Bluetoth to connect devices with unity to be able to retrieve data. It was pretty hard to find a fitting library to establish such connection via bluetooth. We tried some and were frustrated they did not work. After trying an older version of the library the connection finally worked - this was maybe because the older version did not care that much about restrictions from android.
- Communication between two Esp's with LoRaWan Sensors. This worked quite well - i was surprised the connection lasted so far... from the FH2 Top to the Hagenberg castle!. We also learned that buildings played a huge role in blocking the signal. Another thing we had to deal with were loose contacts. We thought the program was wrong, but in reality we just hat a loose contact some times. In one scenario we layed down the esp on a windowsill and caused a circuit.

## Last Day
- not much prior knowledge of certificates -> so most of it was a new learning :)

