using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    abstract class Component
    {
        public abstract void Operation();
    }
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }
    class Decorator : Component
    {
        protected Component component;
        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }
    class ConcreteDecoratorA :Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");

        }
        void AddedBehavior()
        {
        }
    }
}
