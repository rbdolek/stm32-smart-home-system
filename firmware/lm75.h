#ifndef __LM75_H
#define __LM75_H

#ifdef __cplusplus
extern "C" {
#endif

#include "stm32f4xx_hal.h"

/* I2C Address */
#define LM75_ADDRESS (0x48 << 1)

/* Function Prototypes */
HAL_StatusTypeDef LM75_Init(I2C_HandleTypeDef *hi2c);
float LM75_ReadTemperature(I2C_HandleTypeDef *hi2c);

#ifdef __cplusplus
}
#endif

#endif /* __LM75_H */