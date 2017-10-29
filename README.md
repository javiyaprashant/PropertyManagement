# PropertyManagement
This application displays the property details in grid and save the data in DB.

Installation Instruction steps:
1. Download the solution.
2. Open the Roofstock.PM Sln file. 
3. Get the DB Script (Table Script) from DBScript Folder (DBScript.sql)
   a. Create the database named PropertyManagement
   b. Execute DBScript sql script.   (This script assumes that PropertyManagement Database has been created. if you have some other database, please change the reference of database in script and execute it.)
4. Open the Web.config file of Roofstock.PM.UI Project and modified the following properties.
   a. ConnectionStrings 
     
     
