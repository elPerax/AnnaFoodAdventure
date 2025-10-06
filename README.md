# 🍭 Anna’s Food Adventure

A 2D Unity platformer game created as a fun birthday project!  
Play as **Anna**, a character inspired by my friend, who defends herself against snowguns that shoot broccoli 🥦 while collecting candies 🍬 and junk food 🍩 to score Aura points.  

The game evolved from a series of academic Unity assignments into a full, polished **platform-based WebGL game** with physics, sound, animation, and visual effects.

🎮 **Play it online:**  
 [https://elperaxx8000.itch.io/anna-food-adventure](https://elperaxx8000.itch.io/anna-food-adventure)

---

##  Gameplay Overview

-  Explore a snowy world full of candy and chaos  
-  Dodge broccoli snowballs fired from snowguns  
-  Collect junk food and candies to increase your Aura points  
-  Avoid Mangoes, they reduce your points even if they're delicious  
-  Enjoy background music, jump sounds, splash effects, and more  
-  Experience realistic rain, water splashes, and dynamic animation  

---

##  Key Features

###  2D Environment & Animation
- Built using **Unity 2022 (2D)** with **Tilemap-based platforms**  
- Animated character with separate walking, jumping, and landing animations  
- Two-directional movement + jump controlled by **Rigidbody2D physics**  
- **Snowgun projectiles** follow randomized trajectories and speeds  

###  Platform & Physics
- RigidBody2D and BoxCollider2D for platforms, player, and obstacles  
- Broken paths, mini hills, and waterfalls built with a custom snowy tilemap  
- Player dies if:
  - Falling off the platform
  - Touching a waterfall
  - Colliding with a snowball  

###  Balloon & Scoring System
- Food appears randomly on the platform  
- **Food gives you** = +1 point  
- **Mangoes sadly take points from you** = −3 points
- **Broccoli** is so healthy that it kills on touch
- Real-time score display + saved score history  
- Player name input and high-score leaderboard (descending order)  

###  Menu & UI
- **Landing Page** with:
  - New Game  
  - Save/Resume Game  
  - High Scores  
  - Exit Game  
- **In-Game Menus:**
  - Pause / Resume / Restart  
- **Live score UI** and end-game screen  

###  Audio & Effects
- `music_1` — main menu background music (looped)  
- `music_2` — in-game background music (looped until game ends)  
- `jump_sound` — when Anna jumps  
- `splash_effect` — when Anna lands on wet ground  
- `yellow_collect_effect` — for collecting good food  
- `black_collect_effect` — for collecting bad food  
- `game_over_effect` — when Anna dies  
- Rain particle system with medium intensity  
- Controlled splash particle system triggered via collision scripts  

---

##  Technologies Used

| Category | Tool / Feature |
|-----------|----------------|
| Engine | Unity 2022 (2D) |
| Language | C# |
| Physics | Rigidbody2D, BoxCollider2D, PolygonCollider2D |
| Environment | Tilemap System |
| Audio | Unity AudioSource, AudioClip |
| UI | Unity Canvas, TextMeshPro |
| VFX | Particle System (Rain & Splash) |
| Build | WebGL |
| Version Control | Git + Git LFS |
| IDE | Unity Hub + Visual Studio |

---

##  How to Run Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/Annas-Food-Adventure.git
