#include "lm75.h"
#include "uart.h"
#include "lcd.h"

...

LM75_Init(&hi2c1);

while(1)
{
    float temperature;

    temperature = LM75_ReadTemperature(&hi2c1);

    LCD_DisplayTemperature(temperature);

    UART_SendTemperature(&huart2, temperature);

    HAL_Delay(1000);
}