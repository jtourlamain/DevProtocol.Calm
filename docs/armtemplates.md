# Arm templates
 
<!-- TOC -->

- [Arm templates](#arm-templates)
    - [Default naming conventions](#default-naming-conventions)
        - [EnvironmentAffix](#environmentaffix)
        - [role](#role)
        - [resource](#resource)
    - [Composition template](#composition-template)
        - [Input parameters](#input-parameters)
    - [Naming convention template](#naming-convention-template)
        - [Input parameters](#input-parameters-1)
        - [Output parameters](#output-parameters)
    - [App service plan template](#app-service-plan-template)
        - [Input parameters](#input-parameters-2)
    - [Web app template](#web-app-template)
        - [Input parameters](#input-parameters-3)
        - [Output parameters](#output-parameters-1)
    - [Api app template](#api-app-template)
        - [Input parameters](#input-parameters-4)
        - [Output parameters](#output-parameters-2)

<!-- /TOC -->

## Default naming conventions

```
<companyName>-<projectName><environmentAffix>-[<role>]<resource>
```

### EnvironmentAffix

| environmentAffix | description |
|:--|---|
| -poc | poc |
| -d | development |
| -a | acceptance |
| | production |

### role

|role|description|
|:--- |---|
|web|web application|
|api|api application|

### resource

|resource|description|
|:---:|:--- |
|sub|subscription|
|rg|resource group|
| akv | azure keyvault |
| asp | app service plan |
| wa | web app |
| fa | function app |
| sbs | service bus |
| st | storage |
| sql | sql server |

## Composition template

Can be used as example to compose arm deployments

### Input parameters

- companyName
  - minLength = 3
  - maxLength = 10
- projectName
  - minLength = 3
  - maxLength = 10
- environmentName
  - allowed values: Development, Acceptance, Production
- environmentSize
  - allowed values: small, medium, large
- templateBaseUrl
  - defaults to [https://raw.githubusercontent.com/jtourlamain/DevProtocol.Calm/master/armtemplates/](https://raw.githubusercontent.com/jtourlamain/DevProtocol.Calm/master/armtemplates/)

## Naming convention template

### Input parameters

- companyName (required)
- projectName (required)
- environmentName (required)

### Output parameters

- companyName
- projectName
- envName
- envShort
- envAffix
- resourceNamePrefix

## App service plan template

### Input parameters

- resourceNamePrefix (required) created by the namingconvention template
- environmentSize (required)

## Web app template

### Input parameters

- resourceNamePrefix (required) created by the namingconvention template
- environmentName (required)
- hostingPlanName (required) depends on the appserviceplan template

### Output parameters

- webAppName (ex: foo-bar-d-web-wa)
- webAppHostName (ex: https://foo-bar-d-web-wa.azurewebsites.net)

## Api app template

### Input parameters

- resourceNamePrefix (required) created by the namingconvention template
- environmentName (required)
- hostingPlanName (required) depends on the appserviceplan template

### Output parameters

- webAppName (ex: foo-bar-d-web-wa)
- webAppHostName (ex: https://foo-bar-d-web-wa.azurewebsites.net)
