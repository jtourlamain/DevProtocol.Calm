module DevProtocol.Calm.Arm
open DevProtocol.Calm.Domain
open System.Text
open DevProtocol.Calm.Json
open System.IO


type TemplateList = {
    value : string list
    }

let templateDirectory =
    Path.Combine(__SOURCE_DIRECTORY__,"templates")

let readTemplate templateName =
    let content = System.IO.File.ReadAllText(Path.Combine(templateDirectory,  templateName + ".txt"))
    content

let createDelimitedList (items : seq<string>) (delim : string) =
    let buff = 
        Seq.fold 
            (fun (buff :StringBuilder) (s:string) -> buff.Append( "\""  + s + "\"").Append(delim)) 
            (StringBuilder()) 
            items
    buff.Remove(buff.Length-delim.Length, delim.Length).ToString()

let createTemplatePropertyList propertyName propertyValues =
    let startToken = ",\"" + propertyName + "\":"
    let tokenValue = serialize {value = propertyValues} 
    startToken + tokenValue

let changeTokenInTemplate (templateObject:option<'a>) (templateValue:'a -> string) token (defaultName:string) (content:string) =
    match templateObject with
        | None -> content.Replace(token, defaultName)
        | Some x -> content.Replace(token, templateValue x)

let generateStorageTemplateContent (resource:StorageResource) (defaultDependencies:string list) (template:string) = 
    let dependencies = 
        match resource.Dependencies with
        | None -> defaultDependencies
        | Some x -> defaultDependencies @ x
    template
    |> changeTokenInTemplate resource.TemplateName (fun x -> "" + x) resource.TemplateNameToken resource.DefaultTemplateName 
    |> changeTokenInTemplate resource.BlobNames (fun x -> createTemplatePropertyList resource.BlobsTemplatePropertyName x) resource.BlobsTemplateToken ""
    |> changeTokenInTemplate (Some dependencies) (fun x -> createDelimitedList x ",") resource.DependenciesToken ""

let generateSqlTemplateContent (resource:SqlResource) (defaultDependencies:string list) (template:string) =
    let dependencies = 
        match resource.Dependencies with
        | None -> defaultDependencies
        | Some x -> defaultDependencies @ x
    template
    |> changeTokenInTemplate resource.TemplateName (fun x -> "" + x) resource.TemplateNameToken resource.DefaultTemplateName
    |> changeTokenInTemplate (Some resource.AdminLogin) (fun x -> "" + x) resource.AdminLoginToken resource.AdminLogin
    |> changeTokenInTemplate (Some resource.AdminPassword) (fun x -> "" + x) resource.AdminPasswordToken resource.AdminPassword
    |> changeTokenInTemplate (Some dependencies) (fun x -> createDelimitedList x ",") resource.DependenciesToken "" 

