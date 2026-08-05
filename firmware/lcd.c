/******************************************************************************
 * @file    lcd.c
 * @brief   LCD Display Driver
 * @author  Rabia Dölek
 *
 * Description:
 * Displays temperature information on a 16x2 LCD.
 ******************************************************************************/

#include "lcd.h"

#include <stdio.h>

/* 
 * These functions are assumed to be provided by the LCD library.
 *
 * LCD_Clear();
 * LCD_SetCursor(row,column);
 * LCD_Print(char *);
 */

void LCD_DisplayTemperature(float temperature)
{
    char buffer[20];

    LCD_Clear();

    LCD_SetCursor(0,0);
    LCD_Print("Temperature");

    sprintf(buffer,"%.2f C",temperature);

    LCD_SetCursor(1,0);
    LCD_Print(buffer);
}

void LCD_ShowMessage(char *line1, char *line2)
{
    LCD_Clear();

    LCD_SetCursor(0,0);
    LCD_Print(line1);

    LCD_SetCursor(1,0);
    LCD_Print(line2);
}