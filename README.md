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
5. Sample entity names : EmployeeSource.cs EmployeeTarget.cs StudentSource.cs StudentTarget.cs

##### View Insights
1. Starting point : Program.cs
2. Program automatically creates the database and inserts some seed data. If any already exists,it will update with the latest value.
3. You can provide the source, target and primary key as user define inputs. Find the source code in DynamicInputHandler.cs
4. MatchTable.cs class does the matching and returns a matching response. 
5. MatchTable.FindMatch takes the 3 parameters (source entity type, target entity type, primary key)
6. MatchTable.SetBatchSize() take one integer parameter to control the batch limit from client


##### Technologies
1. Microsoft.NetCore App
2. Entity Framework Core 3.1
3. Entity Framework Plus Core 

##### Sample 
View sample outputs from <a href="https://github.com/sabbiryan/entity-auditor/tree/master/Samples">here</a>

<img src="https://github.com/sabbiryan/entity-auditor/blob/master/Samples/Output%20Employee.PNG" width="600px">
<img src="https://github.com/sabbiryan/entity-auditor/blob/master/Samples/Output%20Student.PNG" width="600px">
