# FenrirApi

Test Task
You must follow our instructions correctly.

Create Asp.Net Core web api project on .Net 7. Use a local SQL Server database and Entity Framework Core. Local db is needed for you to store data and send it later with the archive.
Person table
Add Person table to the database. A Person should have properties: Id, FirstName, LastName. Id must be Guid.

Tables to database must be added using “EF Code First” and “EF Core Migrations”.

Seed your database with 3 test Persons.
Person api
Add api to get, create, update, delete Person. Api controller must interact with the database through the “Repository Pattern”.

During development use Postman to check that your api work.

Change so that your project launches at http://localhost:45100 url.

Your apis should be:

To get list of Persons use http method GET: http://localhost:45100/api/person

To create a Person use http method POST: http://localhost:45100/api/person

To update Person use http method PUT: http://localhost:45100/api/person?Id={personId} 

To delete Person use http method DELETE: http://localhost:45100/api/person?Id={personId} 

In place of {} use real values.
