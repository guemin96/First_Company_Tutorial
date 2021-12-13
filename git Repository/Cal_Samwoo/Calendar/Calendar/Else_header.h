#pragma once
#include "Color_header.h"


class YoonYearBasicCD {

	bool IsYoonYear(int _year) {
		return (_year % 4 == 0 && _year % 100 != 0) || (_year % 400 == 0);
	}//������ �´��� �ƴ��� �Ǵ����ִ� �Լ�
	int MonthDay(int _year, int _month) {//������ ��¥���� �����ִ� �ڵ�
		int m[] = { 31,28,31,30,31,30,31,31,30,31,30,31 };
		if (IsYoonYear(_year))
			m[1] = 29;
		//m[1] = Yoon_year(year) ? 29 : 28;// �������� ������ �Ǹ� 29�Ϸ� �ٲ��ְ� �ƴϸ� 28�Ϸ� �־��ش�.
		return m[_month - 1]; // �迭�̱� ������ 1���� ��� m[0]�� �����Ͱ� �ֱ� ������ -1�� �� ���ش�.
	}

	int TotalDay(int _year, int _month, int _day) {
		int total_day = 0;
		int last_year = _year - 1;
		total_day = last_year * 365 + (last_year / 4) - (last_year / 100) + (last_year / 400);
		// ������ ��쿡 366���̱� ������ �Ϸ羿 ���������(��������� ��¥���� �� ������)
		for (int i = 1; i < _month; i++)
		{
			total_day += GetMonthDay(_year, i);//���⵵�� ���� ��¥��ŭ ������

		}
		return total_day + _day;//���� ���� ��¥��ŭ ������
	}
	int DayOfTheWeek(int _year, int _month, int _day) {
		return GetTotalDay(_year, _month, _day) % 7; //1��1��1���� ������
	}
	void ColorWeekday(int _year, int _month, int _day) //���Ϻ� ���� �����ϴ� �Լ�
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



