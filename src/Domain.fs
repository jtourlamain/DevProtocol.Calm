namespace DevProtocol.Calm.Domain

type CompanyName = CompanyName of string

type ProjectName = ProjectName of string

type ArmTemplatesUrl = ArmTemplatesUrl of string

type EnvironmentName = 
| Development
| Acceptance
| Production

type EnvironmentSize = 
| Small
| Medium
| Large

type StorageResource = {
    TemplateName : string option
    BlobNames : string list option
    Dependencies : string list option
    } with
    member this.DefaultTemplateName = "storageTemplate"
    member this.TemplateNameToken = "$$$TemplateName$$$"
    member this.BlobsTemplateToken = "$$$BlobNames$$$"
    member this.BlobsTemplatePropertyName = "blobNames"
    member this.DependenciesToken = "$$$Dependencies$$$"

type SqlResource = {
    TemplateName : string option
    DatabaseNames : string list option
    AdminLogin : string
    AdminPassword : string
    Dependencies :string list option
    } with
    member this.DefaultTemplateName = "sqlServerTemplate"
    member this.TemplateNameToken = "$$$TemplateName$$$"
    member this.AdminLoginToken = "$$$AdminLogin$$$"
    member this.AdminPasswordToken = "$$$AdminPassword$$$"
    member this.DatabasesTemplateToken = "$$$Databases$$$"
    member this.DatabasesTemplatePropertyName = "databases"
    member this.DependenciesToken = "$$$Dependencies$$$"

type ArmResource = 
| StorageResource of StorageResource
| SqlResource of SqlResource


type CalmProject = {
    CompanyName : CompanyName 
    ProjectName : ProjectName
    ArmTemplatesUrl : ArmTemplatesUrl
    EnvironmentName : EnvironmentName
    EnvironmentSize : EnvironmentSize 
    ArmResources : ArmResource list
    } with
    member this.DefaultDependencies = ["configurationTemplate";"namingconventionTemplate"]
    member this.DefaultResourceName = "[reference('namingconventionTemplate').outputs.defaultNames.value.$$$resourceName$$$]"
    member this.ResourceNameToken = "$$$resourceName$$$"
 
