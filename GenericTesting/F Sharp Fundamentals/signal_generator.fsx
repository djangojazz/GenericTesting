#load "D:\GitCode\GenericTesting\GenericTesting\packages\FSharp.Charting.0.90.14\FSharp.Charting.fsx"

open FSharp.Charting

let generateSamples milliseconds frequency = 
    let sampleRate = 44100.
    let sixteenBitSampleLimit = 32767.
    let volume = 0.8
    let toAmplitude x =
        x 
        |> (*) (2. * System.Math.PI * frequency / sampleRate)
        |> sin
        |> (*) sixteenBitSampleLimit
        |> (*) volume
        |> int16

    let numOfSamples = milliseconds / 1000. * sampleRate
    let requiredSamples = seq { 1.0..numOfSamples}
    Seq.map toAmplitude requiredSamples
    
let points = generateSamples 150. 440.
points |> Chart.Line
()