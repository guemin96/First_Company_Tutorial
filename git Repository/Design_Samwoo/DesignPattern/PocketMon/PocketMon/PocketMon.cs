using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    public class PocketMon
    {
        private string name;
        private string type;

        //private int exp;
        private int level;
        private int life;
        private int power;
        private int amor;
        private int attack; 
        
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        public int Amor
        {
            get { return amor; }
            set { amor = value; }
        }
        public string GetName()
        {
            return name;
        }
        //public string GetNameK()
        //{
        //    switch (name)
        //    {
        //        case "Pikachu":
        //            return "피카츄";
        //        case "Pairi":
        //            return "파이리";
        //        case "Gobugi":
        //            return "꼬부기";
        //        case "Esanghesi":
        //            return "이상해씨";
              
        //    }
        //    return null;
        //}
        
        public void initPocketMon(string _name,string _type, int _level, int _power, int _amor,int _life)
        {
            this.name = _name;
            this.type = _type;
            this.level = _level;
            this.power = _power;
            this.amor = _amor;
            this.attack = _power;
            this.life = _life;
        }
        //public abstract void SkillShot();

    }
}
