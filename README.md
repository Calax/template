# Template.
This is a template of what I see a generic service could be. In my production development I use projects with similar structure.
Feel free to investigate and use the template if it meets your requirements.

Solution consists of following projects:
1. *Service.Template.Repository.Migrations.csproj* contains code to apply database structure based on FluentMigrator library.
1. *Service.Template.Repository.csproj* contains repository layer code (incarcerates code working with database) using linq2db ORM.
1. *Service.Template.Host.csproj* is the main project containing api controllers.
1. *Service.Template.Client.csproj* represents ready to use client for consuming the api. 
1. *Service.Template.Tests.UnitTests.csproj* contains unit tests for the project.


