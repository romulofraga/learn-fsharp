(*
    Function-oriented rather than object-oriented
    Expressions rather than statements
    Algebraic types for creating domain models
    Pattern matching for flow of control
  *)

(*
    Function-oriented rather than object-oriented
  *)
let square x = x * x

// functions as values
let squareclone = square
let result = [ 1..10 ] |> List.map squareclone

// functions taking other functions as parameters
let execFunction aFunc aParam = aFunc aParam
let result2 = execFunction square 12

(*
  Expressions rather than statements

// expression-based code in C#
int result = (aBool) ? 42 : 0;
Console.WriteLine("result={0}", result);
*)

(*
  Algebraic Types
*)

//declare it
type IntAndBool = { intPart: int; boolPart: bool }

//use it
let x = { intPart = 1; boolPart = false }

//declare it
type IntOrBool =
    | IntChoice of int
    | BoolChoice of bool

//use it
let y = IntChoice 42
let z = BoolChoice true

let v = (IntChoice 23, BoolChoice false)

(*
  Pattern matching for flow of control
*)

// if-else
let booleanExpression = false

match booleanExpression with
| true -> ignore // true branch
| false -> ignore // false branch

//switch
let aDigit = 33

match aDigit with
| 1 -> ignore // Case when digit=1
| 2 -> ignore // Case when digit=2
| _ -> ignore // Case otherwise

//loops (generally using recursion)
let aList = [ 1..100 ]

match aList with
| [] -> ignore
// Empty case
| first :: rest -> ignore
// Case with at least one element.
// Process first element, and then call
// recursively with the rest of the list

(*
Pattern matching with union types
*)

type Shape = // define a "union" of alternative structures
    | Circle of radius: int
    | Rectangle of height: int * width: int
    | Point of x: int * y: int
    | Polygon of pointList: (int * int) list

let draw shape = // define a function "draw" with a shape param
    match shape with
    | Circle radius -> printfn "The circle has a radius of %d" radius
    | Rectangle(height, width) -> printfn "The rectangle is %d high by %d wide" height width
    | Polygon points -> printfn "The polygon is made of these points %A" points
    | _ -> printfn "I don't recognize this shape"

let circle = Circle(10)
let rect = Rectangle(4, 5)
let point = Point(2, 3)
let polygon = Polygon([ (1, 1); (2, 2); (3, 3) ])

[ circle; rect; polygon; point ] |> List.iter draw
