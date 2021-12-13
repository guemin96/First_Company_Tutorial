using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    class NewUnit
    {
        public virtual void Move()
        {
            Console.WriteLine("새로운 유닛의 유닛움직이기입니다.");
        }
        public virtual void Stop()
        {
            Console.WriteLine("새로운 유닛의 유닛멈추기입니다.");

        }
    }
    //옛날 유닛을 움직이게 해주는 A_Unit 클래스를 새로 만들어준다.
    class A_Unit : NewUnit
    {
        OldUnit oldUnit = new OldUnit();// Oldunit을 생성해줘야한다.
        public override void Move()
        {
            oldUnit.MovetoPoint();
        }
        public override void Stop()
        {
            oldUnit.StopMove();
        }
    }
    class OldUnit
    {
        public void MovetoPoint()
        {
            Console.WriteLine("옛날 유닛의 유닛움직이기입니다.");

        }
        public void StopMove()
        {
            Console.WriteLine("옛날 유닛의 유닛멈추기입니다.");

        }

    }
}
