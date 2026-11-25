namespace _21_StaticYapilar
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Üniversite Örnekleri
            Universite uni1 = new Universite()
            {
                Ad = "Konya Teknik Üniversitesi",
                Rektor = "Osman Nuri Çelik",
                KurulusYılı = 2018
            };

            Universite uni2 = new Universite()
            {
                Ad = "Ankara Üniversitesi",
                Rektor = "Rıfkı Gözaydın",
                KurulusYılı = 2004
            };
            Universite uni3 = new Universite()
            {
                Ad = "Gazi Üniversitesi",
                Rektor = "Ahmet Mithat Efendi",
                KurulusYılı = 1987
            };

            //Öğrenci Örnekleri
            Ogrenci ogr1 = new Ogrenci()
            {
                Ad = "Gülfo",
                Soyad = "Koç",
                UniNumara = "21324324235",
                SinifNumarasi = 4,
                Universite = uni1
                
            };
            Ogrenci ogr2 = new Ogrenci()
            {
                Ad = "Ayşe",
                Soyad = "Keleş",
                UniNumara = "2354654625",
                SinifNumarasi = 3,
                Universite = uni1
            };
            Ogrenci ogr3 = new Ogrenci()
            {
                Ad = "Fatma",
                Soyad = "Koç",
                UniNumara = "21324324235",
                SinifNumarasi = 2,
                Universite = uni3
            };
            Ogrenci ogr4 = new Ogrenci()
            {
                Ad = "Teslo",
                Soyad = "Taylan",
                UniNumara = "2354654625",
                SinifNumarasi = 1,
                Universite = uni2
            };
            Ogrenci ogr5 = new Ogrenci()
            {
                Ad = "Mustafa Arda",
                Soyad = "Işık",
                UniNumara = "21324324235",
                SinifNumarasi = 2,
                Universite = uni3
            };
            Ogrenci ogr6 = new Ogrenci()
            {
                Ad = "Beyza",
                Soyad = "Çelik",
                UniNumara = "535353535353",
                SinifNumarasi = 4,
                Universite = uni1
            };



            //Sistemdeki Toplam Öğrenci/Üniversite Sayısı
            Console.WriteLine($"Sistemde var olan toplam öğrenci sayısı : {Ogrenci.ToplamOgrenciSayisi}\n");
            Console.WriteLine($"Sistemde var olan toplam üniversite sayısı : {Universite.ToplamUniversiteSayisi}\n");


            //uni1 referansının işaret ettiği Üniversitenin toplam öğrenci sayısı
            //Öncelikle var olan öğrencileri listede toplayalım
            List<Ogrenci> ogrenciListesi = [ogr1, ogr2, ogr3, ogr4, ogr5, ogr6];
            List<Universite> universiteler = [uni1, uni2, uni3];
            
            //foreach(var uni in universiteler)
            //{
            //    int UniOgrenciSayisi = 0;
            //    foreach (var ogr in ogrenciListesi)
            //    {
            //        if(uni == ogr.Universite)
            //        {
            //            UniOgrenciSayisi++;
            //        }
            //    }
            //    //Console.WriteLine($"{uni.Ad}'nin öğrenci sayısı : {UniOgrenciSayisi}");
            //    uni.OgrenciSayisi = UniOgrenciSayisi;
            //}


            //Üniversite hakkinda 
            foreach(var uni in universiteler)
            {
                uni.Hakkinda();
            }

            ogr1.Universite = uni2;
            foreach (var uni in universiteler)
            {
                uni.Hakkinda();
            }

            ogr1.Universite = null;
            foreach (var uni in universiteler)
            {
                uni.Hakkinda();
            }
        }
    }


    class Universite
    {
        public string Ad { get; set; }
        public string Rektor { get; set; }
        public int KurulusYılı { get; set; }

        public int OgrenciSayisi { get; set; }

        static public string BagliOlunanKurum { get; set; } = "YÖK"; //Türkiye bazında düşündüğüm için tüm üniler için ortak
        static public int ToplamUniversiteSayisi { get; set; }

        public Universite()
        {
            ToplamUniversiteSayisi++;
        }
        public void Hakkinda()
        {
            Console.WriteLine(
            $"Üniversite Adı: {this.Ad}\n" +
            $"Bağlı Kurum: {BagliOlunanKurum}\n" +
            $"Rektörü: {this.Rektor}\n" +
            $"Kuruluş Yılı: {this.KurulusYılı}\n" +
            $"Öğrenci Sayısı: {this.OgrenciSayisi}\n\n"
            );
        }
    }



    class Ogrenci
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string UniNumara { get; set; }
        public int SinifNumarasi { get; set; }


        static public int ToplamOgrenciSayisi = 0;


        private Universite _universite;

        public Universite Universite { 
            get => _universite; 
            set
            {
                if (_universite != null)
                {
                    _universite.OgrenciSayisi--;
                }
                _universite = value;

                if (_universite != null)
                {
                    _universite.OgrenciSayisi++;
                }
            } 
        }

        public Ogrenci()
        {
            ToplamOgrenciSayisi++; //Her ogrenci türünden örnek oluştuğunda nesne constructorı tetiklenecek ve ToplamOgrenciSayisi 1 artacak.
        }

    }
}
