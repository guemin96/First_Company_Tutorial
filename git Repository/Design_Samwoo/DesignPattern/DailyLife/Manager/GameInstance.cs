using System;
using System.Collections.Generic;
using System.Text;

namespace DailyLife
{
    class GameInstance
    {
        private static GameInstance instance = null;

        private int hp;
        public int GetHp()
        {
            return hp;
        }
        public static GameInstance Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new GameInstance();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

    }
}
