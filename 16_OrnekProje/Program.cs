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
        //Bu alanlar kalıtım yoluyla bu LibraryItem sınıfını uygulayan sınıflara aktarılır.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public bool IsBorrowed { get; set; }

        //SOYUT KISIM:
        //Bu abstract class'ı uygulayan sınıfın zorla gerçekleşmesi gereken metotlar.
       public abstract void DisplayInfo();
    }

    #region SubClass1 : Book sınıfı
    class Book :LibraryItem
    {
        public int PageCount { get; set; }
        public string ISBN { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{this.Id}\n{this.Title}\n{this.Author}\n{PublishYear}\n{this.IsBorrowed}\n{PageCount}\n{ISBN}");
        }
    }
    #endregion

    #region SubClass2: Magazine(Dergi) sınıfı
    class Magazine: LibraryItem
    {
        public int IssueNumber { get; set; }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{this.Id}\n{this.Title}\n{this.Author}\n{PublishYear}\n{this.IsBorrowed}\n{IssueNumber}");
        }
    }
    #endregion
    #region SubClass3: AudioBook
    class AudioBook: LibraryItem
    {
        public int DurationMinutes { get; set; }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{this.Id}\n{this.Title}\n{this.Author}\n{PublishYear}\n{this.IsBorrowed}\n{DurationMinutes}");
        }
    }
    #endregion
}
