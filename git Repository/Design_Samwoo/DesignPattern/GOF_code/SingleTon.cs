using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    // 해당 클래스의 인스턴스가 하나만 생성이 되는 것을 보장하며 어디서든지 그 인스터스에 접근이 가능하도록 만드는 패턴
    // 사용 용도 
    // - 시스템에서 전역으로 관리되고 단 하나의 클래스에서만 정보가 유지되는 것을 원할때
    // - 시스템 자원관리나 정보를 관리
    //
    class SingleTon
    {
        private static SingleTon instance;

        //protected로 생성자를 만듬
        protected SingleTon() { }
        //static으로 메서드를 생성
        public static SingleTon Instance()
        {
            if (instance==null)
            {
                instance = new SingleTon();
            }
            return instance;
        }
    }
}
