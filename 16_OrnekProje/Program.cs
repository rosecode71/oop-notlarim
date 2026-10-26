namespace _16_OrnekProje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    //Base Class
    abstract class LibraryItem
    {
        //SOMUT KISIM:
        //Abstract class'ta normal class'taki gibi normal üyelerimiz vardır.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public bool IsBorrowed { get; set; }

        //SOYUT KISIM:
        //Bu abstract class'ı uygulayan sınıfın zorla gerçekleşmesi gereken metotlar.
       public abstract void DisplayInfo();
    }


}
