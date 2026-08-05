/******************************************************************************
 * @file    uart.c
 * @brief   UART Communication Driver
 * @author  Rabia Dölek
 *
 * Description:
 * This module provides UART communication functions used for
 * transmitting sensor data to a host computer.
 ******************************************************************************/

#include "uart.h"

#include <stdio.h>
#include <string.h>

/**
 * @brief Sends a text message via UART.
 * @param huart Pointer to UART handle.
 * @param message Pointer to message.
 */
void UART_SendMessage(UART_HandleTypeDef *huart, char *message)
{
    HAL_UART_Transmit(
        huart,
        (uint8_t *)message,
        strlen(message),
        HAL_MAX_DELAY);
}

/**
 * @brief Sends formatted temperature value.
 * @param huart UART Handle
 * @param temperature Temperature value
 */
void UART_SendTemperature(UART_HandleTypeDef *huart, float temperature)
{
    char buffer[50];

    sprintf(
        buffer,
        "Temperature : %.2f C\r\n",
        temperature);

    UART_SendMessage(huart, buffer);
}