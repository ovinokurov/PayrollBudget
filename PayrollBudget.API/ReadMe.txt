﻿The dotnet ef tool is no longer part of the .NET Core SDK

This change allows us to ship dotnet ef as a regular .NET CLI tool that can be installed as either a global or local tool. 
For example, to be able to manage migrations or scaffold a DbContext, install dotnet ef as a global tool typing the following command:

dotnet tool install --global dotnet-ef

Migrate DB from models
1) Create Migration : dotnet ef migrations add InitialCreate
	a)  To undo this action, use 'ef migrations remove'
2) Migrate : dotnet ef database update