# cave-adventure-demo

> This demo shows how you can use a camera to follow a character using overrides to control the viewport.

* [Overview](#overview)
* [Usage](#usage)

<a name="overview"></a>
## Overview

Controls:

* Left : a | left-arrow
* Right: d | right-arrow
* Jump : spacebar
* Reset: r

Starting point:

![image](https://user-images.githubusercontent.com/7356219/114114321-81ca4d00-9895-11eb-983a-352dc0715dcb.png)

Camera adjusts as the cave guy is going down

![image](https://user-images.githubusercontent.com/7356219/114114367-94448680-9895-11eb-804d-261119f5c4b4.png)

Camera keeps following using colliders to determine placement

![image](https://user-images.githubusercontent.com/7356219/114114426-af16fb00-9895-11eb-8271-6e958cd64b3b.png)

## Usage

Under CaveGuy game object there's a CaveGuyCameraService. This has 2 values. Smooth Time X and Smooth Time Y. For both, the lower the value, the slower it will follow along that axis, the higher the faster it will follow, eventually instant.

![image](https://user-images.githubusercontent.com/7356219/115081271-d9317400-9eb8-11eb-9fcd-7e47e7187df4.png)

The camera is controlled by CameraOverride game objects which have a trigger collider on them for how the override should affect the camera.

Set Camera Offset Relative. By Default is on. This will update the Y position of the camera relative to the game object.
Set Camera Offset. Using the values from New Offset to the camera.
Set Camera Offset X. Using the x value from New Offset to the camera.
Set Camera Offset Y. Using the y value from New Offset to the camera.
Follow Y. Whether to trigger the camera to start following on the Y.
Unfollow Y. Whether to trigger the camera to start unfollowing on the Y.
New Offset. Use this to adjust the camera.
Relative Object. This is where the camera will go when triggered.

![image](https://user-images.githubusercontent.com/7356219/115081443-201f6980-9eb9-11eb-98af-a4a4d51fd44e.png)

