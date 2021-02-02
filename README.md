# BhopmapGenerator
A simple abstraction over Hammer's VMF Model that let's you "program" maps.

Sample code:
```
//Creating a simple Map
Map m = new Map();

//Create a room and add it to the map
Room room = new Room
{
  X = 0,
  Y = 0,
  Z = 0,
  Width = 1024,
  Breadth = 512,
  Height = 384
};
m.AddWorldObject(room);
  
//The string representation of the map is equivalent to the vmf file hammer editor would produce (and can be compiled by it)
Console.WriteLine(m.ToString()); //Save this to a .vmf file
```
Inside the Model folder are the "low level" models, if you want to write code please use the models in the "Structures" folder, such as Block (simple Cube), Room (Simple room with 6 Blocks), ...

Planned features:
Structures for Spawnzones, Bhopzones and much more
Simple Roomconnector that creates a portal at the end of one and a teleport destination at the start of the other
Support for more entities
The actual mapgenerator (Select length, difficulty, standard textures and get a full map with spawn and end)

More info coming. Contact: [Julius (Steam)](https://steamcommunity.com/id/Chefkoch_JJ/)
