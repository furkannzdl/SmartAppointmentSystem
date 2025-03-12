Smart Appointment System - Context

Project Overview

The Smart Appointment System is a web-based platform developed using ASP.NET Core MVC for the backend and React.js for the frontend. The system aims to provide an efficient and scalable way to schedule, manage, and notify users about their appointments.

Technology Stack

Backend: ASP.NET Core MVC, Entity Framework Core, SQL Server

Frontend: React.js, Context API

Design Patterns: Singleton, Factory, Observer, Strategy, Repository

Authentication & Authorization: JWT (JSON Web Token)

Database: SQL Server

Key Functionalities

User Management:

User roles: Patient, Doctor, Admin

Registration and authentication (JWT-based login)

Appointment Management:

Booking, rescheduling, and canceling appointments

Different appointment types (Online, Physical, Urgent)

Notifications:

Email and SMS notifications for appointment confirmations and reminders

Filtering & Sorting:

Sort appointments by date, doctor, or type

Filter based on user preferences

Design Patterns Implementation

Singleton Pattern:

Used for LoggerService to ensure a single instance for logging across the application.

Factory Pattern:

Used to create different appointment types dynamically.

Observer Pattern:

Implemented for event-driven notifications (email and SMS when an appointment is booked).

Strategy Pattern:

Enables different sorting strategies for appointments (e.g., by date, by doctor, by type).

Repository Pattern:

Provides an abstraction layer for database operations using Entity Framework Core.

Project Structure

Backend (ASP.NET Core MVC)

SmartAppointmentSystem/
├── Controllers/
│   ├── AppointmentController.cs
│   ├── UserController.cs
│   ├── NotificationController.cs
├── Models/
│   ├── Appointment.cs
│   ├── User.cs
│   ├── Doctor.cs
├── Repositories/
│   ├── IAppointmentRepository.cs
│   ├── AppointmentRepository.cs
├── Services/
│   ├── AppointmentService.cs
│   ├── NotificationService.cs
│   ├── LoggingService.cs
├── Patterns/
│   ├── Factory/
│   │   ├── AppointmentFactory.cs
│   ├── Observer/
│   │   ├── IObserver.cs
│   │   ├── EmailNotifier.cs
│   │   ├── SmsNotifier.cs
│   ├── Strategy/
│   │   ├── ISortingStrategy.cs
│   │   ├── DateSortingStrategy.cs
│   │   ├── DoctorSortingStrategy.cs
│   ├── Singleton/
│   │   ├── LoggerService.cs
├── appsettings.json
├── Program.cs
└── Startup.cs

Frontend (React.js)

frontend/
├── src/
│   ├── components/
│   │   ├── AppointmentCard.js
│   │   ├── Notification.js
│   ├── pages/
│   │   ├── Dashboard.js
│   │   ├── Appointments.js
│   ├── context/
│   │   ├── AppointmentContext.js
│   ├── hooks/
│   │   ├── useFetchAppointments.js
│   ├── App.js
│   ├── index.js
├── package.json
└── .env

Next Steps

Database Schema Design – Define tables and relationships.

Implement Repository & Service Layers.

Develop Factory and Observer Patterns for appointments and notifications.

Build Frontend Components & API Integration.

This document will evolve as the project progresses.


