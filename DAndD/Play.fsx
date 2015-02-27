#load "Model.fs"
#load "Impl.fs"
#load "View.fs"

open DAndD.Model
open DAndD.Impl

let g = createGame (10,10)

DAndD.View.showGame g

