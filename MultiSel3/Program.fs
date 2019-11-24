module MultiSel3.Program

open System
open Elmish
open Elmish.WPF

module App =

    type Line =
        {
            Id: Guid
            Marked: bool
            DisplayText: string
        }

    type Model =
        {
            Lines: Line list
        }

    let init () =
        let line marked text = { Id = Guid.NewGuid(); Marked = marked; DisplayText = text }
        {
            Lines = [
                line false "Zero"
                line true "One"
                line true "Two"
                line false "Three"
                line true "Four"
                line true "Five"
                line false "Six"
            ]
        }, Cmd.none

    type Msg =
        | SetMarked of Guid * bool
        | Checked of Guid
        | Unchecked of Guid

    let update msg m =
        match msg with
        | SetMarked (id, marked) ->
            let lines = m.Lines |> List.map (fun line ->
                if line.Id = id then { line with Marked = marked } else line)
            { m with Lines = lines }, Cmd.none
        | Checked id ->
            let lines = m.Lines |> List.map (fun line ->
                if line.Id = id then { line with Marked = true } else line)
            { m with Lines = lines }, Cmd.none
        | Unchecked id ->
            let lines = m.Lines |> List.map (fun line ->
                if line.Id = id then { line with Marked = false } else line)
            { m with Lines = lines }, Cmd.none

    let bindings () : Binding<Model, Msg> list = [
        "Lines" |> Binding.subModelSeq((fun m -> m.Lines), (fun line -> line.Id), fun () ->
            [
                "Id" |> Binding.oneWay (fun (_, line) -> line.Id)
                "DisplayText" |> Binding.oneWay (fun (_, line) ->
                    line.DisplayText + (if line.Marked then " is checked" else " is not checked"))
                "Checked" |> Binding.cmdParam (fun id -> Checked (id :?> Guid))
                "Unchecked" |> Binding.cmdParam (fun id -> Unchecked (id :?> Guid))
            ])
    ]

[<EntryPoint; STAThread>]
let main _ =
    Program.mkProgramWpf App.init App.update App.bindings
    |> Program.withConsoleTrace
    |> Program.runWindowWithConfig
        { ElmConfig.Default with LogConsole = true; Measure = true }
        (Views.MainWindow())
