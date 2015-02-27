namespace DAndD

module Impl = 
    
    open DAndD.Model

    let private newGame (n,m) = 
        let cells = 
            let rand = new System.Random ()
            let width,height = n + 2,m + 2
            Array2D.init width height (fun x y -> 
                if x = 0 || x = width - 1 || y = 0 || y = height - 1 then 
                    Blocked // draw the wall
                else
                    match rand.Next(5) with
                    | 0 -> Empty
                    | 1 -> Blocked
                    | 2 -> ContainsItem (Bone)
                    | 3 -> ContainsItem (Coin)
                    | 4 -> ContainsItem (Scroll)
                    | x -> failwithf "Expected < 5 from Random, got %i" x)

        { Grid = cells; Players = []; Status = InProgress }

    let createGame : NewGame = newGame

    let newOrientation direction orientation = East

    let handle (playerId,g,command) = 
        match command with 
        | Turn direction -> 
            let player = g.Players |> List.tryFind (fun p -> p.Id = playerId)
            match player with
            | Some p -> 
                let orientation = newOrientation direction p.Orientation
                let newPlayers =
                    g.Players
                    |> List.map (fun p2 -> 
                        if p2 = p then { p2 with Orientation = orientation }
                        else p2)
                { g with Players = newPlayers }
            | None -> failwithf "Couldn't find player %A" playerId
        | x -> failwithf "Not implemented command %A" x

    

