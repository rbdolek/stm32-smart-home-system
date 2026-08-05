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
# Engineering Workflow

The development of the Smart Home IoT System followed a structured engineering approach that combined embedded systems, software development, and database integration.

```text
Requirements Analysis
          │
          ▼
Hardware Design
(STM32 + LM75BD + LCD)
          │
          ▼
Embedded Software Development
(STM32CubeIDE / C)
          │
          ▼
Communication Integration
(I²C + UART)
          │
          ▼
Desktop Application Development
(C# WinForms)
          │
          ▼
Database Design
(Microsoft SQL Server)
          │
          ▼
Web Application Development
(ASP.NET)
          │
          ▼
System Integration
          │
          ▼
Testing & Validation
          │
          ▼
Technical Documentation
```

---

## Engineering Process

The project was completed through several engineering phases.

### 1. Requirements Analysis

The system requirements were identified before development began. The primary objective was to build an integrated smart home monitoring system capable of collecting temperature data, storing measurements, and providing users with real-time monitoring capabilities.

---

### 2. Hardware Development

The embedded hardware platform was developed using the STM32F407 Discovery development board together with the LM75BD digital temperature sensor and a 16×2 I²C LCD module.

---

### 3. Embedded Software Development

Firmware was developed in STM32CubeIDE using the HAL library. The embedded software periodically acquired temperature measurements from the sensor and prepared the data for transmission.

---

### 4. Communication Integration

Two communication protocols were implemented:

- I²C for communication between the STM32 and the temperature sensor
- UART for transmitting sensor data to the desktop application

---

### 5. Desktop Application

A Windows desktop application was developed using C# WinForms. The application received temperature data, displayed current measurements, and interacted with the database.

---

### 6. Database Integration

Microsoft SQL Server was used to store historical temperature measurements together with user information required by the monitoring application.

---

### 7. Web Application

An ASP.NET web application was developed to provide users with remote access to environmental monitoring data through a user-friendly interface.

---

### 8. System Testing

The complete system was tested by validating communication between hardware, desktop software, database, and web application to ensure reliable data transmission and monitoring.

---

### 9. Documentation

Technical documentation was prepared throughout the project to describe the architecture, implementation process, and engineering decisions.


# Technical Implementation

The Smart Home IoT System was implemented by integrating embedded hardware, communication protocols, database technologies, and software applications into a single monitoring platform. Each system component was designed to perform a specific task while maintaining reliable communication with the remaining modules.

---

## Embedded System Development

The embedded hardware was built using the **STM32F407 Discovery** development board. The firmware was developed in **STM32CubeIDE** using the **STM32 HAL Library**, providing a modular and maintainable software architecture.

The microcontroller continuously monitored environmental temperature by communicating with a digital temperature sensor through the I²C protocol. Measured values were processed in real time and simultaneously transmitted to both the local display and the monitoring application.

Key embedded functionalities included:

- STM32 peripheral configuration
- GPIO initialization
- I²C communication
- UART communication
- Real-time temperature acquisition
- Continuous sensor monitoring
- LCD data visualization

---

## Temperature Sensor Integration

A **LM75BD Digital Temperature Sensor** was integrated into the embedded platform.

The sensor periodically measured ambient temperature and transmitted digital data to the STM32 through the I²C communication interface.

The acquired measurements became the primary data source for both local monitoring and database storage.

---

## LCD Interface

A **16×2 I²C LCD Display** was used to present real-time temperature information directly on the embedded device.

Displaying measurements locally allowed the system to remain usable even without access to the desktop application.

---

## Serial Communication

UART communication was implemented to establish data transfer between the STM32 development board and the desktop computer.

A USB-to-TTL converter was used as the communication bridge.

Temperature measurements were transmitted continuously to the monitoring application, enabling near real-time visualization.

---

## Desktop Application

A desktop monitoring application was developed using **C# Windows Forms**.

The application was responsible for:

