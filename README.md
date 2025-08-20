Skinet - E-commerce Platform
A modern, full-stack e-commerce application built with .NET Core Web API and Angular 10, featuring advanced architectural patterns and payment integration.

🚀 Features
Backend (.NET Core Web API)
Advanced Architecture: Repository Pattern with Unit of Work and Specification Pattern

Data Mapping: Automated object mapping with AutoMapper

Data Operations: Comprehensive paging, sorting, searching, and filtering capabilities

Error Handling: Custom middleware for centralized error management (400, 401, 404, 500)

Generic Pagination: Reusable pagination class for any entity type

API Documentation: Integrated Swagger with custom configurations

Clean Architecture: Extension methods for IApplicationBuilder and IServiceCollection to maintain clean startup class

Frontend (Angular 10)
Modern Angular CLI-based storefront UI

Responsive design and user-friendly interface

Infrastructure
Performance: Redis caching for improved response times

Payments: Secure payment processing with Stripe integration

Best Practices: Object-oriented programming principles throughout

🛠️ Tech Stack
Backend: .NET Core Web API

Frontend: Angular 10

Database: Entity Framework Core

Caching: Redis

Payments: Stripe

Documentation: Swagger/OpenAPI

Architecture: Repository Pattern, Unit of Work, Specification Pattern

📋 Project Structure
text
Skinet/
├── API/                 # .NET Core Web API
├── Client/              # Angular 10 Frontend
├── Core/               # Domain models and interfaces
├── Infrastructure/     # Data access and repository implementation
└── README.md          # Project documentation
🚦 Getting Started
Prerequisites
.NET Core SDK

Angular CLI

Redis Server

SQL Server

Installation
Clone the repository

bash
git clone https://github.com/your-username/Skinet.git
cd Skinet
Backend Setup

bash
cd API
dotnet restore
dotnet run
Frontend Setup

bash
cd Client
npm install
ng serve
📖 API Documentation
Access Swagger documentation at https://localhost:5001/swagger when the API is running.

🎯 Key Highlights
Proof of Concept: Demonstrates modern e-commerce architecture patterns

Scalable Design: Built with maintainability and scalability in mind

Production Ready: Includes error handling, logging, and security considerations

Developer Friendly: Comprehensive API documentation and clean code structure

🤝 Contributing
This project serves as a learning resource and proof of concept. Feel free to explore the codebase and adapt patterns for your own projects.

📄 License
This project is open source and available under the MIT License.

Built with ❤️ using .NET Core and Angular
