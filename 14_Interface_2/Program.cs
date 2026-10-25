HesapMakinesi hmakine = new HesapMakinesi();
IAlan alan = hmakine;
double dikdortgenAlani = alan.DikdortgenHesapla(3, 5);
double kareAlani = alan.KareHesapla(5);

ICevre cevre = hmakine;
double dikdortgenCevresi = cevre.DikdortgenHesapla(3, 5);
double kareCevresi = cevre.KareHesapla(5);

Console.WriteLine($"Dikdörtgenin alani: {dikdortgenAlani} - cevresi: {dikdortgenCevresi}");
Console.WriteLine($"Karenin alani: {kareAlani} - cevresi: {kareCevresi}");

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