- Receiving temperature measurements
- Displaying current sensor values
- Managing user authentication
- Accessing historical measurements
- Communicating with the SQL Server database

The graphical interface provided users with an intuitive environment for monitoring system status.

---

## Database Design

A **Microsoft SQL Server** database was designed to store both environmental measurements and user information.

The database enabled:

- Historical temperature tracking
- User account management
- Data persistence
- Future reporting capabilities

The structured database architecture improved data accessibility and simplified future system expansion.

---

## Web Application

A web application was developed using **ASP.NET** technologies to provide remote access to monitoring information.

The web interface allowed users to observe environmental data without requiring direct access to the embedded hardware.

This layer demonstrated how embedded systems can be integrated with modern web technologies to create IoT-based monitoring solutions.

---

## System Integration

After each subsystem had been completed individually, all hardware and software components were integrated into a unified architecture.

The complete system successfully demonstrated communication between:

- Temperature Sensor
- STM32 Embedded System
- LCD Display
- UART Communication
- Desktop Application
- SQL Server Database
- ASP.NET Web Application

The integration process verified that sensor data could be collected, transmitted, stored, and presented through multiple software interfaces.

---

## Testing and Validation

System validation focused on ensuring reliable communication between hardware and software components.

The following aspects were tested throughout development:

- Sensor communication accuracy
- UART data transmission
- LCD functionality
- Database connectivity
- Desktop application performance
- Web application functionality
- End-to-end system communication

Testing confirmed that the overall architecture operated as intended and successfully demonstrated the feasibility of the proposed IoT monitoring solution.


# System Features

The Smart Home IoT System was designed as a multi-layered IoT solution that combines embedded hardware, communication technologies, database management, and software applications into a unified monitoring platform.

The following features were implemented throughout the project.

---

## Real-Time Temperature Monitoring

The system continuously measures ambient temperature using the **LM75BD digital temperature sensor** connected to the STM32F407 microcontroller.

Temperature measurements are acquired periodically and processed in real time, providing users with up-to-date environmental information.

---

## Local LCD Display

A **16×2 I²C LCD module** displays the current temperature directly on the embedded device.

This enables immediate local monitoring without requiring access to a computer or web application.

---

## Embedded Data Acquisition

The STM32 embedded firmware continuously collects sensor data and manages communication between all hardware components.

The firmware was developed using the STM32 HAL Library, allowing modular and reliable peripheral management.

---

## Serial Data Communication

Temperature measurements are transmitted from the STM32 development board to the desktop application using **UART communication** through a USB-to-TTL converter.

This communication layer enables continuous data transfer between the embedded system and software application.

---

## Desktop Monitoring Application

A desktop application developed in **C# Windows Forms** provides users with an interface for monitoring temperature measurements.

The application includes:

- User authentication
- Real-time temperature display
- Historical measurement visualization
- Database connectivity

---

## Database Integration

Environmental measurements are stored within a **Microsoft SQL Server** database.

The database architecture supports:

- Persistent data storage
- Historical measurement records
- User account management
- Future reporting capabilities

---

## Web-Based Monitoring

An **ASP.NET web application** allows users to monitor environmental information remotely through a web browser.

The web interface extends the accessibility of the monitoring system beyond the desktop environment.

---

## Modular System Architecture

The project follows a modular architecture where each subsystem performs an independent responsibility while communicating with other system components.

This design improves:

- Maintainability
- Scalability
- System reliability
- Future development

---

## Integrated IoT Solution

The project demonstrates the integration of multiple engineering disciplines, including:

- Embedded Systems
- Sensor Integration
- Communication Protocols
- Desktop Application Development
- Database Management
- Web Development

The combination of these technologies provides a complete proof-of-concept IoT monitoring platform.

---

## Technical Documentation

Comprehensive technical documentation was prepared throughout the project, including:

- System architecture
- Communication flow
- Database design
- Software implementation
- Engineering methodology
- System evaluation

This documentation improves project maintainability and supports future development.
