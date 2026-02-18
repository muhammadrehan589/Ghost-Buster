
# Ghost Buster

**Ghost Buster** is a 2D action-platformer game developed in **Unity** where players combat various enemies using both ranged and melee attacks. The game features dynamic environments, multiple enemy types, and a comprehensive health and safety system to ensure smooth gameplay.

## 🎮 Features

* **Dynamic Combat System**: Engage enemies with melee strikes or ranged shooting mechanics featuring custom projectile behaviors.
* **Diverse Enemy AI**: Face different challenges including spiders and shooting enemies, each with unique attack patterns and health management.
* **Advanced Safety Mechanics**: Includes a "Warp to Safe Ground" feature and ground check system to handle player navigation and fall recovery.
* **Immersive Audio & Visuals**: Utilizes camera shake effects for impactful combat and a dedicated Sound FX manager with a Main Mixer for environmental audio.
* **Character Animations**: Includes a full suite of animations for idle, walking, jumping, taking off, landing, and attacking.
* **Complete Game Flow**: Features a functional main menu for project navigation and entry.

## 🛠️ Tech Stack

* **Game Engine**: Unity
* **Language**: C#
* **Rendering**: Universal Render Pipeline (URP) with 2D optimization
* **Input System**: Uses the modern Unity Input System for custom control mapping
* **UI System**: Enhanced with TextMesh Pro for high-quality text rendering

## 📂 Project Structure

* **`Assets/Scripts/`**: Contains the core game logic organized by player, enemy, environment, and management modules.
* **`Assets/Prefabs/`**: Stores reusable game objects for projectiles, enemies, and sound effects.
* **`Assets/Scenes/`**: Includes the main `GamePlay` and `Main Menu` scenes.
* **`Assets/Spirits/`**: Holds all visual and audio assets, including background textures, character sprites, and sound files.
* **`ProjectSettings/`**: Contains essential configuration files for the Unity project.

## ⚙️ Setup & Installation

### Prerequisites

* **Unity Hub**: Ensure you have Unity Hub installed.
* **Unity Editor**: Use the specific version required for this project.
* **Visual Studio**: Recommended for editing the C# logic.

### Installation Steps

1. **Clone the Repository**:
```bash
git clone https://github.com/your-username/Ghost-Buster.git

```


2. **Open in Unity**:
* Launch **Unity Hub**.
* Click **Add** and select the `Ghost-Buster` folder.
* Wait for Unity to import the assets and dependencies.


3. **Run the Game**:
* Locate the `Assets/Scenes/Main Menu.unity` scene.
* Click the **Play** button in the Unity Editor.



## 🕹️ Controls

* **Movement**: Controlled via a modern input mapping system.
* **Attack**: Trigger melee or ranged combat via dedicated attack scripts.
* **Safety Recovery**: Fall damage and safety warping are automatically managed by the environment scripts.

## 🤝 Contributing

Contributions to improve character movement, add new enemy types, or refine level design are welcome. Please ensure new scripts are placed in the appropriate subfolder within the `Assets/Scripts/` directory.

## 📄 License

This project follows standard Unity asset and source code licensing.
