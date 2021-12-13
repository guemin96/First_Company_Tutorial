using System;
using System.Collections.Generic;
using System.Text;

namespace Maple
{
    abstract class CharacterFactory
    {
        public abstract Character Create(string _name, string _job);
        //추상 함수이므로 선언만 가능
    }
    //MakeCharacter 안에 Charactor라는 타입을 가진 함수를 만들어놨기
    //때문에 캐릭터매니저에서 create 함수 사용 가능
    class MakeCharacter : CharacterFactory
    {
        public override Character Create(string _name, string _job)
        {
            switch (_job)
            {
                case "warrior":
                    return new Warrior(_name);
                case "archer":
                    return new Archer(_name);
                case "thief":
                    return new Thief(_name);
                case "magician":
                    return new Magician(_name);
            }
            return null;
        }
    }
    class Warrior : Character
    {
        public Warrior(string _name)
        {
            initStat(_name, "warrior", 500, 100, 1, 20, 15, 5, 5);
        }
    }
    class Archer : Character
    {
        public Archer(string _name)
        {
            initStat(_name, "archer", 400, 100, 1, 10, 20, 5, 10);
        }
    }
    class Thief : Character
    {
        public Thief(string _name)
        {
            initStat(_name, "thief", 400, 100, 1, 10, 10, 5, 25);
        }
    }
    class Magician : Character
    {
        public Magician(string _name)
        {
            initStat(_name, "magician", 250, 200, 1, 5, 5, 35, 10);
        }
    }

}
