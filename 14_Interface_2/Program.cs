HesapMakinesi hmakine = new HesapMakinesi();
IAlan alan = hmakine;
double dikdortgenAlani = alan.DikdortgenHesapla(3, 5);
double kareAlani = alan.KareHesapla(5);

ICevre cevre = hmakine;
double dikdortgenCevresi = cevre.DikdortgenHesapla(3, 5);
double kareCevresi = cevre.KareHesapla(5);

Console.WriteLine($"Dikdörtgenin alani: {dikdortgenAlani} - cevresi: {dikdortgenCevresi}");
Console.WriteLine($"Karenin alani: {kareAlani} - cevresi: {kareCevresi}");

//Base Class ve Interface'de aynı member imzası bulunması durumu
DerivedClass dclass = new DerivedClass();
Console.WriteLine(dclass.A);
IInterface intf = dclass;
Console.WriteLine(intf.A);


//Default Implementation
IExample expi = new CExample();
expi.Method1();
expi.Method2();
interface IAlan
{
    double KareHesapla(int en);

    double DikdortgenHesapla(double uzunKenar, double kisaKenar);
}

interface ICevre
{
    double KareHesapla(int en);

    double DikdortgenHesapla(double uzunKenar, double kisaKenar);

}


//Burada Hesaplayici sınıfı IAlan ve ICevre sınıfını uyguluyor yani onunla bir anlaşma imzalıyor. Dikkat ederseniz IAlan ve ICevre içerisindeki member imzaları birbirleriyle tamamen aynı. Bu memberları sınıf içerisinde uyguladığımızda hangi interface'den geldiğini bilemiyoruz ya da ilgili interface'e göre operasyon gerçekleştiremiyoruz işte bu durumun önüne geçmek için de Explicity Implement dediğimiz yani açıkça uygulama yapısından yararlanacağız.

#region Name Hiding Durumu
class Hesaplayici : IAlan, ICevre
{
    // Buradaki DikdortgenHesapla ve KareHesapla metodları Hangi Interface'e ait
    public double DikdortgenHesapla(double uzunKenar, double kisaKenar)
    {
        return 0;
    }

    public double KareHesapla(int en)
    {
        return 0;
    }
}
#endregion

#region Explicity Implementation ile Name Hiding'i engellemek
//Artık ilgili interface'e göre operasyonlar gerçekleştirebileceğiz.
class HesapMakinesi : IAlan, ICevre
{
    double IAlan.DikdortgenHesapla(double uzunKenar, double kisaKenar)
    {
        return uzunKenar * kisaKenar;
    }

    double ICevre.DikdortgenHesapla(double uzunKenar, double kisaKenar)
    {
        return 2 * (uzunKenar + kisaKenar);
    }

    double IAlan.KareHesapla(int en)
    {
        return en * en;
    }

    //Yukarıdaki KareHesapla IAlan'dan çağrıldığına göre bu da artık diğer interface olan ICevre'den çağrılacak ve ona göre işlem yapılacak.
    public double KareHesapla(int en)
    {
        return 4 * en;
    }
}
#endregion

#region BaseClass'taki member imzası ile Interface'deki member imzasının birebir aynı olması durumunda BaseClass'ı miras lan Interface'ı implement eden sınıf için Name Hiding durumuna düşürmeyecektir.

class BaseClass
{
    public int A { get; set; } = 20;
}
interface IInterface
{
    int A { get; set; }

}
//A memberı kalıtımla DerivedClass'a aktarıldığı için haliyle IInterface'deki A memberını uygulamış oluyor.
class DerivedClass : BaseClass, IInterface
{
}
#endregion


#region Default Implementation Interface

interface IExample
{
    void Method1();

    void Method2()
    {
        Console.WriteLine("Bu bir default implementation'dur");
    }
}

class CExample : IExample
{
    public void Method1()
    {
        Console.WriteLine("Method1 için sadece imza tanımlandığı için uygulanmak zorunda");
    }
    //public void Method2()
    //{
    //    Console.WriteLine("Method2'in uygulanması isteğe bağlıdır çünkü default implementation'a sahiptir.");

    //}
}

#endregion