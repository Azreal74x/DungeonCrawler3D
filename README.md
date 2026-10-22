**Thanks for checking out my Dungeon Crawler 3D project!**
I developed this project on my own using C#, Unity, and free assets. My main goal was to create a simple 3D dungeon crawler while focusing on clean, reusable, and organized code. Have a look at the details below. 


**Reusable components:**
Both the player and different enemies share the same Health and HealthBar scripts, avoiding unnecessary duplicate code.

**Strategy Pattern:**
Each enemy type has its own attack and movement behavior, implemented using interfaces and ScriptableObjects.

**Observer Pattern:**
Events allow different scripts to react when needed. For example, an enemy's death triggers its death animation, item drops, XP rewards, and quest progress.

**Prefabs:**
Enemies, projectiles, and other objects are instantiated and destroyed through scripts when needed.


**Important! Unity Input System**
When opening the project, Unity may ask you to enable the new Input System backends. Please select "No", as this project uses Unity's old Input Manager instead.
