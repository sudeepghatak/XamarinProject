This was a hobby project I worked on after attending a Xamarin event.

The project includes two Visual studio projects:

1) A web service project: Responsible for CRUD operations on an Azure hosted database.
2) A Xamarin project: An android app using the web service to fetch/add/update/delete user records.


If you want to connect to a different web service and a different database, modify the following files.

-> Change the web service Url in Constants.cs under Intergen.Client project. 
-> Change the database connection string in the web.config file of the Intergen.Web project. 

