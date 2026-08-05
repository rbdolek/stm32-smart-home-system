<p align="center">
  <img src="images/banner.png" width="100%">
</p>

# Smart Home IoT System Using STM32 and ASP.NET

> **Engineering Case Study**  
> Embedded Systems • Internet of Things (IoT) • Real-Time Monitoring • Web Application Development • Database Integration

---

# Executive Summary

The increasing demand for smart environments has accelerated the adoption of Internet of Things (IoT) technologies across residential and industrial applications. Modern monitoring systems require reliable communication between embedded hardware, software applications, and users while providing real-time access to environmental data.

This project presents the design and implementation of an IoT-based Smart Home Monitoring System developed during an industrial internship. The system integrates an STM32 microcontroller, digital temperature sensing, database management, and a desktop/web application into a unified monitoring platform.

Temperature data acquired from the embedded device is transmitted to a software application through serial communication, stored in a relational database, and presented to users via an intuitive graphical interface. The solution demonstrates the integration of embedded software, communication protocols, database technologies, and application development within a single engineering project.

To maintain confidentiality, all organization-specific information, source code unrelated to the demonstrated architecture, and proprietary implementation details have been removed. This repository focuses exclusively on the engineering methodology, system architecture, and technical decisions employed throughout the project.

---

# Business Problem

Environmental monitoring plays an important role in modern intelligent buildings and industrial facilities. Manual observation of environmental conditions is inefficient, time-consuming, and does not provide continuous feedback for decision-making.

Organizations require monitoring systems capable of collecting sensor data automatically, storing historical information, and presenting meaningful insights through software applications.

The objective of this project was to develop a prototype demonstrating how embedded hardware, software systems, and database technologies can work together to provide an integrated smart monitoring solution.

---

# Project Objectives

The primary objectives of this project were to:

- Design an embedded monitoring system using the STM32F407 microcontroller.
- Acquire temperature measurements from a digital sensor through I²C communication.
- Display sensor information locally using an LCD module.
- Transmit sensor data to a computer through UART communication.
- Store measurements within a Microsoft SQL Server database.
- Develop a desktop application for user authentication and real-time monitoring.
- Build a web-based interface for accessing environmental information.
- Demonstrate the practical integration of embedded systems and software engineering principles within an IoT architecture.

---

# My Role

During this project, I actively participated in both hardware and software development activities.

My responsibilities included:

- Developing embedded software using STM32CubeIDE.
- Configuring I²C communication for digital temperature acquisition.
- Implementing UART communication between the embedded device and the computer.
- Integrating the temperature sensor with the STM32 development board.
- Designing and developing the desktop monitoring application in C#.
- Creating the SQL Server database structure for sensor data storage.
- Developing user authentication functionality.
- Implementing a web interface for monitoring environmental information.
- Testing communication between hardware and software components.
- Preparing technical documentation throughout the development process.

---

# System Architecture

The Smart Home IoT System consists of multiple hardware and software components working together to provide real-time environmental monitoring.

```text
                    ┌─────────────────────┐
                    │   LM75BD Sensor     │
                    │ Temperature Sensor  │
                    └──────────┬──────────┘
                               │
                          I²C Communication
                               │
                               ▼
                    ┌─────────────────────┐
                    │ STM32F407 Discovery │
                    │   Embedded System   │
                    └───────┬─────┬───────┘
                            │     │
                       I²C LCD    UART
                            │     │
                            ▼     ▼
                 ┌─────────────┐  USB-TTL
                 │ 16x2 LCD    │      │
                 └─────────────┘      ▼
                           ┌─────────────────────┐
                           │ C# WinForms Client  │
                           └──────────┬──────────┘
                                      │
                                      ▼
                           ┌─────────────────────┐
                           │ Microsoft SQL Server│
                           └──────────┬──────────┘
                                      │
                                      ▼
                           ┌─────────────────────┐
                           │ ASP.NET Web System  │
                           └──────────┬──────────┘
                                      │
                                      ▼
                           ┌─────────────────────┐
                           │      End User       │
                           └─────────────────────┘
```
