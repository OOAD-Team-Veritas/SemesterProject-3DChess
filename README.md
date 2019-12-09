# SemesterProject-3DChess
Semester project for OOAD - A 3D Chess game made in Unity3D and coded using C#

## Team Members
- Riad Shash (Ray) [GitHub](https://github.com/Blackbird002) 
- Elizabeth Robinson [GitHub](https://github.com/elizrobinson)
- Joshua Khoo [GitHub](https://github.com/joshua-khoo)

### Source of 3D assets
- Chess Pieces & board from: https://www.raywenderlich.com/

### Pattern Usage
- *Factory Pattern*: ChessPieceFactory is a factory that can create chessPieces from a set of prefabs. There are many convenient functions to easily create and place chess pieces on the board. This was helpful not only in setting up the chess board, but also for pawn promotion. 
- *Observer Pattern*: Observer pattern was implemented so many classes can observe the current player turn. In this case the subject is ChessGame (the main class that handles the actual chess game) while ChessGameTimer & BoardLogic are the observers. 
  
## Release (Windows bulid)
Download and unzip the `3D.Chess.OOAD.zip` file. Open the directory and click on `3D Chess.exe` to run the program.

[Pre-release](https://github.com/OOAD-Team-Veritas/SemesterProject-3DChess/releases)

## C# Classes/Scripts source code

[Source Code](https://github.com/OOAD-Team-Veritas/SemesterProject-3DChess/tree/master/OOAD%20Chess/Assets/Scripts)