using System;
using System.Collections.Generic;
using System.Text;
using static Maple.GameInstance;

namespace Maple
{
    abstract class IGameManager:Subject {
        Subject mapsub = new Subject();
        
       public abstract void Execute();
        public string GetPosition()
        {
            switch (Instance.Position.ToString())
            {
                case "Maple.Perion":
                    return "페리온";
                case "Maple.Ellinia":
                    return "엘리니아";
                case "Maple.Henesis":
                    return "헤네시스";
                case "Maple.CunningCity":
                    return "커닝시티";
                default:
                    break;
            }
            return null;
        }
        public void Move()
        {

            Console.Clear();
            Console.WriteLine("빅토리아로드 {0}에 오신것을 환영합니다.", GetPosition());
            //Instance.Subject.Notify();
            Console.WriteLine("갈 곳을 선택하시오. 1)마을 2)칭호");
            string input1 = Console.ReadLine();
            switch (input1)
            {
                case "1":
                    Console.WriteLine("갈 마을을 선택하시오");
                    Console.WriteLine("1)페리온 2)헤네시스 3)엘리니아 4)커닝시티");
                    string input = Console.ReadLine();
                    mapsub.Attach(new PostionObserver());

                    switch (input)
                    {
                        case "1":
                            Instance.Position = new Perion();
                            mapsub.MapNum = 1;
                            break;
                        case "2":
                            Instance.Position = new Henesis();
                            mapsub.MapNum = 2;
                            break;
                        case "3":
                            Instance.Position = new Ellinia();
                            mapsub.MapNum = 3;

                            break;
                        case "4":
                            Instance.Position = new CunningCity();
                            mapsub.MapNum = 4;
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("칭호 미구현");
                    break;
                default:
                    break;
            }
        }
    }; 
    //캐릭터 생성 -> 선택 후 나타나야할 부분
    class GameManager
    {
        public GameManager()
        {
           
        }
        //캐릭터 선택 후에 실행되는 첫번째 코드
        public void Execute()
        {
            ShowMenu();

        }

        //캐릭터가 생성될때 이미 위치를 설정해줌(직업에 따라 마을이 달라짐)
        public void ShowMenu()
        {
            Subject mapsub = new Subject();

            Console.Clear();
            Console.WriteLine("{0}의 현재 위치는 {1}입니다.", Instance.Character.Name, Instance.GetKPosition());
            Console.WriteLine("갈 곳을 선택하시오");
            Console.WriteLine("1.마을 2.던전(미구현) ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("갈 마을을 선택하시오");
                    Console.WriteLine("1)페리온 2)헤네시스 3)엘리니아 4)커닝시티");
                    string v_input = Console.ReadLine();

                    switch (v_input)
                    {
                        case "1":
                            Instance.Position = new Perion();
                            mapsub.MapNum = 1;
                            break;
                        case "2":
                            Instance.Position = new Henesis();
                            mapsub.MapNum = 2;
                            break;
                        case "3":
                            Instance.Position = new Ellinia();
                            mapsub.MapNum = 3;
                            break;
                        case "4":
                            Instance.Position = new CunningCity();
                            mapsub.MapNum = 4;
                            break;
                    }
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
            bool loop = true;
            while (loop)
            {
               // Console.Clear();
               //현재 포지션의 execute()함수를 실행시켜줌
                Instance.Position.Execute();
            }
        }

        //public string GetPosition()
        //{
        //    switch (Instance.Position.ToString())
        //    {
        //        case "Maple.Perion":
        //            return "페리온";
        //        case "Maple.Ellinia":
        //            return "엘리니아";
        //        case "Maple.Henesis":
        //            return "헤네시스";
        //        case "Maple.CunningCity":
        //            return "커닝시티";
        //        default:
        //            break;
        //    }
        //    return null;
        //}
        

    }
}
