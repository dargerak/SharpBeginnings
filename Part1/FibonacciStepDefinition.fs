module FibonacciStepDefinition

open TickSpec
open NUnit.Framework
open FsUnit

let mutable resultSet:int seq = {0..1}
let mutable fibonnaciNumber:int = -1
let upperBound = 10000

let rec fibonnaci number = 
   match number with
   | 1-> 1
   | 2 -> 1
   | _ ->  fibonnaci (number - 1) + fibonnaci (number - 2)

let fibonnaciSequence n=
  {1..1000}
  |> Seq.map (fun x -> fibonnaci x) 
  |> Seq.take n
    
let [<Given>] ``a fibonacci sequence calculator`` ()= 
    ()
      
let [<When>] ``I ask for the first (.*) numbers in the sequence`` (n:int) =  
    resultSet <- fibonnaciSequence n
   
let [<When>] ``I ask for the Fibonacci number of (.*)`` (n:int) =  
    fibonnaciNumber <- fibonnaci n

let [<Then>] ``the fib result should be (.*)`` (expected:int) =  
    Assert.AreEqual(expected, fibonnaciNumber)

let [<Then>] ``the fib set should contain (.*)`` (expected:int) =  
    let doesExist=resultSet|> Seq.exists (fun x-> x = expected)
    Assert.IsTrue(doesExist, "Could not find it")

let [<Then>] ``the fib result set length should be (.*)`` (len:int) =  
    let cnt = Seq.length resultSet
    Assert.AreEqual(len, cnt)
