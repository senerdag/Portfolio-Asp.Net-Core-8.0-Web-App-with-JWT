# **Portfolio | Asp.Net Core 8.0 Api With JWT and Mediator Design Pattern, Onion Architecture**
The Portfolio project is a .Net Core web application built on web api for trial purposes as a personal website.The design pattern uses mediator and Authentication and Authorization is provided with JWT (JSON Web Token).In the application I developed with the Code First approach, the user is informed with toastr.Everywhere on the site is dynamic and Admin can manage the CRUD operations of the data in the admin panel.

![1](https://github.com/senerdag/Portfolio/assets/79213168/0828437f-01a4-4c1d-8c24-84cb521449c6)
![2](https://github.com/senerdag/Portfolio/assets/79213168/8927e6da-8056-4b9c-a1ce-fa46604bdd62)
![3](https://github.com/senerdag/Portfolio/assets/79213168/be9397b1-8e1d-4253-a5b8-bb7d147efcfe)
![4](https://github.com/senerdag/Portfolio/assets/79213168/bd8a944e-21f7-4fc8-a170-cf40ecb83d70)
![5](https://github.com/senerdag/Portfolio/assets/79213168/a03107f8-6a10-41da-91d2-82ed9859e3c3)
**You can manage incoming messages and CRUD operations in the admin panel.**
![login](https://github.com/senerdag/Portfolio/assets/79213168/0ac9493d-4aa5-4c1d-9068-e05e487d1cf5)
![contactmessages admin](https://github.com/senerdag/Portfolio/assets/79213168/f71b81ce-70b0-409c-99a1-03891f2c767e)
![banner admin](https://github.com/senerdag/Portfolio/assets/79213168/418d7c58-7b85-4424-bf34-92c4c658c964)
![Web API](https://github.com/senerdag/Portfolio/assets/79213168/b0339941-9dc4-4ced-931b-bde8fbe9c488)

# Technologies Used
**Backend**
- **Web Development Framework:** ASP.NET Core 8.0
- **C#:** In the backend, the C# language has been utilized.
- **MSSQL:** Microsoft SQL Server has been used as the database.
- **Swagger:** Swagger has been used for API documentation.
- **Code First Approach**

**Authentication and Authorization**
- **JWT (JSON Web Token):**  It is a type of token that enables encrypted or signed information to be transferred between parties in bulk as a JSON object with the standard set out in RFC 7519. 
 
**Frontend**
- **HTML:** HTML has been used for structuring the pages.
- **CSS:** CSS has been used for determining styles.
- **Bootstrap:** Bootstrap is used for fast and effective interface design.
- **JavaScript:** JavaScript is used for page interactions.


# **Design Patterns**
- **Mediator:** It is a pattern based on providing communication between objects derived from the same interface through a single point.

 
# **Project Structure and Layered Architecture**
 The project follows the following layered architecture structure:
 - **Core:** In the Core layer we have Domain (class project where we define Entities) and Application (we have Design Pattern and Interfaces)
 - **Frontends:** In our Frontends layer, we have Dto (Mapping) and WebUI (MVC) projects.
 - **Infrastructure:** In our Persistence project, we have the string connection to which we connect our database, migrations and repositories of our interfaces.
 - **Presentation:** Presentation layer contains the Web API to which we send requests for our Web Application.

   
# **Requirements**
- .NET Core SDK
- Microsoft SQL Server

  
# **API Endpoints**
**There are many entity specific query operations inside the project(statistics, filtering operations etc.), the following are just normal crud enpoints.**
- GET: Lists all items 
- GET By Id: Fetches according to ID. 
- POST: Creates a new item. 
- DELETE: Deletes the fetched item by ID. 
- Put: Updates fetched item according to ID 

