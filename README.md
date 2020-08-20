# .NET Core User-Owns-Data Sample
This sample provides a starter web application for Power BI embedding using .NET Core 3.1 and the new Microsoft Authentication Library named `Microsoft.Identity.Web`. You can use this sample application to create your own Power BI embedding prototype.

## Requirements for running this sample application.
The run this sample application on your development workstation you must meet the following prerequisites.
Your developer  workstation must configure to allow the execution of PowerShell scripts. Your developer workstation must also have the following software and developer tools installed.

- PowerShell cmdlet library for AzureAD - [download](https://docs.microsoft.com/en-us/powershell/azure/active-directory/install-adv2?view=azureadps-2.0)
- DOTNET Core SDK 3.1 or later - [download](https://dotnet.microsoft.com/download)
- Node.js - [download](https://nodejs.org/en/download/)
- Visual Studio Code] - [download](https://code.visualstudio.com/Download)
- Visual Studio 2019 (optional) - [download](https://visualstudio.microsoft.com/downloads/)

## Downloading and configuring this sample application.
Once you have install the prequisite software, you must complete the following steps to run this sample application on your development workstation.

 - Download the code for the **UserOwnsData** project.
 - Open the **UserOwnsData** project in Visual Studio Code.
 - Run the PowerShell script named [`CreateAzureADApplication.ps1`](https://github.com/TedPattison/NetCore-UserOwnsData/blob/master/CreateAzureADApplication.ps1) to create a new Azure AD application. 
 - Copy the JSON from the text file into `appsettings.json`.
 - Open the Visual Studio Code Console and Run These Commands.
   1. `npm install`
   2. `npm run build`
   3. `dotnet dev-cert https --clean` 
   4. `dotnet dev-cert https --trust`
 - zzzzzz