# Jobsity.Chatroom


## Starting 🚀
The goal of this application is to create a simple browser-based chat.

This application should allow several users to talk in a chatroom and also to get stock quotes from an API using a specific command.

### Pre-requisites 🔧
#### You need:
* VS 2022
* .Net 6.0
* SQL Server
* Rabbit MQ

## Running solution ⚙️
### Option A
* Open visual studio
* Review Rabbit connection string in appsettings.json for both projects
* Review DB connection string in Jobsity.Chatroom.WebApi
* Run migrations into DB
* Select Jobsity.Chatroom.WebApi and Jobsity.Chatroom.Bot as startup projects
* Run the solution

### Option B
* Open command line/command prompt
* Go to src\Jobsity.Chatroom\Jobsity.Chatroom.Bot
* Run "dotnet run"
* Open second command line/command prompt
* Go to src\Jobsity.Chatroom\Jobsity.Chatroom.WebApi
* Run "dotnet run"


## Built with 🛠️
* Vs 2022

## Sites 📌
### Test:
* Jobsity.Chatroom.WebApi in IISExpress
	* https://localhost:7134/index.html
	
* Users
	* name:user1 password:123456
	* name:user2 password:123456

## Pending 📋
* Create Unit test
* Error handling
* Create view models to avoid returning model data