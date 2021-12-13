using System;
using System.Collections.Generic;
using System.Text;
using static Maple.GameInstance;
namespace Maple
{
    class Character
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string job;
        public string Job
        {
            get { return job; }
            set { job = value; }
        }

        private int hp;
        private int mp;
        private int level;
        private int str;//힘
        private int dex;
        private int inte;
        private int luk;

        public void initStat(string _name, string _job, int _hp, int _mp, int _level, int _str, int _dex, int _inte, int _luk)
        {
            name = _name;
            job = _job;
            hp = _hp;
            mp = _mp;
            level = _level;
            str = _str;
            dex = _dex;
            inte = _inte;
            luk = _luk;
            Console.WriteLine("{0} 이름의 {1}가(이) 생성되었습니다.", Name, Job);
            //캐릭터의 직업에 따라 마을 위치를 바꿔주도록 한다.
            switch (_job)
            {
                case "warrior":
                    Instance.Position = new Perion();
                    break;
                case "archer":
                    Instance.Position = new Henesis();
                    break;
                case "thief":
                    Instance.Position = new CunningCity();
                    break;
                case "magician":
                    Instance.Position = new Ellinia();
                    break;
            }
        }
    }
}
