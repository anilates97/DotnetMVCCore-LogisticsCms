# Logistics CMS

Logistics CMS is a content management system built with ASP.NET Core MVC and MongoDB.

The project focuses on managing logistics-related website content such as sliders, brands, offers, projects, testimonials, shipments and shipment tracking modules through an admin-focused structure.

The application uses a layered architecture with Controllers, Services, DTOs, Models, ViewComponents and Razor Views.

---

# Project Overview

This project was developed to practice and demonstrate ASP.NET Core MVC development with a modular CMS structure.

The main goal of the application is to separate business logic from controllers by using service classes and DTO-based data transfer while storing data in MongoDB.

---

# Key Features

- ASP.NET Core MVC structure
- MongoDB integration
- Admin-focused CMS modules
- Cookie-based authentication
- Shipment and shipment tracking management
- Slider, brand, offer, project and testimonial management
- DTO-based data transfer
- AutoMapper integration
- ViewComponent usage
- Layered project structure
- Razor View-based UI

---

# Technologies Used

## Backend
- ASP.NET Core MVC
- C#
- MongoDB
- AutoMapper
- Cookie Authentication

## Frontend
- HTML5
- CSS3
- JavaScript
- Razor Views
- Bootstrap

## Architecture & Patterns
- MVC Architecture
- Service Layer
- DTO Structure
- ViewComponents

## Tools
- .NET
- Git
- GitHub
- Visual Studio

---

# Project Structure

```text
LogisticsCMS/
├── Controllers/
├── DTOs/
├── Models/
├── Services/
├── ViewComponents/
├── Views/
├── wwwroot/
└── Program.cs
```

---

# Main Modules

The project includes several CMS modules:

- About management
- Brand management
- Offer management
- Project management
- Shipment management
- Shipment tracking
- Slider management
- Testimonial management
- Admin authentication

---

# Architecture

The application follows a modular ASP.NET Core MVC structure.

- Controllers handle HTTP requests and page routing
- Services contain business logic and data operations
- DTOs are used for data transfer between layers
- Models represent application entities
- ViewComponents are used for reusable UI sections
- MongoDB is used as the database layer

This structure improves maintainability and keeps controller logic cleaner.

---

# Installation

## 1. Clone the Repository

```bash
git clone https://github.com/anilates97/DotnetMVCCore-LogisticsCms.git
```

---

## 2. Navigate to the Project Folder

```bash
cd DotnetMVCCore-LogisticsCms
```

---

## 3. Restore Dependencies

```bash
dotnet restore
```

---

## 4. Configure MongoDB

Make sure MongoDB is installed and running.

Update the MongoDB connection settings in the application configuration file if needed.

---

## 5. Run the Application

```bash
dotnet run
```

---

# Future Improvements

- Add dashboard analytics
- Add role-based authorization
- Add form validation improvements
- Add unit tests
- Add Docker support
- Add screenshots and live demo
- Improve admin UI design

---

# Developer

Anıl Hasan Ateş

- LinkedIn: https://linkedin.com/in/anilates97
- GitHub: https://github.com/anilates97
- Portfolio: https://anilates.vercel.app/
