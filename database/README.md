# Database

This directory contains the Microsoft SQL Server database schema used in the Smart Home Temperature Monitoring System.

## Database Name


## Tables

### kayit_tbl

Stores user account information.

| Column | Description |
|---------|-------------|
| user_name | Username |
| password | User password |
| name | First name |
| last_name | Last name |
| mail | Email address |

---

### Temperature_tbl

Stores temperature measurements received from the STM32 device.

| Column | Description |
|---------|-------------|
| Id | Primary Key |
| Room | Room name |
| Temperature | Temperature value |
| Timestamp | Measurement date and time |

---

## Purpose

The database stores user information and historical temperature measurements collected by the embedded system, enabling both desktop and web applications to display current and past sensor data.