# Lecture 03 - 02.05.2024 - Reflections:

## Project Story

### Adventure Game in Unity, combined with IoT sensors and LoRaWAN communication
- Hide and Seek Type
- Two or multiple players
	- At least one “hunter” and a “hunted” player
- Checkpoints
- PowerUPs / Events
- Transmitting data only via LoRaWAN
	- & Internet for the InGame-Map
- Finishing Conditions
	- Time runs out
	- Hunted Player escapes the hunter
	- Out of LoRaWAN range
	- Hunted Player gets catched

### Detailed scenario example with ChatGPT
#### Input:
Create a scenario for an adventure hide and seek game for an IoT project, which is implemented in Unity and utilizes multiple IoT sensors and a LoRaWAN connection between the players and/or the main game server. One IoT sensor could be, for example a NFC reader, which gives the player a special PowerUP or triggers a game-wide event. The name for the game should be “HideFromLoRa”.

#### Output – ChatGPT 3.5:
Project Title:  
HideFromLoRa: IoT-Powered Hide and Seek Adventure

Scenario:  
In a sprawling park nestled within a bustling city, a group of friends gathers for a game of hide and seek unlike any other. Armed with innovative technology and a spirit of adventure, they embark on an epic game called HideFromLoRa, where players use IoT sensors and LoRaWAN transmitters to hide and seek each other across the park's expansive grounds.
 
Project Overview:  
HideFromLoRa reimagines the classic game of hide and seek by incorporating IoT sensors and LoRaWAN transmitters to enhance gameplay and extend the boundaries of traditional hide and seek. Players use a mobile app to track each other's locations, hide in clever spots, and uncover hidden treasures scattered throughout the park.

Components:  
IoT Sensors:	Concealed at strategic locations throughout the park, IoT sensors detect player proximity and trigger special events such as treasure chests, power-ups, or temporary invisibility.  
LoRaWAN:	Coupled with IoT sensors, LoRaWAN transmitters enable long-range communication between players' mobile devices and the game server, ensuring seamless gameplay experiences across the park's expansive terrain.  
Mobile App:	Players access HideFromLoRa through a dedicated mobile app, which serves as their guide and interface for the game. The app features a map of the park, real-time player locations, and interactive elements such as quest descriptions and leaderboard rankings.  
Game Server:	The game server orchestrates gameplay, manages player interactions, and delivers real-time updates and challenges to players' devices. It processes data from IoT sensors and transmitters to create dynamic and immersive hide and seek experiences.  

Gameplay Mechanics:  
Hide and Seek Mode:	Players take turns hiding and seeking each other across the park. Hiders use the app to find clever hiding spots and evade detection, while seekers use their tracking abilities to uncover hidden players.  
Interactive Objects:	IoT sensors placed at key locations trigger interactive events when players approach. These could include power-ups that enhance speed or visibility, treasure chests containing valuable rewards, or temporary boosts to player abilities.  
Special Abilities:	Players can unlock special abilities and upgrades by collecting treasures or completing challenges. These abilities, such as temporary invisibility or enhanced tracking, provide strategic advantages during gameplay.   
Dynamic Events:	The game environment evolves over time with the introduction of dynamic events such as sudden weather changes, unexpected obstacles, or surprise encounters with virtual creatures. This adds an element of unpredictability and excitement to the gameplay experience.  

Benefits:  
Outdoor Fun:	HideFromLoRa encourages players to explore the park, enjoy the outdoors, and engage in physical activity while playing the game.  
Social Interaction:	The multiplayer nature of the game fosters social interaction and teamwork among players, promoting communication, collaboration, and friendly competition.  
Strategic Thinking:	Players must use strategic thinking and problem-solving skills to outwit their opponents, find clever hiding spots, and uncover hidden treasures.  
Innovative Technology: HideFromLoRa showcases the potential of IoT sensors and LoRaWAN transmitters to create immersive and interactive gaming experiences that blend the virtual and physical worlds.  

Conclusion:  
HideFromLoRa offers a thrilling and innovative twist on the classic game of hide and seek, where players use technology to transform the park into a playground of adventure and excitement. By harnessing the power of IoT sensors and LoRaWAN transmitters, the game creates a unique and immersive experience that encourages outdoor exploration, social interaction, and strategic thinking.

#### Game example playtrough
Players: “A” – Hunter | “B” – Hunted player

1.	Player A and B start at a random point and set up the App. This includes the download of the map and the connection to a game instance/lobby.
2.	Both Players now have a 10 Minute countdown, where they can separate from each other. Player A must not follow Player B intentionally. No Positions are shown on each other’s screen. If the LoRaWAN connection gets weak, a warning will be shown. The use of cars/bikes/public transport/etc. is prohibited!
3.	The timer runs out and the game switches to the “running” state. Player A has three “Pings” left. A ping triggers the transmission of the hunters’ position for 20 seconds. This Ping is shown actively to Player B.
4.	Player B founds an NFC Tag and an NFC Reader. By activating the reader, he unlocks the PowerUP “Jammer”. It is stored in the inventory.
5.	Player A pings Player B, but the Jammer PowerUP activates.
6.	The Position for Player B is shown on the Map for all Players, but it jitters in an unplausible way.
7.	Player A founds another PowerUP - “ATC”
8.	Player A triggers a new ping, which shows the current Position of Player B for 20 seconds, but also the moving speed, height and direction of the hunted player. This position will be updated multiple times
9.	Player B enters an indoor area and the connection between the LoRaWAN transmitters will get weak. The Game will transmit both positions internally in the background and perform a distance calculation.
10.	The game calculated that the weak signal results from the walls of the building. It will show a warning to both players – Player B gets a timer and has to leave the building.
11.	Player B does not leave the building in time and Player A sees the last Position with a GPS fix.
12.	Player A enters the same building. As both players do not have a GPS connection, but the LoRaWAN connection is established, the Game switches to the “Indoor-Mode”. Both players can see the others’ signal strength.
13.	Player A founds Player B  Game finished. (Go to Step 1)
