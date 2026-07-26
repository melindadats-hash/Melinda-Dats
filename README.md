# Melinda-Dats: Point-and-Click Mobile Game

A Unity-based point-and-click mobile game prototype.

## Project Structure

```
Assets/
├── Scenes/
│   └── MainGame.unity
├── Scripts/
│   ├── Player/
│   │   └── PlayerController.cs
│   ├── Interactions/
│   │   ├── Interactable.cs
│   │   └── InteractionManager.cs
│   └── UI/
│       └── UIManager.cs
├── Prefabs/
│   ├── Interactable.prefab
│   └── UI/
└── Art/
    ├── Sprites/
    └── Animations/
```

## Getting Started

### Prerequisites
- Unity 2022.3 LTS or newer
- A text editor or IDE (Visual Studio, VS Code)

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/melindadats-hash/Melinda-Dats.git
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Add" and select the project folder
   - Open the project with Unity 2022.3 LTS or newer

3. **Create the project structure**
   - In the Assets folder, create the directories shown above
   - The game scripts will handle the core functionality

### Core Mechanics

- **Point-and-Click**: Tap or click on interactive objects to trigger actions
- **Feedback System**: Visual and audio feedback on interactions
- **Scene Navigation**: Move between different game areas

## Scripts Overview

### PlayerController.cs
Handles player input and raycasting for detecting clicked objects.

### Interactable.cs
Base class for all interactive objects in the game.

### InteractionManager.cs
Manages all interactions and event handling.

### UIManager.cs
Handles UI elements like dialogue, feedback messages, and buttons.

## Features (To Implement)

- [ ] Point-and-click detection
- [ ] Interactive object system
- [ ] Dialogue system
- [ ] Inventory system
- [ ] Animation triggers
- [ ] Mobile touch support
- [ ] Scene transitions

## Development Notes

- This is a prototype structure—feel free to expand and modify
- All scripts use Unity's standard conventions
- The game supports both mouse and touch input

## License

Boost Software License 1.0
