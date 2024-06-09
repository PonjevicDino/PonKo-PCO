# Project - HideFromLoRa

## The Idea/General:
HideFromLoRa is a simple Android Game, where two players can play a type of a hide'n'seek game. The main difference is, that both players can
see each other on a map. - But to see the other player, he has to be "pinged", while the amount of pings left is limited. The game ends, if
the hunter finds the other player, or if both players leave the LoRaWAN coverage from each other.

## Technical information:
The communication between the players is handled by two LoRaWAN tranceivers. LoRaWAN is a similar way to transmit data from one device to the
other, similar to WiFi or the mobile network. The biggest advantage of LoRaWAN is the transmitting distance but with the cost of a lower 
bandwidth. With perfect conditions, a range of multiple of hunderds of kilometers could be reached.

Both LoRaWAN tranceivers are connected to one ESP32 respectively, while each ESP32 is connected to the users device with bluetooth via a serial
connection. The ESP32s just need a 5V power input, which can be provided by the Android device via USB-OTG or as simple as a power bank.

Because of these types of connections used, the game could be played entirely without an connection to the internet. (The only exeption is the
download of the map data, which is hosted by Google and then shown in the game - similar to Google Maps.)

The connection between both devices:
Phone 1 <-> BT serial <-> ESP32 1 <-> LoRaWAN 1 <-> LoRaWAN Connection <-> LoRaWAN 2 <-> ESP32 2 <-> BT serial <-> Phone 2

The project is built in Unity with the version "2023.3.22f1", which made the creation process way easier.

## Building and Programming:
### Step 0: Getting the parts needed
Done by Volker :)

### Step 1: Testing the ordered LoRaWAN transceivers
Also done by Volker ... but we "undid" that step again by connecting the LoRaWAN transceivers to the ESPs wrongly. At the beginning, we didn't
notice that, and we started to implementing the BT connection at the same time - what just led to more confusion...

During the disassemly of the connections for storing the hardware, we noticed, that one ESP32 was turned upside down - this notice saved us a
ton of "trial and error" work. But after this was fixed, the ESPs were able to send a "Hello World" signal to each other via LoRaWAN.

### Step 2: Modifying the transmitted string
After some brainstorming, we decided to not implement a custom transmission protocoll, but to use a simple string to store the transmitted data.
At the same time, we just needed a small amount of information - to be precise:
- LatPosition (float - from Unity)
- LotPosition (float - from Unity)
- PingSignal (bool - from Unity)
- Metadata (string - created on the ESP32)
	- The Metadata stores and shows the current signal strengh and quality with a RSSI and a SNR (signal to noise) value.

The final string is formated then, to be able to decode it later on the receiver device.
Example: [UNITY_PART]#- RSSI: -90 - SNR: 2.25

### Step 3: Communicating with the ESP32 via BT serial
To test the transmission of custom strings, we used an simple Serial Terminal App for Android and modified the code for the ESP32 so that it
reads the input from the BT serial interface and sends it to the LoRaWAN transceiver. To simplify the porcess, we have done some smaller steps
during the implementation of this part (e.g. capturing the string from the BT serial interface and send it to the USB serial interface). At
the end, both devices were able to communicate via the BT and LoRaWAN connection. At this point, the work on the hardware (and the ESP32) was
fully completed.

### Step 4: Unity... and the start of many "it crashed - again" moments
We started with the setup by installing the necessary software - the Android SDK. This SDK contains various tools, including the APK-compiler
and the ADB interface. ADB is used to gain developer (not to mistake with "root") access to the Android device - with that it is easier to
sideload custom apps to the device and read its generated logs (called "Logcat" on Android). After the setup was complete, we started with the
implementation of the map system

### Step 5: Our main game | 5% game - 95% map
It is quite easy to store the whole game system in one sentence: "An interactive map, which shows the own and the others players location."

While this sounds easy, the practical part was more complicated. It is not easy to find a free map-provider without using OSM maps and drawing
them with own and custom code. Of course, this would be possible, but it wouldn't fit the goal of the project well. Therefore we choosed 
Google as our map-provider - to be precise, the Maps Static API. This API takes a Lat/Lon value and some metadata (map type/quality) as the
input and provides us with a PNG of the choosen map tile. These API calls are inexpensive (tens of thousends for less than 1 ) and Google 
allocates every user a "test credit" of 300 .

### Step 6: The map
As described before, the map is just a simple PNG, which is shown in the Background. Furthermore, we implemented a way to move the map with
four buttons and two seperate buttons to zoom in/out. There is also a button, which centers the map to the position of the own device. Two
dots (a blue one and a red one) are overlaying the map, to show the current postition.

### Step 7: Getting the GPS position and showing it on the map
Getting the GPS position was easy, because it is as simple as one line of code. - But the hard part was the projection to the map. We knew
two important values - the center lat/lon of the map and the gps lat/lon. "But by how much has the point to move from the center, if the 
position changes". Mathematically, we were not able to solve this in a reasonable amount of time, because the map was projected with the 
Mercator type. Simplified - it is smaller near the equator and bigger near the earths poles.

To solve the problem we just opened the game and went "out of map". At this point, we knew the difference between that GPS position and the
center of the map. Now we could transform this difference to the dot-movement in an amount of pixels.

The dot of the other player is shown in a similar way - only the input source is different (internal GPS --> lat/lon string).

### Step 8: Unity and Bluetooth
As we have prepared our ESPs, we needed a way to communicate with the BT serial interface via Unity. There were some plugins to do that, but
none of it worked with Android 14 during to security restrictions. At the end, we've found a plugin from 2018, which handles the BT connection
and the serial input/output.

### Step 9: Testing the full connection
Before continuing to work on the game part of the project, we have decided to create another Unity scene to try to send a simple "Heartbeat"-
string to the other device and to decode it on the same device. This worked quite well and the test scene became our main menu, which also 
can load the main scene and also exit the application.

### Step 10: Creating the ping signal
The ping signal and both lat/lon positions are known to both game instances at any time, but they are not shown to the player. Every player
has 10 pings left when the game starts and a ping can be sent at any time by pressing the corresponding button. Doing that, the game enables
the other players dot for five seconds and it sends a ping signal with the next transmission. This ping signal triggers a warning on the
second device.

### Step 11: String encoding and decoding
As described before, the transmitted string has two main parts - from Unity and from the ESP. Because we knew the encoding, we were able to
decode it, just by reversing the process.

Example string: "Lat:#12.34567#-Lon:#01.23456#-Ping:#false# - RSSI: -90 - SNR: 2.25"

Decoded version (seperated by "#"):
- Lat: (not used)
- 12.34567 (--> 2nd player lat float)
- Lon: (not used)
- 01.23456 (--> 2nd player lon float)
- Ping: (not used)
- false (--> show warning bool)
- RSSI: -90 - SNR: 2.25 (--> TextMesh string)

### Step 12: Final optimizations
At this state, the game was quite playable. We just needed to disable some debug text boxes and to move the buttons, so that they could be 
used with multiple screen aspect ratios. Furthermore, we also forced the game to the portrait screen rotation mode.

## Presentation and Playtrough:
Simplified - the presentation of the project and our work was successfull.

Sometimes the connection between the ESP32 and the LoRaWAN
tranceiver might fail, because one or more cables become loose by the movements. But to fix this, it is only necessary to attach the cables 
to the correct pins and to reconnect to the corresponsing ESP via Bluetooth.