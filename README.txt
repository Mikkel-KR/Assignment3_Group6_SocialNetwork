**********************************
***     DAB - Assignment 3     ***
***         NoSQLGroup 6       ***
**********************************
*** The Social Network System  ***
**********************************

Group-members:
- Mikkel Kousgaard Rasmussen 	(au610713)
- Jeppe Dybdal Larsen 		(au616966)

*********************************
******* HOW TO USE THE APP ******
*********************************

** 1. Set up database **
1.1 Make a local Data-folder on your computer (e.g. C:\ase\DAB\SocialNetworkData)
1.2 Open Command-prompt and write: mongod --dbpath <insert-data-folder-path-here>
1.3 Open another instance of Command-prompt and write the following:
	> mongo
	> use SocialNetworkDb
	Note: You can use this prompt to check the collections in the database (The only collection in the database is: "Users"
		- e.g. write: db.Users.find({}).pretty() to find all user-documents in the database
	
** 2. Run/Use the App **
2.1 Press "Ctrl F5" to run the app - the app will start on your localhost and redirect to the HomePage.
2.2 The HomePage presents to options:
	option-1: Populate database 	: This button seeds the database (Recommended option)
	option-2: Clear database	: This button clears/unseeds the database
2.3 Now you are free to use the app as you wish:
	- find all users (their id's, circles and user-information) --> via "All Users"
		- Note: you can use the userId's to query data in the "Query (Feed/Wall)"-view
	- browse the Feed for a specific user or browse the Wall for a user, with a guest-user --> via "Query (Feed/Wall)"
	- create Comments to a specific post --> via the Feed or Wall
	- create Posts for a specific user --> via Feed