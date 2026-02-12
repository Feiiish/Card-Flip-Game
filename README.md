# Card Flip Matching Game

A classic memory matching card game built with Unity 6.

## Features

- **Three Game Modes** – Choose from different difficulty levels
  - 2×3 (6 cards / 3 pairs)
  - 3×4 (12 cards / 6 pairs)
  - 4×4 (16 cards / 8 pairs)

- **Smooth Animations** – Card flip, match success, and victory effects
- **Interactive Feedback** – Hover effects on cards
- **Menu System** – Easy level selection and game navigation
- **Score Tracking** – Real-time pair counting and automatic win detection

## Gameplay

1. **Main Menu** – Select your difficulty level
2. **Game Scene** – Flip cards to find matching pairs
3. **Victory** – Display victory panel after matching all pairs
4. **Return to Menu** – Automatically return to main menu

## Project Structure

```
Assets/
├── Art/                    # Graphics and sprites
├── Prefabs/               # Game prefabs
│   ├── Card.prefab        # Card prefab
│   ├── Background.prefab  # Background
│   ├── Positions.prefab   # Card layout positioning
│   └── GameTracker.asset  # Game configuration
├── Scenes/                # Game scenes
│   ├── Menu.unity         # Main menu
│   └── Game.unity         # Game scene
└── Script/                # C# scripts
    ├── Card.cs
    ├── CardFlipper.cs
    ├── CardPlacer.cs
    ├── ScoreManager.cs
    ├── OnMouseHover.cs
    ├── MenuUI.cs
    ├── GameTracker.cs
    └── UI/
        ├── MenuController.cs
        └── scenceLoader.cs
```

## How to Play

1. Open the project in Unity 6
2. Load the `Assets/Scenes/Menu.unity` scene
3. Click Play to start the game
4. Select a difficulty and begin matching cards!

## License

See [LICENSE](LICENSE) file for details
