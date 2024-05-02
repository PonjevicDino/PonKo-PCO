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
[Exercises](/Teamfolder/exercises/exercise02)



## Day 3
#### research MQTT:
- MQTT (Message Queuing Telemetry Transport) is a messaging protocol for constrained, low-bandwidth networks and extremely high-latency IoT devices.
- Ideal protocol for machine-to-machine ( M2M ) communications.
- MQTT works on the publisher/subscriber principle and is operated via a central broker. (sender and receiver have no d	irect connection)
- The data sources publish their data and all recipients who are interested in certain messages (“identified by the topic”) receive the data because they have registered as a subscriber.
- Wildcard charakters can be used to subscribe to multiple topics at once, eliminating the need to subscribe to each topic individually and reducing overhead. Can only be used for subscritpions and not for publishing. MQTT supports two types of wildcards: + (single-level) and # (multi-level).

#### exercise
Learning: Do not delete Firewall forwarding :D