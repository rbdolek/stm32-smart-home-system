#ifndef __LCD_H
#define __LCD_H

#ifdef __cplusplus
extern "C" {
#endif

#include "stm32f4xx_hal.h"

/* Function Prototypes */
void LCD_DisplayTemperature(float temperature);
void LCD_ShowMessage(char *line1, char *line2);

#ifdef __cplusplus
}
#endif

#endif /* __LCD_H */