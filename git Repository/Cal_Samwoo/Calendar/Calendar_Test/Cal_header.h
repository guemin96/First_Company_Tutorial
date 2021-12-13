#pragma once
bool Yoon_year(int year) {
	return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}//������ �´��� �ƴ��� �Ǵ����ִ� �Լ�

int Month_day(int year, int month) {//������ ��¥���� �����ִ� �ڵ�
	int m[] = { 31,28,31,30,31,30,31,31,30,31,30,31 };
	if (Yoon_year(year))
		m[1] = 29;
	//m[1] = Yoon_year(year) ? 29 : 28;// �������� ������ �Ǹ� 29�Ϸ� �ٲ��ְ� �ƴϸ� 28�Ϸ� �־��ش�.
	return m[month - 1]; // �迭�̱� ������ 1���� ��� m[0]�� �����Ͱ� �ֱ� ������ -1�� �� ���ش�.
}

int GetTotalday(int year, int month, int day) {
	int total_day = 0;
	int last_year = year - 1;
	total_day = last_year * 365 + (last_year / 4) - (last_year / 100) + (last_year / 400);
	// ������ ��쿡 366���̱� ������ �Ϸ羿 ���������(��������� ��¥���� �� ������)
	for (int i = 1; i < month; i++)
	{
		total_day += Month_day(year, i);//���⵵�� ���� ��¥��ŭ ������

	}
	return total_day + day;//���� ���� ��¥��ŭ ������
}
int GetDayOfTheWeek(int year, int month, int day) {
	return GetTotalday(year, month, day) % 7; //1��1��1���� ������
}


