# Unity Scene Setup Guide

## Creating MainGame.unity Scene

### Step 1: Create the Scene
1. Right-click in the Assets/Scenes folder
2. Select "Create" → "Scene"
3. Name it "MainGame"

### Step 2: Scene Hierarchy Setup

Create the following hierarchy in your scene:

```
MainGame (Scene Root)
├── Camera
├── Canvas (UI)
│   ├── FeedbackText
│   ├── DialoguePanel
│   │   ├── DialogueText
│   │   └── NextButton
│   └── DebugText
├── GameManager (Empty GameObject)
├── Managers (Empty GameObject)
│   ├── InteractionManager
│   └── PlayerController
└── Environment (Empty GameObject)
    ├── Background (Sprite)
    └── InteractableObjects
        ├── Door (with Interactable script)
        ├── Button (with Interactable script)
        └── Item (with Interactable script)
```

### Step 3: Configure Camera

1. Select "Camera" in the hierarchy
2. In Inspector:
   - Camera Type: 2D (Orthographic)
   - Orthographic Size: 5
   - Background Color: Choose a background color (e.g., light blue)

### Step 4: Create Canvas (UI)

1. Right-click in hierarchy → UI → Canvas
2. Set Canvas Scaler:
   - UI Scale Mode: "Scale with Screen Size"
   - Reference Resolution: 1080 x 1920

#### Add Feedback Text
1. Right-click Canvas → UI → TextMeshPro - Text
2. Rename to "FeedbackText"
3. Set anchors to bottom-center
4. Position: (0, 100, 0)
5. Size: (800, 100)
6. Font Size: 36
7. Alignment: Center

#### Add Dialogue Panel
1. Right-click Canvas → UI → Panel
2. Rename to "DialoguePanel"
3. Set anchors to center
4. Set size to (600, 300)
5. Set background color to semi-transparent black

#### Add Dialogue Text (inside DialoguePanel)
1. Right-click DialoguePanel → UI → TextMeshPro - Text
2. Rename to "DialogueText"
3. Set to stretch (fill panel)
4. Font Size: 32
5. Add Layout Group: Vertical Layout Group

#### Add Next Button (inside DialoguePanel)
1. Right-click DialoguePanel → UI → Button - TextMeshPro
2. Rename to "NextButton"
3. Position at bottom of panel
4. Change text to "Next >"

### Step 5: Add GameManager

1. Create empty GameObject named "GameManager"
2. Add the GameManager script
3. Set Debug Mode: True
4. Set Game Title: "Your Game Name"

### Step 6: Add InteractionManager

1. Create empty GameObject named "InteractionManager"
2. Add InteractionManager script from Assets/Scripts/Interactions/

### Step 7: Add PlayerController

1. Create empty GameObject named "PlayerController"
2. Add PlayerController script
3. In Inspector, assign Main Camera to Camera field
4. Set Raycast Distance: 100

### Step 8: Add UIManager

1. Right-click Canvas
2. Add UIManager script
3. In Inspector, assign:
   - Feedback Text: Drag "FeedbackText" from hierarchy
   - Feedback Canvas Group: Should auto-detect
   - Dialogue Text: Drag "DialogueText"
   - Dialogue Panel: Drag "DialoguePanel"
   - Next Dialogue Button: Drag "NextButton"

### Step 9: Create Interactable Objects

1. Create a new 2D sprite (or import a sprite)
2. Create GameObject with the sprite
3. Add BoxCollider2D component
4. Add Interactable script
5. In Inspector:
   - Interactable Name: "Door" (or your object name)
   - Interaction Description: "Click to open"
   - Highlight Color: Yellow
   - Play Animation: True
   - On Interact: Add callback (optional)

### Step 10: Test the Scene

1. Press Play
2. Try clicking on interactable objects
3. You should see:
   - Objects highlight on hover
   - Objects scale when clicked
   - Feedback text appears
   - Console logs the interaction

## Mobile Build Settings

For mobile deployment:

1. Go to **File** → **Build Settings**
2. Select platform:
   - iOS (for Apple devices)
   - Android (for Android devices)
3. Player Settings:
   - Orientation: Portrait
   - Resolution: Mobile resolutions
   - Input: Touch enabled

## Troubleshooting

| Issue | Solution |
|-------|----------|
| Objects not responding to clicks | Ensure BoxCollider2D is on the object and enabled |
| Feedback text not showing | Check UIManager references in Inspector |
| Touch input not working | Check Input Manager in Project Settings |
| Objects not highlighted | Ensure SpriteRenderer is on the object |

## Next Steps

- Add background art and sprites
- Create more interactive objects
- Add sound effects
- Implement inventory system
- Create level progression
