# Energy Bar System (Unity / C#)

![Energy bar image](/doc/energyBar.png)

## What is it?

Energy bar system allows to spawn one or more object linked HUD energy bars to target canvas.

* Spawn energy bars and link them to target canvas and make them follow a target object

* Automatic culling for off screen (behind the camera) energy bars to circumvent known issue with Unity screen space elements

* Stepped, interval update for energy bar texts

* Raycast click detection on energy bars and click event support for energy bar


# Classes

## BarCreator MonoBehaviour
Call the Create method of the class to instantiate an energy bar over a target object. Create automatically attaches energy bar to the target Canvas, assigns it a target object and inits it.

## BarHandler MonoBehaviour
Handles moving and updating of the energy bar it owns. Call methods to Update both the energy bar and the text.

## Test scripts
Scripts_test folder contains scripts that are only relevant for the demo scene (wandering NPCs). These scripts show how to setup elements and how to spawn energy bars, how to add bar click event listeners and how to update energy bars. Use arrow keys to move around NPC crowd.

## About
I created Energy Bar System for myself for different personal Unity projects. 

## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
