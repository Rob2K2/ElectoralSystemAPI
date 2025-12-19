# 🗳️ Electoral System API

![.NET 9](https://img.shields.io/badge/.NET-9.0-512bd4?style=for-the-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/EF%20Core-9.0-512bd4?style=for-the-the-badge&logo=dotnet)
![Status](https://img.shields.io/badge/Status-In%20Development-yellow?style=for-the-the-badge)

**A robust, secure, and transparent backend solution for electoral processes, built with modern architectural patterns.**

---

## 📖 Table of Contents
* [Overview](#overview)
* [Key Features](#-key-features)
* [Architecture](#-architecture)
* [Tech Stack](#-tech-stack)

---

## 🌟 Overview
The **Electoral System API** is a high-performance backend designed to handle the complexities of voting systems. It ensures **data integrity** and **full auditability** of every transaction through an automated history tracking system.

---

## ✨ Key Features

* **🛡️ Global Audit Pipeline:** Automatically captures **OldValue** and **NewValue** for every change using **MediatR Behaviors**.
* **🧩 CQRS Architecture:** Complete separation of concerns between Commands and Queries.
* **📂 Dynamic Repositories:** Uses **C# Reflection** to handle data access dynamically across different entities.
* **⚡ Optimized Performance:** Data retrieval implemented with **.AsNoTracking()** to prevent memory overhead and tracking conflicts.
* [cite_start]**🧪 Reliable Foundation:** Backend logic covered with **Unit Testing (MSTest & Moq)**.

---

## 🏛️ Architecture
This project follows **Clean Architecture** principles, ensuring that the business logic is independent of external frameworks.



### **Technical Highlights:**
* **Generic Audit Interceptor:** Instead of manual logging, a **Pipeline Behavior** intercepts requests to provide transparent traceability.
* **Dynamic Read Services:** A specialized `ReadRepository` was developed to fetch any entity type at runtime using **advanced Reflection techniques**.

---

## 💻 Tech Stack

| Category | Technology |
| :--- | :--- |
| **Backend** | [cite_start]**C#, .NET 9, MVC**  |
| **ORM** | [cite_start]**Entity Framework Core, LINQ**  |
| **Database** | [cite_start]**SQL Server**  |
| **Frontend** | [cite_start]**React, TypeScript, Vite**  |
| **Testing** | [cite_start]**MSTest, Moq, Jest**  |
| **Patterns** | **CQRS, MediatR, Repository Pattern** |
