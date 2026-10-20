namespace _09_2_TurDonusumleri
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Polimorfizm Durumlarında Tür Dönüşümleri
            //Polimorfizm, nesnelerin kalıtımsal açıdan ilişki kurdukları ata sınıfların türündeki referanslar tarafından işaretlenebilmelidir. Bu ilgili nesnenin referansı ata türlerine dönüştürülebilmektedir.

            #region Durum 1: Alt türün bir üst türden referansla işaretlenmesi/karşılanması
            //Burada Inek nesnesi atası olan Canli türünden bir referansla işaretlenmiş.
            //İnek,inektir aynı zamanda bir canlıdır.
            Canli canli1 = new Inek();
            #endregion

            #region Durum 2: Ata/Üst türden referansla işaretlenen nesnenin kendi öz türünden referansla işaretlenmesi
            Canli canli2 = new Hayvan();
            Hayvan hayvan1 = (Hayvan) canli2;//canli2 referansının işaret ettiği nesne aslında bir Hayvan türünden nesnedir diyorum.
            #endregion

            #region Durum 3: Ata/üst türden referansla işaretlenen nesnenin yine başka bir ata türden referansla işaretlenme durumu

            Memeli memeli1 = new Inek();
            Hayvan hayvan2 = memeli1; //memeli1 referansı Heap'te inek türünden bir nesneyi işaret eder. Inek türünün hayvan sınıfıyla kalıtsal bir ilişkisi bulunur. Her inek bir hayvandır.

            Inek inek1 = (Inek)hayvan2; //hayvan2 referansı aslında inek nesnesini işaret eder. Inek türünden bir nesne kendi türünden ve ata türden bir referansla işaretlenebilir.
            #endregion

            #region Durum 4: Ata/Üst türden referansla işaretlenen nesnenin alt türden referansla işaretlenme durumu

            Hayvan hayvan3 = new Memeli();
            //Inek inek2 = (Inek) hayvan3; //hayvan3 nesnesi heap'te bir Memeli türde nesneyi işaret eder. Ama biz bu satırda diyoruz ki memeli nesnesi inektir diyoruz. Bu yanlıştır çünkü Her memeli İnek değildir. Burada çalışma zamanı hatası verecek.
            #endregion

            #region Durum 5: Kendi türünden referansla işaretlenen bir nesnenin ata/üst türden bir referanla işaretlenme durumu
            Inek inek3 = new Inek();
            Hayvan hayvan4 = inek3;
            Canli canli3 = inek3; //Bilinçsiz tür dönüşümü
            #endregion
            #endregion

            #region is operatörü
            //is operatörü sayesinde nesnenin hangi tür/türlerde olduğunu kontrol edebiliyoruz.
            Inek inek5 = new Inek();
            Console.WriteLine(inek5 is Canli);
            Console.WriteLine(inek5 is Hayvan);
            Console.WriteLine(inek5 is Memeli);
            Console.WriteLine(inek5 is Inek);

            Console.WriteLine(inek5 is Aslan);

            Hayvan hayvan = new Memeli();
            Console.WriteLine(hayvan is Canli);
            Console.WriteLine(hayvan is Memeli);
            Console.WriteLine(hayvan is Hayvan);
            Console.WriteLine(hayvan is Inek);

            #endregion
        }
    }

    //En üst ata sınıf
    class Canli
    {

    }
    //Her hayvan bir canlıdır.
    class Hayvan : Canli
    {

    }
    //Her memeli bir hayvandır.
    class Memeli : Hayvan
    {

    }
    //Her inek bir memelidir.
    class Inek : Memeli
    {

    }
    //Her aslan bir memelidir.
    class Aslan : Memeli
    {

    }
}





