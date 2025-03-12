# Smart Appointment System

## Project Overview

The **Smart Appointment System** is a web-based platform developed using **ASP.NET Core MVC** for the backend and **React.js** for the frontend. The system provides an efficient, scalable solution for scheduling, managing, and notifying users about appointments.

## Technology Stack

- **Backend:** ASP.NET Core MVC, Entity Framework Core, SQL Server
- **Frontend:** React.js, Context API
- **Design Patterns:** Singleton, Factory, Observer, Strategy, Repository

## Features

### User Management

- User registration and login with roles (`Patient`, `Doctor`, `Admin`).

### Appointment Management

- Booking, rescheduling, and canceling appointments.
- Multiple appointment types (Online, Physical, Urgent).

### Notifications

- Email and SMS notifications for appointment confirmations and reminders.

### Filtering & Sorting

- Sort appointments by date, doctor, or type.
- Filter based on user preferences.

## Design Patterns Implementation

- **Singleton Pattern:**

  - Ensures a single instance of `LoggerService` across the application.

- **Factory Pattern:**

  - Dynamically creates different appointment types.

- **Observer Pattern:**

  - Sends Email and SMS notifications triggered by appointment-related events.

- **Strategy Pattern**

  - Flexible sorting strategies (by date, doctor, type).

- **Repository Pattern**

  - Abstracts database interactions using Entity Framework Core.

## Project Structure

### Backend (ASP.NET Core MVC)

```
SmartAppointmentSystem/
├── Controllers/
│   ├── AppointmentController.cs
│   ├── UserController.cs
│   ├── NotificationController.cs
├── Models/
│   ├── Appointment.cs
│   ├── User.cs
│   └── Doctor.cs
├── Patterns/
│   ├── Factory/
│   │   └── AppointmentFactory.cs
│   ├── Observer/
│   │   ├── IObserver.cs
│   │   ├── EmailNotifier.cs
│   │   └── SmsNotifier.cs
│   ├── Singleton/
│   │   └── LoggerService.cs
│   └── Strategy/
│       ├── ISortingStrategy.cs
│       ├── DateSortingStrategy.cs
│       └── DoctorSortingStrategy.cs
├── Repositories/
│   ├── IRepository.cs
│   └── UserRepository.cs
├── Services/
│   ├── AppointmentService.cs
│   ├── NotificationService.cs
│   └── AuthService.cs
├── appsettings.json
├── Program.cs
└── Startup.cs
```

### Frontend (React.js)

```
frontend/
├── src/
│   ├── components/
│   │   ├── AppointmentCard.js
│   │   └── Notification.js
│   ├── pages/
│   │   ├── Dashboard.js
│   │   └── Appointments.js
│   ├── context/
│   │   └── AppointmentContext.js
│   ├── hooks/
│   │   └── useFetchAppointments.js
│   ├── App.js
│   └── index.js
├── package.json
└── .env
```

## Next Steps

- Database Schema Design: Define tables and relationships.
- Implement Repository & Service Layers.
- Develop Factory and Observer Patterns for appointments and notifications.
- Build Frontend Components & API Integration.

---

This document will evolve as the project progresses.