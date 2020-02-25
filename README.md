### Entity Auditor
A generic table matching console application using .net core and entity framework core and entity framework plus core. You can run the matching upon on any two different entities where the booth primary key is the same. For the best output ensure both entities scheme are same.

##### Setup with visual studio
1. Clone the repository
2. Open solution is visual studio
3. Set your database server name in appsettings.json "Default": "server=YourDatabaseServerName;database=AuditorDb;Trusted_Connection=True;"
4. Build and run the program (Ensure Client project is marked as startup project)

##### Download
1. Download an executable exe version from <a href="https://github.com/sabbiryan/entity-auditor/tree/master/EXE">here</a>
2. Extract the zip.
3. Update the appsetting.json with your database server name "Default": "server=YourDatabaseServerName;database=AuditorDb;Trusted_Connection=True;"
4. Run Client.exe and start playing.
5. Sample inputs : 
    
    1. Empployee Source | Employee Target | Social Security Number
    2. Student Source | Student Target | Student Id

##### View Insights
1. Starting point : Program.cs
2. Program automatically creates the database and inserts some seed data. If any already exists,it will update with the latest value. See DatabaseService.cs for detail reference.
3. You can provide the source, target and primary key as user define inputs. Find the source code in DynamicInputHandler.cs
4. MatchTable.cs class does the matching and returns a matching response. 
5. MatchTable.FindMatch takes the 3 parameters (source entity type, target entity type, primary key)
6. MatchTable.SetBatchSize() take one integer parameter to control the batch limit from client


##### Technologies
1. Microsoft.NetCore App
2. Code First Approach
3. Entity Framework Core 3.1
4. Entity Framework Plus Core 

##### Limitations
As I have used code first approach there are some limitations which I should notice.
1. For new tables is database, need to create new models and add the models reference on AuditorDbContext and also need to create a new migration using Add-Migration command
2. For working with any database just changing the connection string, the existing application needs some breaking changes. Hopefully I will have time to update it in a later version. (Maybe I can achieve this with a dynamic context creator or changing to database first approach or in a raw sql query version). Any other good advice is appriciateable 
3. To test the existing database, there needs to use entity framework core command Scaffold-DbContext for DataSource project and replace the AuditorDbContext references with the Scaffold generated DbContext. In my next release I will make the changes to configured the context in a single place at the starting point of the application


##### Sample 
View sample outputs from <a href="https://github.com/sabbiryan/entity-auditor/tree/master/Samples">here</a>

<img src="https://github.com/sabbiryan/entity-auditor/blob/master/Samples/Output%20Employee.PNG" width="600px">
<img src="https://github.com/sabbiryan/entity-auditor/blob/master/Samples/Output%20Student.PNG" width="600px">
