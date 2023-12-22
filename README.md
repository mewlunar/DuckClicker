# Duck clicker

Finished game - [game]

1. Gameplay:

    * The game is implemented as a clicker using Unity, C# and DOTween.
    * The user interface is adaptive, for horizontal position.

2. Graphics and Animations:

    * 2D graphics created in PNG format for each of the 16 duck guises using the Bing neural network.
    * Animations of the background elements are made with DOTween

3. Economy and Currency:

    * Coins are the virtual currency in the game, stored in a singleton object to save progress between sessions.
    * The base value of click and auto-click is customizable to balance cost and performance.

4. Progress and Levels:

    * The level system is implemented using an algorithm that takes into account the level of experience and ongoing improvements.
    * Each level is represented as an object containing information about the required experience and changes in difficulty.

5. Enhancements and Upgrades:

    * Click and auto-click upgrades are implemented as separate modules that support dynamic feature upgrades.
    * Event systems are used to communicate between different components of the game.

6. Difficulty and Progression:

    * The algorithm for calculating the difficulty of levels takes into account the player's current level and progress.
    * The difficulty increases linearly, requiring constant improvements to progress.

7. Autosave and Persistence:

    * The autosave mechanism ensures that your game progress, including coin count, duck level and improvements, is saved even after closing your browser.

8. Multi-platform:

    * The game is optimized to run on a variety of devices including desktops, tablets and mobile devices using responsive design.

9. Sound and Music:

    * Sound effects when a duck is clicked and when a new level is reached provide audio-visual interaction.
    * Optional support for background music to enhance the atmosphere of the game.


[game]: https://yandex.ru/games/app/276575#app-id=276575
