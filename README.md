The back end to a Progressive webapp designed for the Know Your Nation organization
To view visit https://api.ereader.retrotest.co.za/swagger/index.html


To Manage Migrations:
if you want to update your database:
roll back to your old migration
remove it
do you file changes
create a new migration
 update the database
 
Commands:
//Load Migration running
dotnet ef database update <migrationName> <<this is the name with the weird number in it on your migration
// Removes last migration
dotnet ef migrations remove
//Do Changes here
//Add new migration
dotnet ef migrations add <<migrationName>>
//Update DB
dotnet ef database update

List of Migrations in order from oldest to Latest: (add migrationName to readme if added)
20190213083122_InitialCreate

