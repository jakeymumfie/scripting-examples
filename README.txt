Jakey Mumfie, June 2018
Protocol Aurora Scripting Examples

* Dynamic Sound Container:
Class for holding dynamically generated audio events. Keeps track of how many 
events are posted to it and destroys its instance once all events are over.

* Interactor Sounds:
Simple container class for Interactor minigame sfx

* Music Manager:
Has switching capabilities for menu, gameplay, and combat, but combat was
never implemented due to time constraints. Instead, combat tracks were added
in gameplay random playlist in Wwise. This script mostly handles menu to
gameplay to menu switching and initializing to the right state.

* Player Animation Sounds:
Logic for footstep and jump audio with speed and material switches. All
methods in this script are called from animation timeline. Material switches 
were not implemented due to time constraints. 

* Player Sounds:
Logic for player take damage, death, and respawn sfx. Taking damage sound
only plays one at a time using event callbacks.

* Prop Audio Object:
For spatialized ambient loops associated with specific props. Uses an enable
toggle to control individual props from a prefab, i.e. for destroyed pumps.

* Wind Audio Object:
Similar to Prop Audio Object for procedural wind generation. Sends a 
randomized seed as a Wwise RTPC that is then passed into PureData through a 
Heavy parameter. 