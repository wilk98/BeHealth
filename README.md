# BeHealth - A doctor appointment booking system

It's an appointment booking system for doctors. It's a web application built with ASP.NET Core and React. It uses Entity Framework Core for database access and Microsoft SQL Server for the database. Goal of this project is to help private doctors and clinics to manage their appointments and patients. With the help of this system, doctors can manage their appointments and patients easily. Patients can also book appointments with doctors and see their appointments.

![BeHealth](https://i.imgur.com/WEVctzf.png)

## Features

- Manage appointments
- View appointments in calendar view
- Search doctors
- Chat with doctors
- Write reviews for doctors
- See list of visits
- Add certificates and clinics
- Issue a prescription

## Running the application

### Prerequisites

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/6.0)
- [Node.js](https://nodejs.org/en/)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Running the frontend

- Navigate to the `BeHealth/Frontend/BeHealthFrontend` folder
- Run `npm install` to install the dependencies
- Run `npm run dev` to start the frontend

### Running the backend

- Navigate to the `BeHealth/Backend/BeHealthBackend` folder
- Run `dotnet run` to start the backend

### Running the database

- Navigate to the `BeHealth/BackendBeHealthBackend` folder
- Open `appsettings.json` file
- Change the `BeHealthConnectionString` value to your connection string ([some examples of connection string](https://www.connectionstrings.com/sql-server/))

Important: You need to run the database before running the backend. Otherwise, the backend will not be able to start.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
