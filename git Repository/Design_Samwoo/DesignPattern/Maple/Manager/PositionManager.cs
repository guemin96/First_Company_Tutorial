using System;
using System.Collections.Generic;
using System.Text;
using static Maple.GameInstance;

namespace Maple
{
    class Subject
    {
        //옵저버들 넣어주는 변수
        private List<Observer> observers = new List<Observer>();
        //옵저버 넣어주는 함수
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        //옵저버 삭제해주는 함수
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        //상태변화시 알림기능해주는 함수
        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update(this);
            }
        }
        //맵(마을)에 번호
        private int mapNum;
        public int MapNum
        {
            get { return mapNum; }
            set
            {
                mapNum = value;
                //맵 이동시 알림 기능을 넣어줌
                Notify();
            }
        }

    } 
    //옵저버 인터페이스
    interface Observer
    {
        void Update(Subject _subject);
    }
    //위치 옵저버 클래스
    //위치 변화시 알림기능을 통해서 update문을 실행시켜주도록 한다.
    class PostionObserver : Observer
    {
        private Subject subject;
        public void Update(Subject _subject)
        {
            this.subject = _subject;
            Console.WriteLine("캐릭터가 이동중입니다. 잠시만 기다려주세요!");
            Console.WriteLine("곧 {0}에 도착하겠습니다.", Instance.GetKPosition());
            Console.ReadLine();
        }
        public Subject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        //맵번호에 따른 한글이름 출력
        //public string MapName()
        //{
        //    switch (subject.MapNum)
        //    {
        //        case 1:
        //            return "페리온";
        //        case 2:
        //            return "헤네시스";
        //        case 3:
        //            return "엘리니아";
        //        case 4:
        //            return "커닝시티";

        //    }
        //    return null;
        //}
    }
    class PositionManager
    {
    }
}
