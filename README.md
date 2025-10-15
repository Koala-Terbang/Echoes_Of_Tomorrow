<table>
  <tr>
    <td align="left" width="50%">
      <img width="100%" alt="gif1" src="https://github.com/Koala-Terbang/Echoes_Of_Tomorrow/blob/main/Assets/Assets/gif/EOTgif.gif">
    </td>
    <td align="right" width="50%">
      <img width="100%" alt="gif2" src="https://github.com/Koala-Terbang/Echoes_Of_Tomorrow/blob/main/Assets/Assets/gif/EOTgif1.gif">
    </td>
  </tr>
</table>

##  Runner Up GameToday 2025
##  Scripts and Features

This game have a lot of mechanics like walking, scanning, interacting, and so much more thanks to all the various script implemented in the game.<br>

Here are some of the main mechanic in this game
|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `NPCChase.cs` | Responsible for making NPCs chase onto player |
| `VisionCone.cs` | Responsible for helping NPCs look for player |
| `PlayerScan.cs`  | Responsible for the scanning mechanics |
| `PuzzleTile.cs`  | Responsible for making the pressure plate level |
| `PlayerKeys.cs`  | Responsible for saving players key inventory |
| `PlayerMovement.cs`  | Responsible for all player movement, animation, and respawning |
| `etc`  | |

<br>

## About
Echoes Of Tomorrow blends stealth, sci-fi visuals, and puzzles for a tense, engaging experience. Players infiltrate a futuristic facility, avoiding guards, cameras, and drones, to retrieve crucial data while solving puzzles and uncovering hidden rooms that reveal more of the story.
<br>

## Developer & Contributions
- Bryant Chandra (Game Programmer)
- Raditya Daryl Raspati (Game Designer)
- Oscar Bagus Putra Penn Klopper (2D Game Artist)
<br>

```
├── EchoesOfTomorrow                  # Contain everything needed for Please Survive to works.
   ├── .vscode                        # Contains configuration files for Visual Studio Code (VSCode) when it's used as the code editor for the project.
      ├── extensions.json             # Contains settings and configurations for debugging, code formatting, and IntelliSense. This folder is related to Visual Studio Code integration.
      ├── launch.json                 # Contains the configuration necessary to start debugging Unity C# scripts within VSCode.                     
      ├── setting.json                # Contains workspace-specific settings for VSCode that are applied when working within the Unity project.
   ├── Assets                         # Contains every assets that have been worked with unity to create the game like the scripts and the art.
      ├── Animation                   # Contains every animation clip and animator controller that played when the game start.all the game art like the sprites, background, even the character.
      ├── Assets                      # Contains all the game art like the sprites, background, even the character.
      ├── Audio                       # Contains every sound used for the game like music and sound effects.
      ├── Scenes                      # Contains all scenes that exist in the game for it to interconnected with each other.
      ├── Script                      # Contains all scripts needed to make the gane get goings like PlayerMovement scripts.
      ├── TextMesh Pro                # Contains TextMesh Pro plugin.
      ├── URP                         # Contains Universal Renderer Pipeline.
   ├── Packages                       # Contains game packages that responsible for managing external libraries and packages used in your project.
      ├── Manifest.json               # Contains the lists of all the packages that your project depends on and their versions.
      ├── Packages-lock.json          # Contains packages that ensuring your project always uses the same versions of all dependencies and their sub-dependencies.
   ├── Project Settings               # Contains the configuration of your game to control the quality settings, icon, or even the cursor settings
├── README.md                         # The description of Please Survive file from About til the developers and the contribution for this game.
```

## Game controls

The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D           | Standard movement |
| Left Click        | UI Interact       |
| Q                 | Scanning          |
| E                 | Interact          |

<br>
