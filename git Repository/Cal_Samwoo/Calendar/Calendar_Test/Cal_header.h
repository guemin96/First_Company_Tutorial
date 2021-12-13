#pragma once
bool Yoon_year(int year) {
	return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}//윤년이 맞는지 아닌지 판단해주는 함수

int Month_day(int year, int month) {//월마다 날짜수를 정해주는 코드
	int m[] = { 31,28,31,30,31,30,31,31,30,31,30,31 };
	if (Yoon_year(year))
		m[1] = 29;
	//m[1] = Yoon_year(year) ? 29 : 28;// 윤년으로 판정이 되면 29일로 바꿔주고 아니면 28일로 넣어준다.
	return m[month - 1]; // 배열이기 때문에 1월의 경우 m[0]에 데이터가 있기 때문에 -1을 꼭 해준다.
}

int GetTotalday(int year, int month, int day) {
	int total_day = 0;
	int last_year = year - 1;
	total_day = last_year * 365 + (last_year / 4) - (last_year / 100) + (last_year / 400);
	// 윤년인 경우에 366일이기 때문에 하루씩 더해줘야함(전년까지의 날짜수를 다 더해줌)
	for (int i = 1; i < month; i++)
	{
		total_day += Month_day(year, i);//현년도의 월의 날짜만큼 더해줌

	}
	return total_day + day;//현재 월의 날짜만큼 더해줌
}
int GetDayOfTheWeek(int year, int month, int day) {
	return GetTotalday(year, month, day) % 7; //1년1월1일이 월요일
}


