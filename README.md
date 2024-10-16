# JWTCQRSProject
# .NET Core Web API & MVC Application with CQRS Architecture

This project demonstrates a .NET Core Web API and MVC application implementing the CQRS (Command Query Responsibility Segregation) pattern. The project includes technologies like Mediator, JWT Authentication, AutoMapper, and EF Core for database operations. The application handles CRUD operations on `Roles`, `User`, `Category`, and `Product` entities.

## Table of Contents
- [Features](#features)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Installation](#installation)

## Features
- Implemented CQRS pattern to separate read and write operations.
- Used Mediator for decoupling the request and response handling.
- JWT Authentication for securing the Web API.
- AutoMapper for object mapping.
- EF Core for database interactions.
- Support for CRUD operations on `Roles`, `User`, `Category`, and `Product` entities via API.

## Technologies
- .NET Core 6.0
- CQRS Pattern
- Mediator (using MediatR)
- JWT Authentication
- AutoMapper
- Entity Framework Core (EF Core)
- SQL Server (or your preferred database)

## Architecture
The project follows the CQRS pattern:
- **Command Handlers** are responsible for handling commands that change the state of the application (e.g., Create, Update, Delete).
- **Query Handlers** are responsible for handling read operations (e.g., Get, GetAll).
- Mediator pattern is used to decouple the command/query handlers from the controller actions.
- JWT is used for authentication and authorization.
- AutoMapper is used to map entities to DTOs.

## Prerequisites
- [.NET Core SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database system

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/OguzhanOrge/DotNetCoreJWTApp
2. Navigate to the project directory:
    ```bash
   cd DotNetCoreJWTApp
2. Navigate to the project directory:
    ```bash
   cd DotNetCoreJWTApp
3. Apply database migrations:
    ```bash
   dotnet ef database update
