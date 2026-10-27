namespace _16_OrnekProje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Yeni kitap nesnelerimiz
            Book b1 = new Book("Eylül", "Mehmet Rauf", 160, 1901, "9789750800001");
            Book b2 = new Book("Eylül", "Ayşe Kulin", 320, 2015, "9789750811112"); // Aynı isim, farklı yazar
            Book b3 = new Book("Akşam Güneşi", "Reşat Nuri Güntekin", 440, 1926, "9876543473233");
            Book b4 = new Book("Acımak", "Reşat Nuri Güntekin", 180, 1925, "9870902300949");
            Book b5 = new Book("Kuyucaklı Yusuf", "Sabahattin Ali", 221, 1937, "9789753638020");
            Book b6 = new Book("Kürk Mantolu Madonna", "Sabahattin Ali", 177, 1943, "9789753638013");
            Book b7 = new Book("Saatleri Ayarlama Enstitüsü", "Ahmet Hamdi Tanpınar", 392, 1961, "9789759954000");
            Book b8 = new Book("Tutunamayanlar", "Oğuz Atay", 724, 1971, "9789750738609");
            Book b9 = new Book("İnce Memed", "Yaşar Kemal", 436, 1955, "9789750807154");
            Book b10 = new Book("Kuyucaklı Yusuf", "Farklı Yayın", 200, 2020, "9789753639999"); 

            List<LibraryItem> items = [b1, b2, b3,b4,b5,b6,b7,b8,b9,b10];

            //Menü
            while (true)
            {
                Console.WriteLine("1.Materyalleri Listele\n2.Kitap Ara\n3.Kitap Ara ve Ödünç Al\n4.Kitap İade Et\n0.Sistemden Çıkış");
                Console.WriteLine("Yapmak istediğiniz işlemin numarasını giriniz: ");
                int islem = int.Parse(Console.ReadLine());
                Console.WriteLine("\n==================================================================\n");
                switch (islem)
                {
                    case 0:
                        return;
                    case 1:
                        ListOfMaterial(items,"Kütüphanedeki Tüm Materyal Listesi:");
                        break;
                    case 2:
                        List<LibraryItem> AramaSonucListesi = SearchMaterial(items);
                        if(AramaSonucListesi.Count !=0)
                           ListOfMaterial(AramaSonucListesi,"Arama Sonuçları:");
                        break;
                    case 3:
                        SearcAndBorrow(items, "Gülfidan");
                        break;
                    case 4:
                        List<LibraryItem> OduncAlinmisListesi = SearchBorrowedItem(items);
                        if(OduncAlinmisListesi.Count == 0)
                        {
                            Console.WriteLine("!!! Ödünç alınmış materyal yok.");
                            break;
                        }
                        ListOfMaterial(OduncAlinmisListesi,"Ödünç Alınmış Materyal Listesi:");
                        ReturnItem(OduncAlinmisListesi);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\n==================================================================\n");
            }
                  
        }

        public static void ListOfMaterial(List<LibraryItem> items,string message)
        {
            if(items.Count == 0)
            {
                return;
            }
            Console.WriteLine(message);
            foreach(var item in items)
            {
                item.DisplayInfo();
            }
        }
        public static List<LibraryItem> SearchMaterial(List<LibraryItem> items)
        {
            Console.WriteLine("Arama yapmak istediğiniz ögenin adını giriniz:");
            string Title = Console.ReadLine();
            List<LibraryItem> bulunanSonuclar = [];

            foreach (var item in items)
            {
                if (item is ISearchable searchable)
                {

                    if (searchable.isFind(Title))
                    {
                        bulunanSonuclar.Add(item);

                    }
                }
            }
            if (bulunanSonuclar.Count == 0)
            {
                Console.WriteLine("Aradığınız materyale uygun sonuç bulunamadı.");
            }
            return bulunanSonuclar;
        }
        public static  void SearcAndBorrow(List<LibraryItem> items,string memberName)
        {
            //Kitap Ödünç Alma Sistemi
           
            List<LibraryItem> bulunanSonuclar = SearchMaterial(items);
            if(bulunanSonuclar.Count == 0)
            {
                return;
            }
            ListOfMaterial(bulunanSonuclar,"Arama sonuçları:");

            Console.WriteLine("Lütfen ödünç almak istediğiniz materyalin Id'sini giriniz.");
            int Id = int.Parse(Console.ReadLine());

            foreach (var sonuc in bulunanSonuclar)
            {
                if (sonuc.Id == Id)
                {
                    if (sonuc is IBorrowable borrowable)
                    {
                        borrowable.BorrowItem(memberName);
                        return;
                    }
                    Console.WriteLine("Maalesef ilgili materyal ödünç alınabilir değil.");

                }
            }
        }
        public static List<LibraryItem> SearchBorrowedItem(List<LibraryItem> items)
        {
            List<LibraryItem> OduncAlinmisListesi = [];
            foreach(var item in items)
            {
                if (item.IsBorrowed)
                {
                    OduncAlinmisListesi.Add(item);
                }
            }
            return OduncAlinmisListesi;
        }
        public static void ReturnItem(List<LibraryItem> items)
        {
            Console.WriteLine("Lütfen iade etmek istediğiniz materyalin Id bilgisini giriniz:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (var item in items)
                {
                    if (item.Id == id)
                    {
                        if (item is IBorrowable borrowable)
                        {
                            borrowable.ReturnItem();
                            return; 
                        }
                        Console.WriteLine("Maalesef ilgili materyal iade edilebilir bir yapıda değil.");
                        return;
                    }
                }
                Console.WriteLine("Girdiğiniz ID'ye sahip ödünç alınmış bir materyal bu listede bulunamadı.");
            }
            else
            {
                Console.WriteLine("Geçersiz bir ID girdiniz. Lütfen sayısal bir değer giriniz.");
            }
        }
    }

    #region Abstract Class
    abstract class LibraryItem
    {
        //SOMUT KISIM:
        //Abstract class'ta normal class'taki gibi normal üyelerimiz vardır.
        //Bu alanlar kalıtım yoluyla bu LibraryItem sınıfını uygulayan sınıflara aktarılır.
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public bool IsBorrowed { get; set; }
        static int sayac;


        //Constructor
        public LibraryItem()
        {
            Id = sayac++;
           
        }

        //SOYUT KISIM:
        //Bu abstract class'ı uygulayan sınıfın zorla gerçekleşmesi gereken metotlar.
       public abstract void DisplayInfo();
    }
    #endregion

    #region IBorrowable interface'i
    //Bu Şablondaki/Arayüzdeki kurallar sadece Book ve Magazine tarafından uygulanacak 
    interface IBorrowable
    {
        void BorrowItem(string memberName);
        void ReturnItem();
    }
    #endregion


    #region ISearchable interface'i
    interface ISearchable
    {
        bool isFind(string keyword);
        

    }
    #endregion


    #region SubClass1 : Book sınıfı
    class Book :LibraryItem,IBorrowable,ISearchable
    {
        //Instance member
        public int PageCount { get; set; }
        public string ISBN { get; set; }

        //Constructor
        public Book(string Title,string Author,int PageCount,int PublishYear,string ISBN)
        {
            
            base.Title = Title;
            base.Author = Author;
            this.PageCount = PageCount;
            this.PublishYear = PublishYear;
            this.ISBN = ISBN;
            base.IsBorrowed = false;
        }

        //IBorrowable interface'inde uygulatılması gereken memberlar
        public void BorrowItem(string memberName)
        {
            if (this.IsBorrowed)
            {
                Console.WriteLine($"{this.Title} adlı kitap, ödünç alınmış. Maalesef {memberName} isimli üyeye ödünç verilemiyor.");
                return;
            }
            this.IsBorrowed = true;
            Console.WriteLine($"{this.Title} adlı kitap, {memberName} isimli üyeye ödünç verildi.");
        }
        public void ReturnItem()
        {
            if (this.IsBorrowed)
            {
                this.IsBorrowed = false;
                Console.WriteLine($"{this.Title} adlı kitap kütüphaneye iade edildi.");
                return;
            }
            Console.WriteLine("İlgili kitap zaten kütüphanede.");
            
        }

        //LibraryItem abstract classında uygulatılması gereken member.
        public override void DisplayInfo()
        {
            Console.WriteLine($"Kitap Id: {Id}\nKitap Adı:{this.Title}\nKitap Yazarı: {this.Author}\nYayınlanma Tarihi: {PublishYear}\nÖdünç Alınabilir Mi: {this.IsBorrowed }\nSayfa Sayısı: {PageCount}\nISBN: {ISBN}\n");
        }


        //ISearchable interface'inde uygulatılması gereken member.
        public bool isFind(string keyword)
        {
            if(this.Title.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
    #endregion

    #region SubClass2: Magazine(Dergi) sınıfı
    class Magazine: LibraryItem
    {
        public int IssueNumber { get; set; }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{this.Title}\n{this.Author}\n{PublishYear}\n{this.IsBorrowed}\n{IssueNumber}");
        }
    }
    #endregion
    
    #region SubClass3: AudioBook
    class AudioBook: LibraryItem
    {
        public int DurationMinutes { get; set; }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{this.Title}\n{this.Author}\n{PublishYear}\n{this.IsBorrowed}\n{DurationMinutes}");
        }
    }
    #endregion
}
