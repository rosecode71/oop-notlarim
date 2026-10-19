using System;

namespace _09_Polimorfizm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Örnek Uygulama 1

            // Roman türünde bir nesne ürettim ve bu nesneyi yine 
            // kendi türünde bir referans ile stackte işaretledim.
            Roman roman = new Roman("Akşam Güneşi", "Reşat Nuri Güntekin", 447, 400);
            roman.Bilgi();
            roman.RomanTuru = "Aşk";

            // Roman aynı zmanda bir kitap olduğu için kitap türünden bir referans ile de 
            // stackte gösterilebilir. Ancak referansın türü neyse o türdeki davranışları 
            // veya yine türetildiği sınıfın davranışlarını gösterir. Alt sınıftaki 
            // davranışlara erişmez. Ancak override etme işlemi varsa kitap sınıfında 
            // tanımlanan sanal bir metod roman sınıfında sınıfın davranışına göre 
            // tekrar düzenlendiyse/ezildiyse o metod gövdesi çalışır.
            Kitap roman2 = new Roman("Acımak", "Reşat Nuri Güntekin", 180, 200);
            roman2.Bilgi();

            // roman2.RomanTuru = "Dram"; 
            // roman2 referansı Kitap türünde olduğu için kitap sınıfında ve türetildiği 
            // Urun sınıfında romanTuru memberı olmadığı için ulaşılamaz.

            #endregion
        }
    }

    #region Örnek Uygulama 1

    // Urun sınıfını burada En yüksek mertebeli ata sınıf olarak tanımladım. 
    // Dikeyde hiyerarşik olarak kalıtsal ilişkiler tanımladım.
    class Urun
    {
        public void Hakkinda()
        {
            Console.WriteLine("Urunler birden fazla çeşitte olabilir.");
        }
    }

    // Kitap, kitaptır. Kitap aynı zmanda bir üründür.
    // Kitap aslında bir üründür diyebilmemiz için o türden bir sınıftan türemesi 
    // kalıtım alması lazım.
    class Kitap : Urun
    {
        // Burada tanımlanan memberler bu Kitap sınıfından türeyen sınıflar için 
        // erişilebilir ortak memberlardır.
        protected String _Adi { get; set; }
        protected String _Yazari { get; set; }
        protected int _SayfaSayisi { get; set; }
        protected double _Fiyati { get; set; }

        // Roman ve Hikaye sınıflarının Base Class'ının constructorı parametreli
        public Kitap(String Ad, String Yazar, int SayfaSayisi, double Fiyati)
        {
            _Adi = Ad;
            _Yazari = Yazar;
            _SayfaSayisi = SayfaSayisi;
            _Fiyati = Fiyati;
        }

        public void Oku()
        {
        }

        public virtual void Bilgi()
        {
        }

        public virtual void OzetGoster()
        {
            Console.WriteLine("Her kitabın bir özeti vardır.");
        }
    }

    // Roman,romandır.Roman aynı zamanda bir Kitaptır.
    // Roman bir kitaptır diyebilmem için aralarında bir kalıtsal ilişki bulunmalıdır. 
    // Yani roman sınıfı aslında kitap sınıfından türetilmeli ve onun özelliklerini 
    // taşıyabilmelidir.
    class Roman : Kitap
    {
        public string RomanTuru { get; set; }
        public List<string> AnaKarakterListesi { get; set; }

        public Roman(string Ad, string Yazar, int SayfaSayisi, double Fiyat)
            : base(Ad, Yazar, SayfaSayisi, Fiyat)
        {
        }

        public override void Bilgi()
        {
            Console.WriteLine($"Adı:{_Adi}\nYazari:{_Yazari}\nSayfa Sayisi: {_SayfaSayisi}\nFiyatı: {_Fiyati}");
        }

        public override void OzetGoster()
        {
            Console.WriteLine("Bu bir romandır ve trajedik olayları konu alır. Kahramanın üstesinden gelmeye çalıştığı ancak korktuğu sorunlardan kaçamadığı olayları anlatır.");
        }
    }

    // Hikaye, hikayedir. Hikaye anı zmanda bir kitaptır.
    // Hikayeyi de kitap olarak nitelendirebilmemiz için kitap türünden bir sınıftan 
    // türemesi gerekir. Bunu da kalıtım yoluyla sağlarız.
    class Hikaye : Kitap
    {
        public string Donem { get; set; }
        public int OykuSayisi { get; set; }

        // Hikaye sınıfının base class'ı yani türetildiği 1.dereceden sınıf Kitap sınıfıdır. 
        // Kitap sınıfının geçerli constructorı da parametreli constructordır.
        public Hikaye(string Ad, string Yazar, int SayfaSayisi, double Fiyat)
            : base(Ad, Yazar, SayfaSayisi, Fiyat)
        {
        }

        public override void Bilgi()
        {
            Console.WriteLine($"Adı:{_Adi}\nYazari:{_Yazari}\nSayfa Sayisi: {_SayfaSayisi}\nFiyatı: {_Fiyati}");
        }

        public override void OzetGoster()
        {
            Console.WriteLine("Bu bir hikayedir. İçerisinde 7 adet kısa öyküler barındırır. Her öykü birbirinden bağımsızdır.");
        }
    }

    // Dikkat: Roman ve hikaye aynı türden sınıftan türetilen sınıflardır. 
    // Yani yatay anlamda aynı seviyede bulunurlar. Ancak aralarında kalıtsal bir ilişki 
    // bulunmaz yani kendi türlerine ait üyeleri birbirleriyle paylaşmazlar. 
    // Kalıtımda nitelikler yatay düzende aktarılmaz. Dikey bir düzende hiyerarşide aktarılır.
    #endregion
}
