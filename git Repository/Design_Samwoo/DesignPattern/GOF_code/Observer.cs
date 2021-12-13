using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();
        public void Attach(Observer observer) // 옵저버 추가 코드
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer) //  옵저버 삭제 코드
        {
            _observers.Remove(observer);
        }
        public void Notify()// 옵저버 알림
        {
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }
       
    }
    class ConcreteSubject : Subject
    {
        private string _subjectState;
        public string SubjectState
        {
            set { _subjectState = value;  }
            get { return _subjectState; }
        }
    }
    abstract class Observer
    {
        public abstract void Update();
    }
    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }
        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}", _name, _observerState);
        }
        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }

    
}
