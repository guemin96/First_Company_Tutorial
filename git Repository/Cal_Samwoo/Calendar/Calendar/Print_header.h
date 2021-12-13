#pragma once
using namespace std;
#include <iostream>
#include "Else_header.h"
#include "Color_header.h"
#include <iomanip>

class PrintCal {

	YoonYearBasicCD YBCD;//

	void PrintYearMonth(int _year, int _month) // �޷��� ���� ���� ǥ�����ִ� �Լ�

	{
		cout << "	" << setw(4) << _year << "�� " << _month + 1 << "��	\t";
	}
	void PrintLine() // ���м��� ǥ�����ִ� �Լ�
	{
		cout << "-----------------------------\t";
	}
	void PrintWeekDay() //������ ����ϴ� �Լ�
	{
		setColor(RED);
		cout << " sun";
		setColor(WHITE);
		cout << " mon tue wed thu fri";
		setColor(BLUE);
		cout << " sat\t";
		setColor(WHITE);
	}
	int PrintFirstLine(int _year, int _month, int _day) // �޷��� ù��° ���� ����ϴ� �Լ�
	{
		int a = 0;
		for (int i = 0; i < YBCD.GetDayOfTheWeek(_year, _month, 1); i++)
		{
			cout << "    ";
			a = i + 1;
		}
		for (int i = 1; i < 8 - a; i++)
		{
			YBCD.SetColorWeekday(_year, _month, i);
			cout << setw(4) << i;
			_day = i;
		}
		cout << "\t";

		return _day + 1;
	}

	int PrintMiddleLine(int _year, int _month, int _day)//2��°�ٿ��� 4��°�ٱ����� �ڵ尡 ���� ������ ���Ͻ����ش�.
	{
		for (int i = _day; _day < i + 7; _day++)
		{
			YBCD.SetColorWeekday(_year, _month, _day);
			cout << setw(4) << _day;
			setColor(WHITE);
		}
		cout << "\t";
		return _day;
	}
	int PrintLastLine(int _year, int _month, int _day)//5��°���̶� 6��°�� ����ϴ� �Լ�
	{
		int a = 0;
		for (_day; _day < YBCD.GetMonthDay(_year, _month) + 1; _day++)
		{
			YBCD.SetColorWeekday(_year, _month, _day);
			cout << setw(4) << _day;
			a++;
			setColor(WHITE);
			if (a == 7)
			{
				_day++;// �̹� day�� ���� ��Ȳ�̱� ������ �극��ũ�� �ֱ� ���� 1�� ������� �����࿡�� �ߺ��� ���� �ʴ´�. 
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


	void PrintMonth(int _year, int _month, int _column) //������ ����ϴ� ����, �޷��� ����� ���ϴ� ��� ����� ���ؼ� 
	{
		int* month_day = new int[_column];
		for (int i = 0; i < _column; i++)
		{
			month_day[i] = 1;
		}
		_month -= 1;//�迭�� ������ 0�̱� ������ -1�� ���ش�. => �ʿ����
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

		//2021-11-16 �ڱԹ� ù��° �ٱ��� �Ϸ�
		//3������ �ϼ�

		return;
	}
	void PrintWhole() // �ش�⵵ �޷� ��ü�� ����ϴ� �Լ�
	{

		while (true)
		{
			int year;
			int column;
			cout << ">������ �Է��Ͻÿ� (0�� �Է��ϸ� ����) : ";
			cin >> year;
			cout << ">����ϰ� ���� ���� ���� �Է��Ͻÿ�(1,2,3,4,6,12�� ����) : ";

			cin >> column;
			if (column == 1 || column == 2 || column == 3 || column == 4 || column == 6 || column == 12)
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
				cout << "���� ���ڰ� Ʋ�Ƚ��ϴ�. �ٽ� �Է����ּ���\n";
			}
		}
	}

public: // ��� Ŭ�������� ������ �Լ����� �� private���� �����ؼ� GetPrintWhole�Լ��� ���ؼ��� ������ �� �ֵ��� �Ѵ�. 
	void GetPrintWhole()
	{
		PrintWhole();
	}


};
