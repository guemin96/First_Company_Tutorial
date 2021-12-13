using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
   abstract class Race
    {
        public abstract MainBuilding CreateMainBuilding();
        public abstract PopulationBuilding CreatePopulationBuilding();
    }
    class Terran : Race
    {
        public override MainBuilding CreateMainBuilding()
        {
            return new Commander();
        }

        public override PopulationBuilding CreatePopulationBuilding()
        {
            return new Supply();
        }
    }
    class Protoss : Race
    {
        public override MainBuilding CreateMainBuilding()
        {
            return new Nexus();
        }

        public override PopulationBuilding CreatePopulationBuilding()
        {
            return new Pylon();
        }
    }
    
    class MainBuilding
    {

    }
    class Commander:MainBuilding
    {

    }
    class Nexus :MainBuilding
    {

    }
    abstract class PopulationBuilding
    {
        public abstract void Interact(MainBuilding a);

    }
    class Supply :PopulationBuilding
    {
        public override void Interact(MainBuilding a)
        {
            Console.WriteLine(this.GetType().Name + " interact with " + a.GetType().Name);
        }
    }
    class Pylon : PopulationBuilding
    {
        public override void Interact(MainBuilding a)
        {
            Console.WriteLine(this.GetType().Name + " interact with " + a.GetType().Name);
        }
    }
    class Game
    {
        //메인,인구 건물에 해당하는 변수 만들어주기
        private MainBuilding mainBuilding;
        private PopulationBuilding populationBuilding;

       
        public Game(Race race)
        {
            mainBuilding = race.CreateMainBuilding();
            populationBuilding = race.CreatePopulationBuilding();
        }

        public void Run()
        {
            populationBuilding.Interact(mainBuilding);
        }

    }


}
