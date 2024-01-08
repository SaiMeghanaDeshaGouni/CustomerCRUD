This project utilizes Angular 15 and ASP.NET Core Web API with the latest .NET version 8.

Features supported:
The front end of the application displays customer information, and the tabular view allows users to sort customers and also allow pagination. As per the requirements, when a user clicks the edit pencil to modify a customer, the corresponding row is highlighted in green, and the customer ID is stored in session storage, which is managed through a separate session storage service and remains highlighted even on page refreshes.

Implementation details:
1. On front end side, there are 3 folders: components, services and models - one for each type of entity.
2. Two services have been created on the Angular side: one for data retrieval and the other for session storage operations, maintaining a separation of concerns.
3. Table is created using latest Angular Material for neat look & feel and grid supports sorting and pagination.
4. Add/Edit Customer is implemented in a reusable component (modal popup) and supports input validation.
5. On DotNetCore API side- All data related operations happen at Service DAL layer which is connected to Controller layer via Dependency Injection(DI)
6. Swagger is implemented on API side.
7. API Routes uses Attribute based routing for all calls.
8. Models are maintained in a separate "Models" folder on Angular side and Web API side. In this case we have model only of Customer entity.
9. In a real-world scenario, data would be sourced from persistent storage like a database. So, due to absense of database and for illustrative purpose, data is stored in-memory on the API side and passed to the frontend for display in this implementation. However, all operations are defined on API side too so that it is just plug-and-play once database connections are implemented.


Possible improvements:
1. Currently, the Angular frontend and API lack support for unit test cases, which can be implemented. 
2. UI can be improved further but due to time limitation kept it light and neat.
3. The Web API does not currently incorporate any authentication mechanism; however, in a production environment, user authentication will be crucial.
4. As the application code base expands, the implementation of a few design patterns(apart from DI) can enhance the overall code structure.
5. Due to time constraints, error handling and logging functionalities have not been implemented, which are crucial aspects in a real production-based application.
6. Currently data comes via WEB API using in-memory implemtation. In a real scenario with a database, a DBContext can be created to source data for all operations. Though API has all retrieval, Editing, adding customer related methods are implemented.