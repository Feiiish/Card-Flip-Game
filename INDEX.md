# Card-Flip-Game — Project Index

Unity 6 card-matching (memory) game. This index lists folders, key assets, and scripts with short descriptions.

---

## Root

| Item | Description |
|------|-------------|
| `README.md` | Project title: Unity 6 Card Flip Matching Game |
| `LICENSE` | License file |
| `.gitignore` | Git ignore rules |
| `.vscode/` | VS Code / Cursor config (extensions, launch, settings) |
| `Assets/` | All game content (art, scripts, scenes, prefabs, settings) |
| `Packages/` | Unity Package Manager (manifest, lock) |
| `ProjectSettings/` | Unity project settings (audio, graphics, input, etc.) |

---

## Assets

### `Assets/Art/`
- **AppleEmoji/** — Card face images (e.g. face_in_clouds, grinning, imp, nauseated_face, neutral_face, rage, sleeping, thinking_face).
- **CardsPrefabs/** — `Card.prefab` (card with back/face).
- **Images:** `Button.png`, `Card.png`, `menu UI.png`, `victory.png`, `wallpaper.png`.
- **Sources:** `Card.kra`, `wallpaper.kra` (Krita).

### `Assets/Prefabs/`
- **Background.prefab** — Game background.
- **Positions.prefab** — Layout anchor for card positions.
- **GameTracker.asset** — ScriptableObject storing current layout/set (see `GameTracker.cs`).
- **GameTracker.cs** — ScriptableObject: `GameSet` (Set2_3, Set3_4, Set4_4).

### `Assets/Scenes/`
- **Menu.unity** — Main menu (start game, layout choice, exit).
- **Game.unity** — In-game card-matching scene.

### `Assets/Script/`
Core gameplay and UI logic.

| Script | Class name | Purpose |
|--------|------------|--------|
| **Card.cs** | `Card` | Single card: `matchNumber`, `isRevealed`, flip animation (Y rotation + sprite swap), `faceUpIcon` show/hide. |
| **CardFlipper.cs** | `Position` | Input: raycast on click; flips two cards, compares `matchNumber`; match → scale-down + destroy + `ScoreManager.addScore()`; no match → flip back after delay. |
| **CardPlacer.cs** | `CardPlacer` | Uses `GameTracker.gameSet` to pick layout (2×3, 3×4, 4×4); gets positions from position holders, shuffles cards from `cardSet`, places them. |
| **MenuUI.cs** | `exitUI` | Click on object named `"exit"` → `Application.Quit()`. |
| **ScoreManager.cs** | `ScoreManager` | Singleton; tracks score; win thresholds (3 / 6 / 8 pairs by set); shows `winingPanel`, then loads menu via `scenceLoader.goToMenu()`. |
| **OnMouseHover.cs** | `CardHoverClick` | Hover scale-up on cards using 2D collider + mouse position. |

### `Assets/Script/UI/`
| Script | Class name | Purpose |
|--------|------------|--------|
| **scenceLoader.cs** | `scenceLoader` | Scene loading: `scenceName` + raycast click; `setAndGoToGame()` (sets `gameTracker.gameSet`, loads "Game"); `goToMenu()`, `exitApp()`. |

### `Assets/Settings/`
- URP 2D: `UniversalRP.asset`, `Renderer2D.asset`, scene template, `Lit2DSceneTemplate.scenetemplate`.

### `Assets/` (root)
- **InputSystem_Actions.inputactions** — New Input System actions.
- **DefaultVolumeProfile.asset** — Post-processing volume.
- **UniversalRenderPipelineGlobalSettings.asset** — URP global settings.

---

## Enums & shared types

- **GameSet** (in `CardPlacer.cs`): `Set2_3`, `Set3_4`, `Set4_4` — layout / number of pairs (3, 6, 8).

---

## Data flow (summary)

1. **Menu** — `scenceLoader` buttons set `GameTracker.gameSet` and load `Game` (or exit).
2. **Game** — `CardPlacer` reads `GameTracker`, places shuffled cards; `Position` (CardFlipper) handles clicks and match logic; `ScoreManager` counts pairs and triggers win → menu.
3. **Card** — Flip state and animation; `CardHoverClick` adds hover feedback.

---

## File counts (approximate)

- **Scenes:** 2 (Menu, Game).
- **C# scripts:** 8 (Card, CardFlipper, CardPlacer, MenuUI, ScoreManager, OnMouseHover, GameTracker, scenceLoader).
- **Prefabs:** Card, Background, Positions, GameTracker asset.
- **Art:** Emoji card faces, UI/menu images, wallpaper, button.

---

*Generated index for the Card-Flip-Game Unity project.*
