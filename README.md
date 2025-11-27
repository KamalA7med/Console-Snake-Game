# Snack Game 🐍

A generic, Object-Oriented console-based implementation of the classic "Snake" arcade game, written in C#.

## 📝 Description

Snack Game is a C# console application where the player controls a "Snack" (snake) moving around a grid. The objective is to eat "Apples" to grow in length and increase your score. The game ends if the player collides with the border walls or obstacles.

This project demonstrates the use of *Object-Oriented Programming (OOP)* principles, including:
* *Inheritance:* (e.g., Apple inherits from Object)
* *Encapsulation:* (Logic separated into Game, Grid, and Snack classes)
* *Game Loop Logic:* Handling rendering, input, and updates in real-time.

## 🎮 How to Play

1.  *Start the Game:* Run the application.
2.  *Controls:* Use the *Arrow Keys* to change direction:
    * ⬆ *Up Arrow*: Move Up
    * ⬇ *Down Arrow*: Move Down
    * ⬅ *Left Arrow*: Move Left
    * ➡ *Right Arrow*: Move Right
3.  *Objective:* Navigate the grid to eat the Apples (represented by A).
4.  *Game Over:* The game ends if you hit the border walls (represented by X) or solid obstacles.

## ⚙ Features

* *Dynamic Grid System:* A configurable 2D array representing the game map.
* *Score Tracking:* Real-time score updates displayed in the console header.
* *Collision Detection:* Checks for boundary violations and self-collision.
* *Growing Mechanic:* The snake increases in length every time an apple is consumed.
* *Configurable Settings:* Frame delay, grid size, and symbols can be adjusted in Program.cs.

## 📂 Project Structure

* **Program.cs**: The entry point. Configures game settings (Grid size, symbols, speed) and initializes the game.
* **Game.cs**: The core engine. Manages the game loop, draws the grid, handles input, and manages game states (Score, Game Over).
* **Snack.cs**: Represents the player. Handles movement logic and history tracking (tail growth).
* **Grid.cs**: Manages the game board dimensions and the array of objects within it.
* **Object.cs**: The base class for all items on the grid (Walls, Empty Space, Apples).
* **Apple.cs**: Inherits from Object, representing the food items.

## 🛠 Installation & Setup

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended).
* An IDE like *Visual Studio* or *VS Code*.

### Running the App
1.  *Clone the repository:*
    bash
    git clone [https://github.com/your-username/Snack-Game.git](https://github.com/your-username/Snack-Game.git)
    
2.  *Navigate to the project directory:*
    bash
    cd Snack-Game
    
3.  *Run the application:*
    bash
    dotnet run
    

## 🔮 Future Improvements

* *Fix Flickering:* Implement a smoother rendering technique instead of constantly using Console.Clear().
* *High Score:* Save the highest score to a text file.

## 📜 License

This project is open-source and available for educational purposes.
