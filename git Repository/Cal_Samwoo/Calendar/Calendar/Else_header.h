#pragma once
#include "Color_header.h"


class YoonYearBasicCD {

	bool IsYoonYear(int _year) {
		return (_year % 4 == 0 && _year % 100 != 0) || (_year % 400 == 0);
	}//윤년이 맞는지 아닌지 판단해주는 함수
	int MonthDay(int _year, int _month) {//월마다 날짜수를 정해주는 코드
		int m[] = { 31,28,31,30,31,30,31,31,30,31,30,31 };
		if (IsYoonYear(_year))
			m[1] = 29;
		//m[1] = Yoon_year(year) ? 29 : 28;// 윤년으로 판정이 되면 29일로 바꿔주고 아니면 28일로 넣어준다.
		return m[_month - 1]; // 배열이기 때문에 1월의 경우 m[0]에 데이터가 있기 때문에 -1을 꼭 해준다.
	}

	int TotalDay(int _year, int _month, int _day) {
		int total_day = 0;
		int last_year = _year - 1;
		total_day = last_year * 365 + (last_year / 4) - (last_year / 100) + (last_year / 400);
		// 윤년인 경우에 366일이기 때문에 하루씩 더해줘야함(전년까지의 날짜수를 다 더해줌)
		for (int i = 1; i < _month; i++)
		{
			total_day += GetMonthDay(_year, i);//현년도의 월의 날짜만큼 더해줌

		}
		return total_day + _day;//현재 월의 날짜만큼 더해줌
	}
	int DayOfTheWeek(int _year, int _month, int _day) {
		return GetTotalDay(_year, _month, _day) % 7; //1년1월1일이 월요일
	}
	void ColorWeekday(int _year, int _month, int _day) //요일별 색깔 적용하는 함수
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

public:
	int GetMonthDay(int _year, int _month) {
		return MonthDay(_year, _month);
	}
	int GetTotalDay(int _year, int _month, int _day) {
		return TotalDay(_year, _month, _day);
	}
	int GetDayOfTheWeek(int _year, int _month, int _day) {
		return DayOfTheWeek(_year, _month, _day);
	}
	void SetColorWeekday(int _year, int _month, int _day) {
		ColorWeekday(_year, _month, _day);
		return;
	}
	/*bool GetIsYoonYear(int _year) {
		return IsYoonYear(_year);
	}*/

};



