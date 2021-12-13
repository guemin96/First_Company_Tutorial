using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual
{
    class Program
    {
        class 아버지
        {
            public void 아빠차()
            {
                Console.WriteLine("[부모] 아버지차");
            }
            //virtual 부티면 가상함수로 변신
            virtual public void 아빠차2()
            {
                Console.WriteLine("부모 아빠차2");
            }
        }
        class 아들 : 아버지
        {
            //일반 함수 오버라이딩 : new 키워드
            new public void 아빠차()
            {
                Console.WriteLine("[자식] 슈퍼카");
            }
            //2. 가상 함수 오버라이딩
            public override void 아빠차2()
            {
                Console.WriteLine("아들 슈퍼카2");
            }
        }
        static void Main(string[] args)
        {
            아들 son = new 아들();
            아버지 father = son; //아빠가 아들의 슈퍼카를 타고 싶은 열망에 업캐스팅

            son.아빠차();
            father.아빠차();
            Console.WriteLine();
            father.아빠차2();
        }
    }
}
// 아빠 : 가사함수로 선언해서 아들에게 물려줘야지!(필요하면 내가 아들거 타고~)
// 가상함수 조건 = 1.오버라이딩 된 상태 + 2. 업캐스팅된 상태