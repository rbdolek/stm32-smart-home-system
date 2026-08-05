#ifndef __UART_H
#define __UART_H

#ifdef __cplusplus
extern "C" {
#endif

#include "stm32f4xx_hal.h"

/* Function Prototypes */
void UART_SendMessage(UART_HandleTypeDef *huart, char *message);
void UART_SendTemperature(UART_HandleTypeDef *huart, float temperature);

#ifdef __cplusplus
}
#endif

#endif /* __UART_H */