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

#region Explicity Implementation 
#endregion