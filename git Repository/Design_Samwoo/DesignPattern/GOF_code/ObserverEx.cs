using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{

    abstract class Unit
    {
        private string name;
        private int health;
        private List<UnitViewer> unitViewers = new List<UnitViewer>();
        public Unit(string name, int health)
        {
            this.name = name;
            this.health = health;

        }
        public void Attach(UnitViewer investor)
        {
            unitViewers.Add(investor);
        }

        public void Detach(UnitViewer investor)
        {
            unitViewers.Remove(investor);
        }
        public void Notify()
        {
            foreach (UnitViewer unitViewer in unitViewers)
            {
                unitViewer.Update(this);
            }
        }

        //체력이 바뀌게 되면 notify 함수를 실행시켜줌 -> 그러면 notify함수에서 옵저버들을 업데이트시켜주는 함수를 실행시켜줌 
        public int Health
        {
            get { return health; }
            set { health = value;
                Notify();
            }
        }
        public string Name
        {
            get { return name; }
        }
    }
        class Marine: Unit
        {
            public Marine(string name, int health):base(name,health)
            {

            }
        }
        interface UnitViewer
        {
            void Update(Unit unit);
        }
        class MainScreen : UnitViewer
        {
            private Unit unit;
            public void Update(Unit _unit)
            {
                this.unit = _unit;
                Console.WriteLine("메인화면 {0} 상태변경 : 체력 {1}", this.unit.Name, this.unit.Health.ToString());
            }
            public Unit Unit
            {
                get { return unit; }
                set { unit = value; }
            }
        }
        class StatusScreen : UnitViewer
        {
            private Unit unit;
            public void Update(Unit _unit)
            {
                this.unit = _unit;
                Console.WriteLine("상태창 {0} 상태 변경 : 체력 {1}", this.unit.Name, this.unit.Health.ToString());
            }
            public Unit Unit
            {
                get { return unit; }
                set { unit = value; }
            }
        }
        class EnemyScreen : UnitViewer
        {
            private Unit unit;
            public void Update(Unit _unit)
            {
                this.unit = _unit;
                Console.WriteLine("적 상태창 {0} 상태 변경 : 체력{1}", this.unit.Name, this.unit.Health.ToString());
            }
            public Unit Unit
            {
                get { return unit; }
                set { unit = value; }
            }
        }
    
    
}

