#include <iostream>
#include "Cal_header.h"
#include <string>
#include "Color_header.h"
#include <iomanip>
using namespace std;

void PrintWhole();

int main()
{
	PrintWhole();
}


void SetColorWeekday(int _year, int _month, int _day) //요일별 색깔 적용하는 함수
{
	if (GetDayOfTheWeek(_year, _month, _day) == 0)
	{
		setColor(RED);
	}
	else if (GetDayOfTheWeek(_year, _month, _day) == 6)
	{
		setColor(BLUE);
	}
	else
	{
		setColor(WHITE);
	}
}
void PrintYearMonth(int _year, int _month) // 달력이 월과 일을 표시해주는 함수

{
	cout << "	" << setw(4)<<_year << "년 " << _month + 1 << "월	\t";
}
void PrintLine() // 구분선을 표시해주는 함수
{
	cout << "-----------------------------\t";
}
void PrintWeekDay() //요일을 출력하는 함수
{
	setColor(RED);
	cout << " sun";
	setColor(WHITE);
	cout << " mon tue wed thu fri";
	setColor(BLUE);
	cout << " sat\t";
	setColor(WHITE);
}
int PrintFirstLine(int _year, int _month, int _day) // 달력의 첫번째 줄을 출력하는 함수
{
	int a = 0;
	for (int i = 0; i < GetDayOfTheWeek(_year, _month, 1); i++)
	{
		cout << "    ";
		a = i + 1;
	}
	for (int i = 1; i < 8 - a; i++)
	{
		SetColorWeekday(_year, _month, i);
		cout << setw(4) << i;
		_day = i;
	}
	cout << "\t";

	return _day + 1;
}

int PrintMiddleLine(int _year, int _month, int _day)//2번째줄에서 4번째줄까지는 코드가 같기 때문에 통일시켜준다.
{
	for (int i = _day; _day < i + 7; _day++)
	{
		SetColorWeekday(_year, _month, _day);
		cout << setw(4) << _day;
		setColor(WHITE);
	}
	cout << "\t";
	return _day;
}
int PrintLastLine(int _year, int _month,int _day)//5번째줄이랑 6번째줄 출력하는 함수
{
	int a = 0;
	for (_day; _day < Month_day(_year, _month) + 1; _day++)
	{
		SetColorWeekday(_year, _month, _day);
		cout << setw(4) << _day;
		a++;
		setColor(WHITE);
		if (a == 7)
		{
			_day++;// 이미 day가 찍힌 상황이기 때문에 브레이크를 넣기 전에 1을 더해줘야 다음행에서 중복이 되지 않는다. 
			break;
		}
	}
	for (int i = 0; i < 7 - a; i++)
	{
		cout << "    ";
	}
	cout << "\t";
	return _day;
}
//int PrintRepeatDT(int _year, int _month,int _column,int month_day[],int(*_fuc)(int __year,int __month,int __day)) {
//	for (int i = _month; i < _month+ _column; i++)
//	{
//		month_day[i - _month] = _fuc(_year, i + 1, month_day[i - _month]);
//		return month_day[i - _month];//?
//	}
//	
//}

void PrintMonth(int _year, int _month, int _column) //월별로 출력하는 형태, 달력의 출력을 원하는 대로 만들기 위해서 
{
	int* month_day = new int[_column];
	for (int i = 0; i < _column; i++)
	{
		month_day[i] = 1;
	}
	_month -= 1;//배열의 시작은 0이기 때문에 -1을 해준다. => 필요없음
	for (int i = _month; i < _month + _column; i++)
	{
		PrintYearMonth(_year, i);
	}
	cout << "\n";
	for (int i = _month; i < _month + _column; i++)
	{
		PrintLine();
	}
	cout << "\n";

	for (int i = _month; i < _month + _column; i++)
	{
		PrintWeekDay();
	}
	cout << "\n";

	for (int i = _month; i < _month + _column; i++)
	{
		PrintLine();
	}
	cout << "\n";
	
	for (int i = _month; i < _month + _column; i++)
	{
		month_day[i - _month] = PrintFirstLine(_year, i + 1, month_day[i - _month]);
	}
	cout << "\n";
	for (int i = _month; i < _month + _column; i++)
	{
		month_day[i - _month] = PrintMiddleLine(_year, i + 1, month_day[i - _month]);
	} 
	cout << "\n";
	for (int i = _month; i < _month + _column; i++)
	{
		month_day[i - _month] = PrintMiddleLine(_year, i + 1, month_day[i - _month]);
	}
	cout << "\n";
	for (int i = _month; i < _month + _column; i++)
	{
		month_day[i - _month] = PrintMiddleLine(_year, i + 1, month_day[i - _month]);
	}
	cout << "\n";
	for (int i = _month; i < _month + _column; i++)
	{
		month_day[i - _month] = PrintLastLine(_year, i + 1, month_day[i - _month]);
	}
	cout << "\n";
	for (int i = _month; i < _month + _column; i++)
	{
		month_day[i - _month] = PrintLastLine(_year, i + 1, month_day[i - _month]);
	}
	cout << "\n";
	
	//2021-11-16 박규민 첫번째 줄까지 완료
	//3월까지 완성

	return;
}


void PrintWhole() // 해당년도 달력 전체를 출력하는 함수
{

	while (true)
	{
		int year;
		int column;
		cout << ">연도를 입력하시오 (0을 입력하면 종료) : ";
		cin >> year;
		cout << ">출력하고 싶은 열의 수를 입력하시오(1,2,3,4,6,12만 가능) : ";
		
		cin >> column;
		if (column==1|| column == 2|| column == 3 || column == 4 || column == 6 || column == 12)
		{
			if (year == 0)
			{
				break;
			}
			for (int i = 1; i < 13; i += column)
			{
				PrintMonth(year, i, column);

			}

			cout << "\n";
		}
		else
		{
			cout << "열의 숫자가 틀렸습니다. 다시 입력해주세요\n";
		}
	}
}

