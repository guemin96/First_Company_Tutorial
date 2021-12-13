using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    //구체적인 클래스를 명시하지 않고도 연관되어 있거나 의존적인 객체 패밀리 생성을 위한 인터페이스 제공
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();

    }


    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
    abstract class AbstractProductA
    {

    }
    //추상클래스의 경우에는 public으로 사용하게 되면 main함수에서 Interact로 접근할때 오류가 생기므로 private로 설정해줘야 한다.
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }
    class ProductA1 : AbstractProductA
    {

    }
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }
    class ProductA2:AbstractProductA
    {
    }
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client(AbstractFactory factory)// 생성자
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }
        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }

}
