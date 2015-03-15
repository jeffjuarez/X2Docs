# DrakeProject
Drake X2 Docs project

DataLayer - This is where all of our ORM tooling related objects reside. 
Our EF (Entity Framework 6.1.2) DataContext, Data, Mappings and Migrations. 
Give us a nice separation, control and isolation of where any persistence related objects live. 
If ever, one day we need to change the tool of choice, or even upgrade, there’s only one layer or project 
to do this in, the Data project.

  * Data folder - is where all of our POCO (Plan Old C# Objects) objects will live.
  

Repository - This is where our UoW (Unit of Work) pattern will be implemented as well as our Repository implementation. 
Our UoW implementation will handle most of our usual CRUD activities.


Web Project (Presentation Layer) - This is our presentation layer, for the purposes of the blog, 
we will use MVC (ASP.NET MVC 5).
