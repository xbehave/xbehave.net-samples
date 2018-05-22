﻿// QuickStart sample conversion to F# from C# with some helper functions
// based on http://fssnip.net/kn by Phillip Trelford http://trelford.com/blog
namespace Xbehave.Samples.FSharp

module Pipes =
    open Xbehave
    open Xunit

    // helper functions
    let Given f (s:string) = s.f(System.Action< >(f)) |> ignore
    let And f (s:string) = s.f(System.Action< >(f)) |> ignore
    let But f (s:string) = s.f(System.Action< >(f)) |> ignore
    let When f (s:string) = s.f(System.Action< >(f)) |> ignore
    let Then f (s:string) = s.f(System.Action< >(f)) |> ignore

    // SUT
    type Calculator () = member __.Add(x,y) = x + y

    [<Scenario>]
    let addition(x:int, y:int, calculator:Calculator, answer:int) =
        let x, y, calculator, answer = ref x, ref y, ref calculator, ref answer

        "Given the number 1"
            |> Given (fun () -> x := 1)

        "And the number 2"
            |> And (fun () -> y := 2)

        "And a calculator"
            |> And (fun () -> calculator := Calculator())

        "When I add the numbers together"
            |> When (fun () -> answer := (!calculator).Add(!x, !y))

        "Then the answer is 3"
            |> Then (fun () -> Assert.Equal(3, !answer))
