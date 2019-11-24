module MultiSel.Program

open System
open Elmish
open Elmish.WPF

module App =

    type Model =
        {
            Dummy: string
        }

    let init () =
        {
            Dummy = ""
        }

    type Msg =
        | Dummy

    let update msg m =
        match msg with
        | Dummy -> m

    let bindings () : Binding<Model, Msg> list = [
        "Dummy" |> Binding.cmd Dummy
    ]

[<EntryPoint; STAThread>]
let main _ =
    Program.mkSimpleWpf App.init App.update App.bindings
    |> Program.withConsoleTrace
    |> Program.runWindowWithConfig
        { ElmConfig.Default with LogConsole = true; Measure = true }
        (Views.MainWindow())
