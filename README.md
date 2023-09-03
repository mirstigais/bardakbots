# Bardakbots
### A bot for Bardaks discord server
[![Click on the birb to join the server](https://cdn.discordapp.com/icons/568517834498637836/a_aa40d06b727a51222c720cf9be5cca7e.jpg "Click on the birb to join the server")](https://disboard.org/server/join/568517834498637836 "Click on the birb to join the server")

------------


## Features
At this moment has debug functionality and ability to remind you of how poor you are.

#### Development Commands
##### General commands
* !sample - Will respond to you, used to check if the bot is even running locally.

##### Bank commands
* !bilance - returns your account bilance.
* !cheatAddBilance [number] - will add [number] bardaksbucks to your account. (number can be changed)
* !cheatRemoveBilance [number] - will remove [number] bardaksbucks from your account. (number can be changed)

------------


## How to set up the project for development?
### Server setup
1. Go to https://discord.com/developers ;
2. Get yourself a bot and invite it to your server. (Covered in tutorial linked below);
3. Remember to grant it all intents, otherwise you might get permission issues;

### Dev environment setup
1. Install VS Studio 2022:
	* Select .NET desktop development workload in the installer.
2. (Optional) Install Git client like sourcetree or Git CLI;
3. Clone the project ;
4. Set up localdb:
	* [How to set up and download](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16#install-localdb "How to set up and download")
5. Rename .env.example to .env:
	 * Fill token variable with one you got from discord dev portal when setting up the bot;
	 * Connection string can be found in visual studio, SQL Server Object explorer by clicking on the server, the properties window should contain connection string:
	* Replace "Data Source=" with "Server=" and "Catalog=master" with "Catalog=Bardakbots" in the connection string so on runtime it creates new DB instead of creating tables under "master" DB.
6. In package manager console run "update-database" for DB and tables to be created
7. Click run and it should build the project and bot on your server should appear as being online.

------------


## Project structure
* Already existing module "Bank" can be used as a loose guideline for how a module should be structured. (unless someone comes up with something better)
* Under folder named "Providers" in the respective files new commands and events may be registered. (use the existing ones as template)

## Helpful links
* https://dsharpplus.github.io/DSharpPlus/ - Library docs
* https://youtu.be/qxlmioSDWmk?si=zSmDaO6SXmp8MeIJ - Inspired by this well made tutorial
* https://youtu.be/SryQxUeChMc?si=LcHe5AyfGBKObDNG - Tutorial for Entity Framework for those daring to play around with DB

![Static Badge](https://img.shields.io/badge/K%C4%81rums-Sieri%C5%86%C5%A1-orange?labelColor=blue)
