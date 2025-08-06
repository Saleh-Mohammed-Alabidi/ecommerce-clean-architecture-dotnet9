
# 📦 Ecommerce Clean Architecture • .NET 9

## 🧭 Overview
A modular eCommerce API built with .NET 9 using Clean Architecture principles, Minimal APIs, and Entity Framework.

## 🚀 Features

* CRUD operations for products, customers, categories, and orders
* Integration with CQRS and MediatR for application logic
* Entity Framework Core for data persistence
* Clear separation into **Domain**, **Application**, **Infrastructure**, and API layers
* Basic validations, error handling, and logging

## 🧩 Project Structure

```
/src
  /Domain           ← Business rules, entities, value objects
  /Application      ← Use cases, DTOs, commands & queries
  /Infrastructure   ← EF Core implementation, database, external APIs
  /API              ← ASP.NET Core Web API project (presentation layer)
/tests              ← Unit and integration tests
```

## 🎯 Tech Stack

* .NET 9 and C# 12
* ASP.NET Core Web API
* Entity Framework Core
* MediatR (for CQRS)
* DDD & SOLID principles
* xUnit (tests)
* Docker (optional)

## 🛠️ Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com)
* MySQL Server
* (Optional) Docker & Docker Compose

## ⚙️ Setup & Run Locally

1. Clone this repo:

   ```bash
   git clone https://github.com/Saleh-Mohammed-Alabidi/ecommerce-clean-architecture-dotnet9.git
   ```
2. Navigate to the solution folder:

   ```bash
   cd ecommerce-clean-architecture-dotnet9
   ```
3. Restore dependencies:

   ```bash
   dotnet restore
   ```
4. Configure database connection in `appsettings.json` (API project)
5. Apply EF Core migrations (if applicable):

   ```bash
   cd Infrastructure
   dotnet ef migrations add Initial  
   dotnet ef database update
   ```


## ⚖️ License

Distributed under the **MIT License**. See `LICENSE` for more information.


### 🧠 Why This Template Works

* Adopts the layered structure consistent with Clean Architecture and DDD.
* Guides newcomers quickly through setup, structure, tech choices, and running instructions.

