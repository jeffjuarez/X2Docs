# DrakeX2
Drake X2 Docs project

THE ARCHITECTURE 

DataLayer - This is where all of our ORM tooling related objects reside. 
Our EF (Entity Framework 6.1.2) DataContext, Data, Mappings and Migrations. 
Give us a nice separation, control and isolation of where any persistence related objects live. 
If ever, one day we need to change the tool of choice, or even upgrade, there’s only one layer or project 
to do this in, the Data project.

  * Data folder - is where all of our POCO (Plan Old C# Objects) objects will live.
  

Repository - This is where our UoW (Unit of Work) pattern will be implemented as well as our Repository implementation. 
Our UoW implementation will handle most of our usual CRUD activities.


Web Project (Presentation Layer) - This is our presentation layer, for the purposes of the project, 
we will use MVC (ASP.NET MVC 5).


# X2 DOCS PROJECT PLAN

1)	Create project  Architecture

-	Status : Done
-	Tools  :  VS  2013 ,ASP.NET  MVC 5  using C# and ORMapping using  Entity Framework
-	Data   :  SQL 2008 R2 

2)	Functional Specification   (Search , Preview and  Delete )

     UPLOADING -  Status: Done!
SEARH DOCS.
•	User Search in UI for a particular uploaded documents
- we will provide the user a searching capability where user can see a textbox to type the keyword.
 

  - We will also provide the user to search through different categories such as Date range and File names keyword.      

PREVIEW   DOCS.

•	User click on Preview link  in UI for a particular uploaded documents
- We  will provide the user a Previewing capability where user can see a linkbutton  to click just corresponding the particular file to preview.
- It will open a new window browser to render the prevew.

	DELETE   DOCS.
•	User click on Delete Button  in UI for a particular uploaded document  to be deleted
- We  will provide the user a deletion capability where user can see a button  to click just corresponding the particular file to delete

3)	BACK-END  CAPABALITY 

-	I will provide a Function / Stored proc. That will return a result based on a Full-Text Indexing search capability.

-	This functionality can be used for querying and returning result of searching through the Files being uploaded which has a Varbinary Data type.




