#pragma once
#include <stdio.h>
#include <windows.h>

enum {
    BLACK,
    DARK_BLUE,
    DARK_GREEN,
    DARK_SKYBLUE,
    DARK_RED,
    DARK_VOILET,
    DAKR_YELLOW,
    GRAY,
    DARK_GRAY,
    BLUE,
    GREEN,
    SKYBLUE,
    RED,
    VIOLET,
    YELLOW,
    WHITE,
};
//콘솔 텍스트 색상 변경해주는 함수
void setColor(unsigned short text) {
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), text);
}