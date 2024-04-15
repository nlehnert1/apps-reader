# apps-reader <!-- omit in toc -->
The project containing the gateway and frontend for the web reader
## Table of Contents <!-- omit in toc -->
- [Setup](#setup)
  - [Software to install](#software-to-install)
  - [Visual Studio Setup](#visual-studio-setup)
  - [VSCode Recommended Extensions](#vscode-recommended-extensions)
  - [SQL Server Setup and SSMS Setup](#sql-server-setup-and-ssms-setup)
- [Running project](#running-project)
- [Work to do](#work-to-do)

## Setup

### Software to install
1. [SQL Server Management Studio 20.1](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms)
2. [Visual Studio 2022 Community Edition](https://visualstudio.microsoft.com/vs/)
3. [Visual Studio Code](https://code.visualstudio.com/)
4. [SQL Server 2022 Developer Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
5. [Git](https://git-scm.com/download/win)

### Visual Studio Setup
1. Launch Visual Studio Installer.
2. Check "ASP.NET and web Development", "Azure development", ".NET desktop development", and "Data storage and processing" from the "Workloads" tab.
3. In "Individual Components" tab, make sure .NET 8.0 Runtime is checked. The other checked items you see are selected due to our choices in the "Workloads" tab.
4. Download and install.

### VSCode Recommended Extensions
1. Angular Essentials
2. Markdown All in One

### SQL Server Setup and SSMS Setup
1. Run the wizard(s)
2. I don't believe I made any changes from the defaults during the install process.

## Running project
1. Clone repo from https://github.com/nlehnert1/apps-reader
2. Open SSMS and connect to database
3. In SSMS, open and run SchemaSetupDLL.sql
4. In SSMS, open and run SeedData.sql
5. Open solution in Visual Studio 2022
6. Run project to pull up Swagger for endpoints

## Work to do
1. Add Angular to project
2. Create Angular Frontend
3. Flesh out endpoints