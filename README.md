# Offline-Radio
A program to manually create and play radio stations with.

<p align="center">
  <img width="256" height="256" src="./README/icon.png">
</p>
(The icon is a radio from Resident Evil 5)

## To use

<p align="center">
  <img width="246" height="138" src="./README/offline_radio.png">
</p>

**To add new Stations**
- Click `Stations` --> `Select Folder`
- Select the folder where your radio stations are stored
- Any supported file will be added to the dropdown.

**To play a station**
- Choose the sation from the dropdown
- Press `Play`
  - (The program will immediately start playing if it was playing when closed)

**To stop playing a station**
- Press `Stop`

The volume can be changed using the slider

## Current state
 currently, the program plays only premade radio stations from single audio files.

It currently runs as a winforms program, using [Windows media player](https://learn.microsoft.com/en-us/windows/win32/wmp/embedding-the-windows-media-player-control-in-a-c--solution) as the backend for playing audio, this is intended to be replaced by a more modern/cross-platform implementation.
