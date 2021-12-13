using System;
using System.Collections.Generic;
using System.Text;

namespace Maple
{
    //싱글톤을 사용해서 게임상황을 계속해서 이어나가게 해주는 코드
    class GameInstance
    {
        // 위치 저장
        private IGameManager position;
        public IGameManager Position
        {
                
            get { return position; }
            set { position = value;}

        }
        //
        private Character character = new Character();
        public Character Character// 사용자가 선택한 character를 저장하는 곳 
        {
            get
            {
                return character;
            }
            set
            {
                character = value;
            }
        }

        private List<Character> charactersList = new List<Character>();

        public List<Character> CharactersList // 캐릭터 리스트를 보여줄때
        {
            get
            {
                return charactersList;
            }
            set
            {
                charactersList = value;
            }
        }
        public void Add(Character _character)
        // 매개변수에 캐릭터 형식을 넣어준 다음에 List<Character>에 넣어주도록 한다.
        {
            charactersList.Add(_character);
        }
        private static GameInstance instance = null;
        public static GameInstance Instance
        {
            get
            {
                if (instance == null)
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
        public string GetKPosition()
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
    }
    //
   
}
