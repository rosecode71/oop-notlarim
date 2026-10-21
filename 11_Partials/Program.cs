namespace _11_Partials
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kitap k = new Kitap();
            k.OzetiGoster();
        }
    }
    


#region partial Yapılar


        //Biz MyClass'ı parçalara ayırsakta compiler seviyesinde tüm partial classları bir bütün olarak olarak MyClass olarak algılayacaktır.
        //Parça olması beklenen tüm yapılar partial keywordü ile işaretlenmesi gerekir.
        //Bir sınıfın parçaları yine ilgili sınıfla aynı adla olması gerekir.
        //İç içe partial yapılar bulunabilir. Dıştaki sınıfında partial olması gerekmektedir.
        //Bir yapının(class,interface,struct,record,abstarct class) istediğiniz kadar partial'ı olabilir.

        #region Partial Class
    partial class MyClass
    {
        public int Yas { get; set; }
    }

    partial class MyClass
    {
        public void Bilgi()
        {

        }
    }
    #endregion

    #region Partial Record
    partial record MyRecord
    {

    }
    partial record MyRecord
    {

    }
    #endregion


    #region Partial Interface
    partial interface IMyInterface
    {

    }
    partial interface IMyInterface
    {

    }
    #endregion


    #region Partial Abstract Class
    abstract partial class MyAbstractClass
    {

    }
    abstract partial class MyAbstractClass
    {

    }
    #endregion

    #endregion


    #region partial metodlar
    //Bir yapıda hangi metodların kullanılabileceği başlangıçta tasarlanır ve şablon olarak sunulur.
    //Bu metodlar kullanılabilir veya kullanılmayadabilir. Kullanılmama sebebinden dolayı biz başlangıçta bu metodları yalnız tanımlarız.
    //Metodları kullanma durumu olduğu takdirde imzası olan metodun gövdesini davranışa uygun tasarlarız.
    //partial metodların imzasını tanımlandıktan sonra eğer uygulandıysa yani gövdesi tanımlandıysa artık dışarıdan erişilebilir anlama gelebilir.O yüzden başına public keywordü ekleyebiliriz.
    //partial metodların öncelikle imzalarını tanımlıyoruz kullanıp kullanmamayı geliştiriciye bıraktığımızdan dolayı bu ilgili partial metodların runtime'daki kaderini de yani çalışıp çalışmayacağını da bilemiyoruz.
    //partial metodların geriye dönüş türü void olmak zorundadır.
    //partial bir yapı içinde tanımlanırlar.




    partial class Kitap
    {

        public Kitap()
        {
            OzetiGoster();
            Karakterler();//Bu metod geliştirici tarafından kullanılmadığı için tetiklense dahi hiç varolmamış sayılacaktır.
        }
        //Burada geliştirici tarafından kullanılabilir metodları taslak olarak veriyoruz yani sadece tanımlıyoruz.
        // tanımlama/declaration
        public partial void OzetiGoster();
        partial void Karakterler();

        //Burada ise geliştiric tarafından kullanılmaya karar verilen metodun gövdesini metod davranışına uygun tasarlıyoruz.
        //Metodunun uygulanması/implementation
        public partial void OzetiGoster()
        {
            Console.WriteLine("Cemile kitabının sonunda ,cemile ve danyar birbirlerinin ruh arkadaşı olduğunu anlayıp kaçmaha karar verirler.");
        }
    }
    #endregion


}
