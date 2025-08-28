# Object Oriented Programming Demo

## Directory Structure

- The *Security* folder contains the code implementing various security providers.
- The *Communicators* folder contains the code simulating various communication providers. The .NET folder contains the ```c#``` implementation and the java folder for the ```java``` project.
- The *Diagram* folder includes class dependencies for each of the setup (Security and Communicators).
- The *Networking* folder implements communicators with observer pattern.
    + Contains four modules, each of which having its own listeners and subsribing to a single communicator.
    + Whenever the file *in.txt* is modified, the listeners detects it and passes it on to the receiver module.
    + A module subsribes by giving a unique identifier and a listener.
    + It is expected that the new message is of the \<id>:\<message>, where *id* is the identity used while subscribing.


## Class Diagrams

### Communicator 
#### Initial Implementation
![Security-class-diagram](Diagrams/Communicator.png)

#### Communicator Factory Implementation
![Security-class-diagram-factory](Diagrams/CommunicationFactory.png)

### Security
#### Initial Implementation
![Security-class-diagram](Diagrams/SecurityProvider.png)
