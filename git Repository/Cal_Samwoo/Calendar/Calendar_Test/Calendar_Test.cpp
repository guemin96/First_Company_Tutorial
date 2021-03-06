
#include <iostream>
#include "Cal_header.h"
#include <string>
#include "Color_header.h"
//#include <cctype>
using namespace std;

void Whole_PrintOut();

int main()
{
	Whole_PrintOut();
}


void Weekday_Color(int year, int month, int day) //요일별 색깔 적용하는 함수
{
	if (GetDayOfTheWeek(year, month, day) == 0)
	{
		setColor(RED);
	}
	else if (GetDayOfTheWeek(year, month, day) == 6)
	{
		setColor(BLUE);
	}
	else
	{
		setColor(WHITE);
	}
}
void Year_Month(int year, int month) // 달력이 월과 일을 표시해주는 함수

{
	printf("	%d년 %d월	\t", year, month);
}
void blank() // 구분선을 표시해주는 함수
{
	printf("-----------------------------\t");
}
void weekday() //요일을 출력하는 함수
{
	setColor(RED);
	printf(" sun");
	setColor(WHITE);
	printf(" mon tue wed thu fri");
	setColor(BLUE);
	printf(" sat\t");
	setColor(WHITE);
}
int FirstLine(int year, int month, int day) // 달력의 첫번째 줄을 출력하는 함수
{
	int a = 0;
	for (int i = 0; i < GetDayOfTheWeek(year, month, 1); i++)
	{
		printf("    ");
		a = i + 1;
	}
	for (int i = 1; i < 8 - a; i++)
	{
		Weekday_Color(year, month, i);
		printf("%4d", i);
		day = i;
	}
	printf("\t");


	return day + 1;
}

int MiddleLine(int year, int month, int day)//2번째줄에서 4번째줄까지는 코드가 같기 때문에 통일시켜준다.
{
	for (int i = day; day < i + 7; day++)
	{
		Weekday_Color(year, month, day);
		printf("%4d", day);
		setColor(WHITE);
	}
	printf("\t");

	return day;
}
int SecondLine(int year, int month, int day) // 달력의 두번째 줄을 출력하는 함수
{
	for (int i = day; day < i + 7; day++)
	{
		Weekday_Color(year, month, day);
		printf("%4d", day);
		setColor(WHITE);
	}
	printf("\t");

	return day;
}
int ThirdLine(int year, int month, int day) // 달력의 세번째 줄을 출력하는 함수
{
	for (int i = day; day < i + 7; day++)
	{
		Weekday_Color(year, month, day);
		printf("%4d", day);
		setColor(WHITE);
	}
	printf("\t");

	return day;
}
int  ForthLine(int year, int month, int day) // 달력의 네번째 줄을 출력하는 함수
{
	for (int i = day; day < i + 7; day++)
	{

		Weekday_Color(year, month, day);
		printf("%4d", day);
		setColor(WHITE);

	}
	printf("\t");

	return day;
}
int FifthLine(int year, int month, int day) // 달력의 다섯번째 줄을 출력하는 함수
{
	int a = 0;
	for (day; day < Month_day(year, month) + 1; day++)
	{
		Weekday_Color(year, month, day);
		printf("%4d", day);
		a++;
		setColor(WHITE);
		if (a == 7)
		{
			day++;// 이미 day가 찍힌 상황이기 때문에 브레이크를 넣기 전에 1을 더해줘야 다음행에서 중복이 되지 않는다. 
			break;
		}
	}
	for (int i = 0; i < 7 - a; i++)
	{
		printf("    ");
	}
	printf("\t");

	return day;
}
int SixthLine(int year, int month, int day) // 달력의 여섯번째 줄을 출력하는 함수
{
	int a = 0;
	for (day; day < Month_day(year, month) + 1; day++)
	{
		Weekday_Color(year, month, day);
		printf("%4d", day);
		a++;
		setColor(WHITE);
	}
	for (int i = 0; i < 7 - a; i++)
	{
		printf("    ");
	}
	printf("\t");
	return day;
}
void Month_OutPrint(int year, int month) //월별로 출력하는 형태
{
	int month_day[] = { 1,1,1 };//월별 날짜를 저장하는 배열
	month -= 1;//배열의 시작은 0이기 때문에 -1을 해준다. => 필요없음
	for (int i = month; i < month + 3; i++)
	{
		Year_Month(year, i);
	}
	printf("\n");
	for (int i = month; i < month + 3; i++)
	{
		blank();
	}
	printf("\n");

	for (int i = month; i < month + 3; i++)
	{
		weekday();
	}
	printf("\n");

	for (int i = month; i < month + 3; i++)
	{
		blank();
	}
	printf("\n");
	for (int i = month; i < month + 3; i++)
	{
		month_day[i - month] = FirstLine(year, i + 1, month_day[i - month]);
	}
	printf("\n");
	for (int i = month; i < month + 3; i++)
	{
		month_day[i - month] = SecondLine(year, i + 1, month_day[i - month]);
	}
	printf("\n");
	for (int i = month; i < month + 3; i++)
	{
		month_day[i - month] = ThirdLine(year, i + 1, month_day[i - month]);
	}
	printf("\n");
	for (int i = month; i < month + 3; i++)
	{
		month_day[i - month] = ForthLine(year, i + 1, month_day[i - month]);
	}
	printf("\n");
	for (int i = month; i < month + 3; i++)
	{
		month_day[i - month] = FifthLine(year, i + 1, month_day[i - month]);
	}
	printf("\n");
	for (int i = month; i < month + 3; i++)
	{
		month_day[i - month] = SixthLine(year, i + 1, month_day[i - month]);
	}
	printf("\n");

	//2021-11-16 박규민 첫번째 줄까지 완료
	//3월까지 완성

	return;
}
 

void Whole_PrintOut() // 해당년도 달력 전체를 출력하는 함수
{
	
	while (true)
	{
		int year;
		printf(">연도를 입력하시오 (0을 입력하면 종료) : ");
		cin >> year;
		if (year == 0)
		{
			break;
		}
		Month_OutPrint(year, 1);
		Month_OutPrint(year, 4);
		Month_OutPrint(year, 7);
		Month_OutPrint(year, 10);

		printf("\n");

	}
	

}


