using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    abstract class Moveable
    {
        public abstract void Move();
    }
    class MoveLand : Moveable
    {
        public override void Move()
        {
            Console.WriteLine("Move Land");
        }
    }
    class MoveSky : Moveable
    {
        public override void Move()
        {
            Console.WriteLine("Move Sky");
        }
    }
    abstract class Attackable
    {
        public abstract void AttackEnemy();
    }
    class Attack : Attackable
    {
        public override void AttackEnemy()
        {
            Console.WriteLine("Attack Enemy!");
        }
    }
    class NoAttack : Attackable
    {
        public override void AttackEnemy()
        {
            Console.WriteLine("Can not attack"); 
        }
    }
    class SpecialAttack : Attackable
    {
        public override void AttackEnemy()
        {
            Console.WriteLine("Medic can Special Attack!!");
        }
    }
    class St_Unit
    {
        private Moveable moveable;
        private Attackable attackable;

        public St_Unit(Moveable moveable, Attackable attackable)
        {
            this.moveable = moveable;
            this.attackable = attackable;
        }
        public void Attack()
        {
            attackable.AttackEnemy();
        }
        public void Move()
        {
            moveable.Move();
        }
        public Moveable Moveable
        {
            set { this.moveable = value; }
        }
        
    }
    class Marine : St_Unit
    {
        public Marine(Moveable moveable, Attackable attackable):base(moveable, attackable)
        {
            
        }
    }
    class Medic : St_Unit
    {
        public Medic(Moveable moveable, Attackable attackable) : base(moveable, attackable)
        { }
    }
    class Wrath : St_Unit
    {
        public Wrath(Moveable moveable, Attackable attackable) : base(moveable, attackable)
        { }
    }
}
