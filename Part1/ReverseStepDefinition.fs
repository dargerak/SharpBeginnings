module ReverseDefinition

open System
open TickSpec
open NUnit.Framework
open FsUnit

let reverse (str:string) = 
  //todo: implement algorithm to reverse a string
  let a = str.ToCharArray()
  let b = Array.rev a
  new String(b)
  
let mutable storedString = ""

let [<Given>] ``a reversable string (.*)`` (str:string)= 
    storedString <- str
      
let [<When>] ``I reverse it`` () = 
    let newStr = reverse storedString
    storedString <- newStr 

let [<Then>] ``the reversed string should be (.*)`` (expected:string) =  
    Assert.AreEqual(expected,storedString)
