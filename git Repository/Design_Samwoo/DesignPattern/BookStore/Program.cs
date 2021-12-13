using System;
namespace BookStore
{
    public enum CustomerLocation { EastCoast, MidWest, WestCoast}// 판매처가 3군데
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("East coast Customer : ");
            IBookStore bookStore = new BookStoreA(CustomerLocation.EastCoast);
            ShipBook(bookStore);

            Console.WriteLine("Mid West Customer : ");
            bookStore = new BookStoreA(CustomerLocation.MidWest);// 이미 위에서 bookStore를 선언해줬기 때문에 굳이 앞에 타입을 쓸 필요없음
            ShipBook(bookStore);

            Console.WriteLine("West Coast Customer : ");
            bookStore = new BookStoreA(CustomerLocation.WestCoast);
            ShipBook(bookStore);
        }
        private static void ShipBook(IBookStore s)//파라미터를 판매처에 넣어줌 
        {
            IDistributor d = s.GetDistributor();
            d.ShipBook();
        }
       
    }

    public interface IBookStore
    {
        IDistributor GetDistributor();
    }
    public class BookStoreA : IBookStore
    {
        private CustomerLocation location;//3군데의 판매처를 private로 설정함
        public BookStoreA(CustomerLocation location)
        {
            this.location = location;
        }
        IDistributor IBookStore.GetDistributor()
        {
            switch (location)
            {
                case CustomerLocation.EastCoast:
                    return new EastCoastDistributor();
                case CustomerLocation.MidWest:
                    return new MidwestDistributor();
                case CustomerLocation.WestCoast:
                    return new WestCoastDistributor();
            }
            return null;
        }

    }
    
    // 아래에 있는 부분이 팩토리 디자인 패턴
    public interface IDistributor// 판매하는 곳(EastCoast,MidWest,WestCoast의 캡슐화 대상//인터페이스(계약,자격증)로 만듬)
    {
        void ShipBook();// 기능 선언만 가능!!   
    }
    //인터페이스를 상속받은 경우에는 반드시 인터페이스 안에 들어있는 함수를 사용해주어야한다.
    public class EastCoastDistributor : IDistributor
    {
        void IDistributor.ShipBook()
        {
            Console.WriteLine("Book shipped by East Coast Distributor");
        }
    }
    public class MidwestDistributor: IDistributor
    {
        void IDistributor.ShipBook()
        {
            Console.WriteLine("Book shipped by Mid West Distributor");
        }
    }
    public class WestCoastDistributor : IDistributor
    {
        void IDistributor.ShipBook()
        {
            Console.WriteLine("Book shipped by West Coast Distributor");
        }
    }
}
