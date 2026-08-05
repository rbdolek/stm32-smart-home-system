# STM32 Firmware

This directory contains the embedded firmware developed for the **STM32F407 Discovery Board**. The firmware is responsible for acquiring temperature data from the **LM75BD digital temperature sensor**, displaying the measurements on an LCD and transmitting real-time data to a host computer via UART communication.

The firmware was developed as part of an IoT-based Smart Home Temperature Monitoring System and follows a modular architecture to improve readability, maintainability and scalability.

---

## Features

- Real-time temperature acquisition
- LM75BD digital temperature sensor integration
- I²C communication
- UART communication
- LCD temperature display
- Modular firmware architecture
- Hardware abstraction using STM32 HAL
- Periodic temperature transmission

---

## Firmware Architecture

```
LM75BD Temperature Sensor
           │
         I²C Bus
           │
           ▼
 STM32F407 Discovery Board
           │
   ┌───────┴────────┐
   │                │
   ▼                ▼
LCD Display      UART Output
                     │
                     ▼
             Desktop Application
```

---

## Folder Structure

```
firmware/

├── README.md
├── architecture.md
├── main.c
├── lm75.c
├── lm75.h
├── uart.c
├── uart.h
├── lcd.c
└── lcd.h
```

---

## Source Files

### `main.c`

Main application entry point.

Responsible for:

- Peripheral initialization
- System startup
- Main execution loop
- Temperature monitoring

---

### `lm75.c / lm75.h`

LM75BD sensor driver.

Provides:

- Sensor initialization
- Temperature acquisition
- Raw data conversion
- Celsius calculation

---

### `uart.c / uart.h`

UART communication module.

Provides:

- Serial communication
- Formatted temperature transmission
- Host computer communication

---

### `lcd.c / lcd.h`

LCD display module.

Provides:

- Temperature visualization
- User messages
- LCD interface functions

---

## Development Environment

| Component | Description |
|-----------|-------------|
| IDE | STM32CubeIDE |
| MCU | STM32F407 Discovery |
| Language | C |
| HAL Library | STM32 HAL |
| Sensor | LM75BD |
| Communication | I²C |
| Communication | UART |

---

## Main Workflow

```
System Initialization
        │
        ▼
Initialize GPIO
        │
        ▼
Initialize I²C
        │
        ▼
Initialize UART
        │
        ▼
Read Temperature
        │
        ▼
Display on LCD
        │
        ▼
Send via UART
        │
        ▼
Delay (1000 ms)
        │
        ▼
Repeat
```

---

## Engineering Principles

The firmware was designed according to the following principles:

- Modular design
- Readable source code
- Hardware abstraction
- Maintainability
- Code reusability
- Scalability

---

## Notes

This firmware is shared for educational and portfolio purposes. Project-specific configurations and confidential information have been removed.