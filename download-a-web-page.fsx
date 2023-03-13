// "open" brings a .NET namespace into visibility
open System
open System.Net
open System.Net.Http

// Fetch the contents of a web page
let fetchUrl callback url =
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    callback reader url

let myCallback (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()
    let html1000 = html.Substring(0,1000)
    printfn "Downloaded %s. First 1000 is %s" url html1000
    html      // return all the html

//test
let google = fetchUrl myCallback "http://google.com"

let fetchUrl2 callback url =
    let client = new HttpClient()
    use resp = client.GetStreamAsync(Uri(url)) 
    use reader = new IO.StreamReader(resp.Result)
    callback reader url 

let myCallback2 (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()
    let html1000 = html.Substring(0,1000)
    printfn "Downloaded %s. First 1000 is %s" url html1000
    html      // return all the html

//test
let google2 = fetchUrl2 myCallback2 "http://google.com"

//bake in function
let fetchUrlBaked = fetchUrl2 myCallback2

let face = fetchUrlBaked "https://facebook.com"
let bbc = fetchUrlBaked "https://bbc.co"

//with a list of sites
let sites = [
    "http://www.bing.com";
    "http://www.google.com";
    "http://www.yahoo.com"
]

//process each sinte in the list
sites |> List.map fetchUrlBaked

