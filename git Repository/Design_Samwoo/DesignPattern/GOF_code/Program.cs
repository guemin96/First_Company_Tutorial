using System;
using System.Collections.Generic;

namespace GOF_code
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 팩토리 패턴
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }*/
            /*옵저버 패턴
            ConcreteSubject s = new ConcreteSubject();
            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            s.SubjectState = "ABC";
            s.Notify();
            //Console.ReadKey();*/

            /*옵저버 패턴 예제
            Marine ourMarine = new Marine("아군마린", 100);
            ourMarine.Attach(new MainScreen());
            ourMarine.Attach(new StatusScreen());
            ourMarine.Attach(new EnemyScreen());
            
            ourMarine.Health = 60;

            ourMarine.Health = 40;

            Console.ReadKey();
            */
            /*추상 팩토리 
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);// 클라이언트를 통해서 productB와 productA를 생산
            client1.Run();//productB가 A와 상호작용한다는 것을 알려줌

            AbstractFactory factory2 = new ConcreteFactory2();
            Client clien2 = new Client(factory2);
            clien2.Run();

            Console.ReadKey();
            */
            /*추상 팩토리 예제
            Race terran = new Terran();
            Game game1 = new Game(terran);
            game1.Run();

            Race protoss = new Protoss();
            Game game2 = new Game(protoss);
            game2.Run();*/
            /*어댑터 예제
            Target target = new Adapter();
            target.Request();

            Console.ReadKey();
            */
            /*어댑터 스타크래프트 예제

            //using System.Collections.Generic; -> 이게 있어야 List를 사용가능
            List<NewUnit> myunit = new List<NewUnit>();
            myunit.Add(new NewUnit());
            myunit.Add(new A_Unit());// A_Unit은 기존 유닛을 NewUnit과 연결시켜주는 어댑터의 형식임으로 NewUnit을 상속받았다.

            foreach (NewUnit newUnit in myunit) 
            {
                newUnit.Move();
                newUnit.Stop();
            }*/
            /*데코레이터 예제
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.SetComponent(c);
            d2.SetComponent(d1);
            d2.Operation();

            Console.ReadKey(); */
            /*데코레이터 스타크래프트 예제*/
            De_Marine marine = new De_Marine();
            DefensiveMatrix defensiveMatrix = new DefensiveMatrix();

            defensiveMatrix.SetComponent(marine);

            defensiveMatrix.UnderAttack(50);
            defensiveMatrix.UnderAttack(50);
            defensiveMatrix.UnderAttack(50);

            Console.ReadKey();

        }
        abstract class Product
        {

        }
        class ConcreteProductA : Product
        {

        }
        class ConcreteProductB : Product
        {

        }
        abstract class Creator
        {
            public abstract Product FactoryMethod();
        }
        class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductA();
            }
        }
        class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductB();
            }
        }
    }
}
