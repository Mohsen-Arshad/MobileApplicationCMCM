# MobileApplicationCMCM

A cross-platform **mobile application** built with **.NET MAUI** for the CMCM request management system.

This was my first mobile application project and was developed alongside the [ProjectCMCM](https://github.com/Mohsen-Arshad/ProjectCMCM) backend API.

## About

The application allows users to interact with the CMCM system from a mobile device. Users can register, log in, browse request categories, submit requests, attach documents, and manage their submitted requests.

The application communicates with the CMCM Web API for authentication, request management, and document handling.

## Features

* User registration and login
* JWT authentication
* Browse request categories
* Create and submit requests
* Attach PDF and image documents
* View submitted requests
* User profile management
* Find pharmacies
* Location and map integration
* Emergency calling
* Cross-platform UI

## Tech Stack

* **C# / .NET 7**
* **.NET MAUI**
* **XAML**
* **MVVM**
* **CommunityToolkit.Mvvm**
* **REST API**
* **JWT**
* **Newtonsoft.Json**
* **Mopups**

## Project Structure

```text
ApplicationCMCM/
├── MVVM/
│   ├── Models/
│   ├── ViewModels/
│   └── Views/
│
├── Services/
├── CustomConstants/
├── Resources/
├── Platforms/
├── App.xaml
├── AppShell.xaml
└── MauiProgram.cs
```

## Supported Platforms

The project targets:

* Android
* iOS
* macOS
* Windows

## Getting Started

Make sure you have the appropriate **.NET MAUI workload** installed.

```bash
git clone https://github.com/Mohsen-Arshad/MobileApplicationCMCM.git
cd MobileApplicationCMCM
dotnet restore
```

Open the project in **Visual Studio** and select the desired target platform to build and run the application.

> The application requires the CMCM Web API to be configured and accessible.

---

### A Starting Point

This was my first mobile application and one of the projects that helped me learn **C#, .NET MAUI, XAML, MVVM, API integration, and cross-platform application development**.

It remains in my GitHub as part of my programming journey and the starting point of my mobile development experience.
