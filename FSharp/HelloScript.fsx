"f#" // single line comments use a double slash; String expression
(* multi line comments use (* . . . *) pair -end of multi line comment- *)
(*
    Variable and Binding
    The "let" keyword defines an (immutable) value
*)
let myInt = 5
let myFloat = 3.14
let myString = "hello"



(* Conditional expression and logical operator *)
if 3 < 4 then 117 else 118



(*
    Lists
    Square brackets create a list with semicolon/new line delimiters
*)
let twoToFive = [ 2; 3; 4; 5 ]


(* :: creates list with new 1st element *)
let oneToFive = 1 :: twoToFive


(* @ concats two lists *)
let zeroToFive = [ 0; 1 ] @ twoToFive



(* Pairs and tuples, product types *)
let twoTuple = 1, 2
let twoTuple2 = (1, 2)
let threeTuple = ("a", 2, true)


(* The empty tuple () of type unit, similar to void in C# and Java *)
()



(*
    Record
    Record types have named fields, Semicolons are separators
*)
type Person = { First: string; Last: string }
let person1 = { First = "john"; Last = "Doe" }



(*
    Union
    Union types have choices, vertical bars are separators
*)
type MeasurementUnit = Cm | Inch | Mile 

type Name = 
    | Nickname of string 
    | FirstLast of string * string

type Tree<'a> = 
    | E 
    | T of Tree<'a> * 'a * Tree<'a>

let u = Inch
let name = Nickname("John")
let t = T(E,"John",E)	



(* Enum *)
type Gender = | Male = 1 | Female = 2

let g = Gender.Male



(* 
    Class 
    'new' keyword for secondary constructors
    'member' keyword for defining members
*)
type Product (code:string, price:float) = 
   let isFree = price=0.0 
   
   new (code) = Product(code,0.0)
   
   member this.Code = code 
   member this.IsFree = isFree


let p = Product("X123",9.99)
let p2 = Product("X123")



(*
    Inteface
    Same as class but all members are abstract
    Abstract members have colon and type signature
*)
type IPrintable =
   abstract member Print : unit -> unit



(*
    Struct
    Uses "val" to define fields
*)
type Product= 
   struct  
      val code:string
      val price:float
      new(code) = { code = code; price = 0.0 }
   end
   
let p = Product()
let p2 = Product("X123")



(*
    Function
    The "let" keyword also defines a named function
    In F# returns are implicit -- no "return" needed.
    A function always returns the value of the last expression used
*)
let square x = x * x
square 3


let add x y = x + y
add 2 3


(*
    'Curried Functions' vs 'Function on product type'
    int -> int -> int versus int * int -> int
*)
let addp (x, y) = x + y
let addc x y = x + y

let res1 = addp (17, 25)
let res2 = addc 17 25

let addSeventeen = addc 17
let res3 = addSeventeen 25
let res4 = addSeventeen 100


(*
    Multiline Function
    Multiline function are defined using use indents; No semicolons needed
*)
let evens list =
    let isEven x = x % 2 = 0
    List.filter isEven list
evens oneToFive


(* Higher-order functions *)
let rec map f xs =
    match xs with
    | [] -> []
    | x :: xr -> f x :: map f xr
let mul2 x = 2.0 * x

map mul2 [ 4.0; 5.0; 89.0 ]


(* Recursive function declarations *)
let rec fac n = if n = 0 then 1 else n * fac (n - 1)
fac 7


(* Mutually recursive function declarations *)
let rec even n = if n = 0 then true else odd (n - 1)
and odd n = if n = 0 then false else even (n - 1)

even 10
odd 10



(* Type constraints *)
let isLarge (x: float): bool = 10.0 < x
isLarge 89.0


(* Local let-binding *)
let x = 42

let r =
    let x = 9 + 16
    x * x

r, x


(*
    You can use parens to clarify precedence.
    In this example, do "map" first, with two args, then do "sum" on the result
    Without the parens, "List.map" would be passed as an arg to List.sum
*)
let sumOfSquaresTo100 = List.sum (List.map square [ 1 .. 100 ])


(*
    Pipe
    You can pipe the output of one operation to the next using "|>"
*)
let sumOfSquaresTo100piped =
    [ 1 .. 100 ] |> List.map square |> List.sum


(*
    Anonymous functions
    You can define anonymous functions using the "fun" keyword
*)
let sumOfSquaresTo100withFun =
    [ 1 .. 100 ]
    |> List.map (fun x -> x * x)
    |> List.sum



(* Pattern Matching *)

let simplePatternMatch =
    let x = "a"
    match x with
    | "a" -> printfn "x is a"
    | "b" -> printfn "x is b"
    | _ -> printfn "x is something else"


(* Anonymous function defined by pattern matching *)

let rec faca =
    function
    | 0 -> 1
    | n -> n * faca (n - 1)
faca 7



(* Options *)
let validValue = Some(99)
let invalidValue = None

let optionPatternMatch input =
    match input with
    | Some i -> printfn "input is an int=%d" i
    | None -> printfn "input is missing"

optionPatternMatch validValue
optionPatternMatch invalidValue



(*
    Modules
    Modules are used to group functions together
    Indentation is needed for each nested module.
*)
module ModuleExamples =
    let add x y = x + y
    let a = add 1 2

ModuleExamples.a



(*
    Printing
    The printf/printfn functions are similar to the
    Console.Write/WriteLine functions in C#
*)

printfn "Printing an int %i, a float %f, a bool %b" 1 2.0 true
printfn "A string %s, and something generic %A" "hello" [ 1; 2; 3; 4 ]

(* All complex types have pretty printing built in *)
printfn "twoTuple=%A,\nPerson=%A,\nTemp=%A,\nEmployee=%A" twoTuple person1 temp worker



(* Exceptions *)

exception IllegalHour

let mins1 h =
    if h < 0 || h > 23 then raise IllegalHour else h * 60

try
    (mins1 25)
with IllegalHour -> -1



(* Arrays *)
let arr = [| 2; 5; 7 |]
arr.[1]

arr.[1] <- 11

arr

arr.Length



(*
    Assignment
    '<-' Assigns a value to a variable
*)
let mutable mutableInt = 5
mutableInt <- 7
mutableInt



(* References and updatable state *)

let r = ref 177

let v = !r

r := 288

!r



(* Using methods from the .NET class library *)

open System

let z = Math.Sqrt 2.0



(* .NET types and functions *)

let tomorrow =
    let nationalDebt = 14349539503882.02M
    let perSecond = 45138.89M
    nationalDebt + 86400M * perSecond


let rec fac (n: bigint) = if n = 0I then 1I else n * fac (n - 1I)

fac 104I