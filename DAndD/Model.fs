namespace DAndD

module Model =
    
    type Item = 
        | Bone
        | Coin
        | Scroll

    type Orientation = 
        | North
        | South
        | East
        | West

    type Player = 
        { Id : PlayerId 
          Inventory : Item list
          Location : Coord 
          Orientation : Orientation }
    and Coord = { X : int; Y : int }
    and PlayerId = PlayerId of int

    type Cell = 
        | Blocked
        | Empty
        | ContainsItem of Item

    type Game = 
        { Grid : Cell [,] 
          Players : Player list 
          Status : GameStatus }
    and GameStatus = InProgress | PlayerWon of PlayerId

    //
    // API


    type Direction = Left | Right

    type PlayerCommand = 
        | Turn of Direction
        | Move

    type Handle = (PlayerId * Game * PlayerCommand) -> (Cell * Game)

    type NewGame = (int * int) -> Game


