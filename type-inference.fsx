let Where source predicate = Seq.filter predicate source

let GroupBy source keySelector = Seq.groupBy keySelector source

(*
    in C# the implementation
    public IEnumerable<TSource> Where<TSource>(
    IEnumerable<TSource> source,
    Func<TSource, bool> predicate
    )
{
    //use the standard LINQ implementation
    return source.Where(predicate);
}

    public IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
    IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector
    )
{
    //use the standard LINQ implementation
    return source.GroupBy(keySelector);
}

*)

let seq = { 1..100 }

let isOdd x =
    match x % 2 with
    | 0 -> true
    | _ -> false

Where seq isOdd

let i = 1
let s = "hello"
let tuple = s, i // pack into tuple
let s2, i2 = tuple // unpack
let list = [ s2 ] // type is string list

let sumLengths strList =
    strList |> List.map String.length |> List.sum
