using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Context context;
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            Console.ReadKey();*/
            St_Unit unit = new St_Unit(new MoveLand(),new Attack());
            unit.Move();
            unit.Attack();

            unit = new St_Unit(new MoveLand(), new NoAttack());
            unit.Move();
            unit.Attack();

            unit = new St_Unit(new MoveSky(), new Attack());
            unit.Move();
            unit.Attack();

            unit = new St_Unit(new MoveLand(), new SpecialAttack());
            unit.Move();
            unit.Attack();

            Console.ReadKey();
        }
    }
    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");

        }
    }
    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");

        }
    }
    class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }
        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}
