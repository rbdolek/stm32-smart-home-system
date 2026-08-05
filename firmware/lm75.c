/******************************************************************************
 * @file    lm75.c
 * @brief   LM75BD Temperature Sensor Driver
 * @author  Rabia Dölek
 *
 * Description:
 * This driver provides basic functions for communicating with the
 * LM75BD digital temperature sensor over the I2C interface.
 ******************************************************************************/

#include "lm75.h"

#define LM75_TEMP_REGISTER 0x00

/**
 * @brief Initializes the LM75 sensor.
 * @param hi2c Pointer to I2C handle.
 * @retval HAL status
 */
HAL_StatusTypeDef LM75_Init(I2C_HandleTypeDef *hi2c)
{
    if (HAL_I2C_IsDeviceReady(hi2c,
                              LM75_ADDRESS,
                              3,
                              HAL_MAX_DELAY) == HAL_OK)
    {
        return HAL_OK;
    }

    return HAL_ERROR;
}

/**
 * @brief Reads temperature from LM75 sensor.
 * @param hi2c Pointer to I2C handle.
 * @retval Temperature in Celsius
 */
float LM75_ReadTemperature(I2C_HandleTypeDef *hi2c)
{
    uint8_t buffer[2];

    int16_t rawTemperature;

    float temperature;

    /* Read temperature register */
    HAL_I2C_Mem_Read(
        hi2c,
        LM75_ADDRESS,
        LM75_TEMP_REGISTER,
        I2C_MEMADD_SIZE_8BIT,
        buffer,
        2,
        HAL_MAX_DELAY);

    /* Convert raw sensor data */
    rawTemperature = (buffer[0] << 8) | buffer[1];

    rawTemperature >>= 7;

    temperature = rawTemperature * 0.5f;

    return temperature;
}