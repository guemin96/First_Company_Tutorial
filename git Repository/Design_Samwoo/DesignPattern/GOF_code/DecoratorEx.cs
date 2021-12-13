using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    abstract class De_Unit
    {
        public int health = 100;
        public abstract void UnderAttack(int _Damage);
    }
    class De_Marine : De_Unit
    {
        public override void UnderAttack(int _Damage)
        {
            health -= _Damage;
            Console.WriteLine("남은 체력 : " + health.ToString() + ". 받은 데미지 : " + _Damage.ToString());
        }
    }
    abstract class UnitDecorator : De_Unit
    {
        protected De_Unit component;

        public void SetComponent(De_Unit component)
        {
            this.component = component;
        }
        public override void UnderAttack(int _Damage)
        {
            if (component != null)
            {
                component.UnderAttack(_Damage);
            }
        }
    }
    class DefensiveMatrix : UnitDecorator
    {
        private int addedHealth = 100;
        private int damage = 0;

        public override void UnderAttack(int _Damage)
        {
            CheckDefensiveMatrix(_Damage);
            base.UnderAttack(damage);
        }

         void CheckDefensiveMatrix(int _Damage)
        {
            int remainHealth = addedHealth - _Damage;

            if (remainHealth >= 0)
            {
                addedHealth -= _Damage;
                Console.WriteLine("보호막으로 데미지 " + _Damage.ToString() + " 모두 흡수 , 남은 보호막 : " + remainHealth.ToString());
                damage = 0;
            }
            else
            {
                if (addedHealth ==0)
                {
                    Console.WriteLine("보호막으로 흡수 못함, 남은 보호막 : 0");
                    damage = _Damage;
                }
                else
                {
                    Console.WriteLine("보호막으로 데미지 " + (_Damage - addedHealth).ToString() + "만 흡수, , 남은 보호막 : 0");
                    damage = _Damage - addedHealth;
                    addedHealth = 0;
                }
            }
        }

    }
}
