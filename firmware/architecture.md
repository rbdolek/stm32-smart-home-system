# Firmware Architecture

## Overview

The firmware was developed for the STM32F407 Discovery Board to implement a real-time temperature monitoring system using the LM75BD digital temperature sensor.

The system periodically reads ambient temperature via the I²C communication protocol and transmits the processed measurements to an external computer through UART communication.

The firmware was designed with a modular architecture to improve readability, maintainability and future scalability.

---

# System Architecture

```
                LM75BD
          Temperature Sensor
                  │
               I²C Bus
                  │
                  ▼
        STM32F407 Discovery
                  │
      ┌───────────┴───────────┐
      │                       │
      ▼                       ▼
   LCD Display            UART Output
                              │
                              ▼
                     Desktop Application
                              │
                              ▼
                        SQL Server
                              │
                              ▼
                       ASP.NET Website
```

---

# Software Modules

The firmware is organized into independent software modules.

## main.c

Responsible for

- Peripheral initialization
- Program execution
- Calling sensor driver
- Calling UART driver
- Calling LCD driver

---

## lm75.c

Responsible for

- Sensor initialization
- Temperature acquisition
- Raw data conversion
- Celsius calculation

---

## uart.c

Responsible for

- Serial communication
- Data formatting
- Host computer communication

---

## lcd.c

Responsible for

- LCD initialization
- Temperature visualization
- User messages

---

# Data Flow

```
LM75 Sensor

↓

Raw Temperature Data

↓

Temperature Conversion

↓

Display on LCD

↓

UART Transmission

↓

Desktop Application

↓

SQL Database

↓

Web Dashboard
```

---

# Firmware Workflow

```
System Initialization

↓

Initialize GPIO

↓

Initialize I²C

↓

Initialize UART

↓

Initialize LCD

↓

Read Temperature

↓

Display Temperature

↓

Send Temperature via UART

↓

Delay (1000 ms)

↓

Repeat
```

---

# Design Principles

The firmware follows several embedded software engineering principles.

- Modular design
- Readable code
- Hardware abstraction
- Code reusability
- Maintainability
- Scalability

---

# Hardware Components

| Component | Description |
|------------|-----------------------------|
| STM32F407 Discovery | Main Microcontroller |
| LM75BD | Digital Temperature Sensor |
| LCD 16x2 | Temperature Display |
| UART | Serial Communication |
| I²C | Sensor Communication |

---

# Features

- Real-time temperature monitoring
- Digital temperature acquisition
- I²C communication
- UART communication
- LCD visualization
- Modular firmware architecture

---

# Future Improvements

Possible future enhancements include

- Wi-Fi connectivity
- MQTT support
- Cloud integration
- Mobile application
- Data logging to SD Card
- Remote monitoring
- Alarm notifications
- OTA firmware update

---

# Author

Rabia Dölek

Computer Engineer

Embedded Systems | IoT | Data Analytics