# apps-reader <!-- omit in toc -->
The project containing the gateway and frontend for the web reader
## Table of Contents <!-- omit in toc -->
- [Setup](#setup)
  - [Software to install](#software-to-install)
  - [Visual Studio Setup](#visual-studio-setup)
  - [VSCode Recommended Extensions](#vscode-recommended-extensions)
  - [SQL Server Setup and SSMS Setup](#sql-server-setup-and-ssms-setup)
  - [Angular Setup](#angular-setup)
- [Running project](#running-project)
  - [Database](#database)
    - [Import](#import)
    - [Export](#export)
  - [API](#api)
  - [Angular](#angular)
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

### Angular Setup
1. Install [Node.js v20.12.2 (LTS)](https://nodejs.org/en/download/)
    1. The above process takes a while, and at least in my case, was able to finish without closing down the Powershell window it had opened, making it unclear whether or not the installs were done.
2. Open up a new terminal (fresh, since PATH variables will be updated as part of the previous installs, and a terminal can't update that without restarting) and enter the following commands:  `node --version` and `npm -help`. If both of those run and produce output other than a statement about node or npm not being on your PATH, you should be good to proceed
3. Navigate to Application.GeniusReader/ClientApp, and open this folder in Visual Studio Code.
4. Run `npm install`, and wait for it to install all of the packages on your machine

## Running project
### Database
When working on this project, it will be helpful for everyone to be working from the same set of data. Rather than manually write up and maintain scripts to drop, recreate, and repopulate our schema every time a change is made, for now we will instead be making use of database backups. When pulling down new work, please make sure to restore from the latest backup (included in the repo). See the [Import](#import) section below.

 If you push work that involved modifying schema or adding more data to the database, MAKE SURE THAT THE DATA IS VALID (no orphaned records, no duplicate records unless intentional, no unused columns, etc.) and then export your data to a new backup and commit it. See the [Export](#export) section below.
#### Import
1. Clone repo from https://github.com/nlehnert1/apps-reader
2. Copy the file `Applications.GeniusReader/CopyOfMasterDb.bak` into a location on your machine that SSMS will have permissions to read/restore from. By default, this should be something like `C:/Program Files/Microsoft SQL Server/MSSQL16.MSSQLSERVER/MSSQL/Backup/`.
3. In SSMS, expand the Object explorer, and underneath the root of the connection, right click on Databases and select "Restore Database".
4. Select Device:, and then select the ellipses (...) to locate your backup file.
5. Select Add and navigate to where your .bak file is located. Select the .bak file and then select OK.
6. Select OK to close the Select backup devices dialog box.
7. Select OK to restore the backup of your database.

#### Export
1. In the process of working on the project, make changes to the schema or data contained within the database
2. BEFORE BACKING UP, VERIFY THE FOLLOWING:
   1. There are no orphaned records in the database, and all foreign key relationships are correct
   2. There are no duplicate records (unless intentionally added to test filtering logic of an endpoint)
   3. There are no unused columns in the schema
3. Right click the database you have been using > Tasks > Export Data
4. Under Destination, confirm that the path for your backup is correct. If you need to change the path, select Remove to remove the existing path, and then Add to type in a new path. You can use the ellipses to navigate to a specific file.
   1. You probably don't have permission to write the backup directly to the repo location. Looking into how to get around that, but for now, just make note of the default path and use it
5. Select OK to take a backup of your database.
6. Make sure the database has a .bak extension (rename it if necessary)
7. Copy the file to the repo, check it in, and commit it.

### API
1. Open solution in Visual Studio 2022
6. Run project to pull up Swagger for endpoints

### Angular
1. Make sure the API is already running. While the API isn't strictly necessary for Angular itself to do anything, we are not using Service Fabric or anything like that to host the API while not actively dubgging it, so you need to be actively debugging the app in Visual Studio for service calls to have anything to hit.
2. Navigate to the ClientApp folder in VSCode and run `npm run start`. This will build application bundles, and should produce a link once it has finished. Ctrl+click the link, or open a browser yourself and navigate to http://localhost:4200, and you should be able to see the landing page.

## Work to do
1. Add more controllers and endpoints (add chapter, add series, add tags to series/chapter, etc)
2. Figure out actual file storage solution (read/write .png or .jpg files directly to/from machine in the mean time?)
3. Add accounts/Identity