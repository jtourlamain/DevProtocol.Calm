# CALM: A starter pack for Azure DevOps

<!-- TOC -->

- [CALM: A starter pack for Azure DevOps](#calm-a-starter-pack-for-azure-devops)
    - [What is this?](#what-is-this)
    - [Quick start](#quick-start)
    - [Contributors](#contributors)
    - [License](#license)

<!-- /TOC -->

## What is this?

The CALM (Cloud Application Lifecycle Management) starter pack provides ARM templates that contain some best practices such as naming conventions and T-Shirt sizing. With the CALM starter pack you can create your resources in Azure in a consistent way.

## Quick start

This quick start will show you how you can create an Azure resource via the templates in a manual way. However, to optimise your CI/CD pipeline you should automate the resource deployments.

- Keep calm 😎, your Azure resources will be up and running in no time.
- make sure you have the Azure CLI installed. If not, please [Install the Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)
- create a new file "azuredeploy.parameters.json". Make sure you replace the companyName "foo" and projectName "bar" with your own values (between 3-10 characters each).

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "companyName": {
            "value": "foo"
        },
        "projectName": {
            "value": "bar"
        }
    }
}
```

- open a command prompt

```bash
# login with your azure account
az login
# change your subscription if needed
az account set --subscription "yoursubscription"
# create a resource group in your location -> I'll use westeurope
# to align to the naming conventions use <companyName>-<projectName><environmentAffix>-[<role>]<resource>
# the resource is create for development. The environmentAffix "-d" is used
# the resource is a resource group. Here the abbreviation "rg" is used.
az group create --name foo-bar-d-rg --location "westeurope"
# deploy the resource via an arm template to your resource group.
az group deployment create --name testdeployment --resource-group foo-bar-d-rg --template-uri "https://raw.githubusercontent.com/jtourlamain/DevProtocol.Calm/master/samples/armcompositions/storageTemplate.json" --parameters "azuredeploy.parameters.json"
```

## Contributors

- [Jan Tourlamain](https://github.com/jtourlamain "Jan Tourlamain GitHub")

## License

Licensed under MIT ( See [LICENSE.md](LICENSE.md) ).
