# **Design Pattern Report**
##### *ABOU JAOUDE Yann  - BALLET Maël*
> **Final Project – A Monopoly™ game**

> Objective of the project is to simulate a simplified version of the Monopoly™
game.

![](https://i.pinimg.com/originals/0f/c1/6f/0fc16fd16c0d0590ef41ba4a44816455.jpg)
## *Choice of Design Pattern*

- *MVC*
- *Observer*
- *Singleton*


#### MVC 
    Stands for "Model-View-Controller." MVC is an application design model comprised of three interconnected parts. 
    They include the model (data), the view (user interface), and the controller (processes that handle input).

#### Observer
    The subject, maintains a list of its dependents, called observers and notifies them automatically of any state changes.
    It is easier for the player to visualize the board in order to play.
#### Singleton
    Ensure a class has only one instance and provide a global point of access to it.
    There is only one board in a monopoly game so it's important that we can use only one.
