using System;
using System.Collections.Generic;
using System.Text;
using static Maple.GameInstance;
namespace Maple
{
    class CharactorManager
    {
        public void Execute()
        {
            //캐릭터를 생성하고 선택하는 창
            // while문을 통해서 계속 반복시켜주면서 캐릭터를 선택했을 경우에 반복문을 빠져나갈 수 있게 만들어준다.
            while (true)
            {
                
                Console.Clear();
                Console.WriteLine("캐릭터 선택(p) 캐릭터 생성(c)  캐릭터 삭제(d)");
                string input = Console.ReadLine();
                

                switch (input)
                {
                    case "p":
                        ShowCharacter();

                        break;
                    case "c":
                        AddCharactor();
                        break;
                    case "d":
                        RemoveCharacter();
                        break;
                }
                if (Instance.Character.Job!=null)
                {
                    break;
                }
            }
            

        }
        //캐릭터리스트에 캐릭터를 추가해주는 함수
        private void AddCharactor()
        {
            Console.Clear();
            Console.WriteLine("직업을 고르시오 ");
            Console.WriteLine("1)전사 2)궁수 3)도적 4)마법사");
            string inputJob = Console.ReadLine();

            switch (inputJob)
            {
                case "1":
                    inputJob = "warrior";
                    break;
                case "2":
                    inputJob = "archer";
                    break;
                case "3":
                    inputJob = "thief";
                    break;
                case "4":
                    inputJob = "magician";
                    break;
            }
            Console.WriteLine("캐릭터의 이름을 정하시오");
            string inputName = Console.ReadLine();

            MakeCharacter makeCharacter = new MakeCharacter();// 캐릭터를 생성해주는 makeCharacter를 생성해준다.

            //makeCharacter.Create(inputName, inputJob);<-이렇게만 할 경우에는 게임상황을 저장해주는 싱글톤변수에 저장이 되지 않고 일시적으로만 생성되기 때문에 싱글톤 변수에 꼭 넣어준다.
            Instance.Add(makeCharacter.Create(inputName, inputJob));   //Instance 안에 함수인 Add를 통해 캐릭터를 리스트안에 넣어주도록 한다.         
            Console.ReadLine();

        }
        //캐릭터리스트에 캐릭터를 제거해주는 함수
        public void RemoveCharacter()
        {
            Console.WriteLine("삭제할 캐릭터를 고르시오.");
            for (int i = 0; i < Instance.CharactersList.Count; i++)
            {
                Console.WriteLine("{0}.{1} {2}", i + 1, Instance.CharactersList[i].Job, Instance.CharactersList[i].Name);
            }
            string input2 = Console.ReadLine();
            int c_input2 = Convert.ToInt32(input2);

            Instance.CharactersList.Remove(Instance.CharactersList[c_input2 - 1]);

        }
        //게임을 플레이 하기 전에 캐릭터리스트를 보여주고 플레이할 캐릭터를 고르게 해주는 코드
        public void ShowCharacter()
        {
            if (Instance.CharactersList.Count==0)
            {
                Console.WriteLine("생성된 캐릭터가 없습니다. 캐릭터를 생성해주세요");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < Instance.CharactersList.Count; i++)
                {
                    Console.WriteLine("{0}.{1} {2}", i + 1, Instance.CharactersList[i].Job, Instance.CharactersList[i].Name);
                }
                string input = Console.ReadLine();
                int c_input = int.Parse(input);
                Instance.Character = Instance.CharactersList[c_input - 1];

            }
        }
    }
    
}
