namespace _06_Static_Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Static constructor tetiklenmesi

            //Static constructor sınıf içerisinde tanımlanan static bir üye çağrıldığında veya ilk kez ilgili sınıftan nesne oluşturulduğunda tetiklenir.

            //Statik üyelere sınıf adı üzerinden erişiyoruz. Burada ilk static üye çağırdığımız için static constructor tetiklenecektir.
            User.UygulamaHakkinda();


            //Burada User sınıfından ilk kez nesne üretiyoruz. İlgili sınıftan ilk kez nesne ürettiğimizde normalde ilk tetiklenecek metod static constructordı ancak yukarıda static üye çağrılınca tetiklendiği için birdaha tetiklenmeyecek ve artık normal constructor tetiklenecek.
            User user1 = new User()
            {
                Ad = "Rose",
                Soyad = "Code",
                DogumTarihi = new DateTime(2002, 12, 04)
            };

            User user2 = new User()
            {
                Ad = "Mary",
                Soyad = "Oop",
                DogumTarihi = new DateTime(2002, 12, 27)
            };

            user1.KullaniciTanit();
            user2.KullaniciTanit();

            User.UygulamaHakkinda();

            #endregion
        }
    }

    class User
    {
        //Propertylerimiz: Nesnenin sahip olacağı alanların değerlerini dışarıya kontrollü bir şekilde açar.
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }

        //Sınıf üyeleri

        public static int KullaniciSayisi { get; private set; }
        public static string UygulamaAdi { get; }

        //Constructor
        public User()
        {
            Console.WriteLine("Her yeni kullanıcı oluştuğunda bu metod tetiklenecek");
            KullaniciSayisi++;
        }

        //Static Constructor
        static User()
        {
            Console.WriteLine("Static constructor çaprıldı.");
            UygulamaAdi = "Instagram";
        }

        //Bu metoda ilgili nesne tarafından erişilmesi gerekiyor.
        public void KullaniciTanit()
        {
            Console.WriteLine($"Ad: {Ad}\nSoyad: {Soyad}\nDoğum Tarihi: {DogumTarihi}");
        }

        public static void UygulamaHakkinda()
        {
            Console.WriteLine($"Uygulama Adı: {UygulamaAdi}\nKullanıcı Sayısı: {KullaniciSayisi}\n");
        }
    }
}
