### Entity Auditor
A generic table matching console application using .net core and entity framework core and entity framework plus core

##### View Insights
1. Starting point : Program.cs
2. Program automatically inserts some seed data. If already exists any, will update with latest value.
3. MatchTable.cs class does the matching and returns a matching response. 
4. MatchTable.FindMatch takes the 3 parameters (source entity type, target entity type, primary key)
5. MatchTable.SetBatchSize() take one integer parameter to control the batch limit from client


##### Technologies
1. Microsoft.NetCore App
2. Entity Framework Core 3.1
3. Entity Framework Plus Core 

##### Sample 
View sample output from <a href="https://github.com/sabbiryan/entity-auditor/blob/master/Output.PNG">here</a>
