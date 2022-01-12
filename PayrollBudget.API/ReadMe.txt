Migrate DB from models
1) Create Migration : dotnet ef migrations add InitialCreate
	a)  To undo this action, use 'ef migrations remove'
2) Migrate : dotnet ef database update