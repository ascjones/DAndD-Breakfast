namespace DAndD

module View = 

    open System
    open DAndD.Model
    
    let showGame game =
        let cells = game.Grid
        let height = cells.GetLength(0)
        let width = cells.GetLength(1)

        let charToCell cell = 
            match cell with
            | Empty -> ' '
            | Blocked -> '#'
            | ContainsItem item ->
                match item with
                | Bone -> 'B'
                | Scroll -> 'S'
                | Coin -> 'G'

        let cellsStr = seq {
            // top
            for y in [0..height - 1] do
                for x in [0..width - 1] do
                    let char = cells.[x,y] |> charToCell
                    let sep =    
                        if x < width - 1 then " " 
                        else Environment.NewLine 
                    yield sprintf "%c%s" char sep }

        String.Join("", cellsStr) 

        
         



