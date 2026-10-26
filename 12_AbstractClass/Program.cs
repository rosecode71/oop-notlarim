namespace _12_AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    abstract class MyAbstractClass
    {

        //Abstract classların constructorları vardır. Abstract classların compile seviyesinde bellekte nesneleri oluşur.
        public MyAbstractClass()
        {
            Console.WriteLine("Abstract class constructorı tetiklendi.");
        }

        //AbsractClassların SOMUT KISMI

        //class yapılanmasında olduğu gibi abstract classlarında normal memberları(üyeleri) vardır.
        public string Baslik;
        public int MyProperty { get; set; }

        //virtual olan bir member override ediledebilir edilmeyedebilir ancak abstract olan bir member override edilmek zorundadır.
        virtual public void  Bilgi()
        {

        }

        //SOYUT KISMI
        //MyAbsractClass sınıfını implemente edecek olan class'a zorla uygulatacağımız member imzalarına burada yer verebiliriz
        //Zorla uygulatılmasını istediğimizi member imzalarını abstract keywordü ile işaretlememiz gerekiyor.
        //MyAbstractClass sınıfının içinden zorla uygulatılacak metodlara implemente eden sınıf erişebilmesi için de erişilebilir yani public olması gerekir.
        abstract public void X();
        abstract public int Y{ get; set; }
        //virtual  abstract public void Z(); sanal sınıflarda abstract class içerisinde tanımlanamıyor.
        //abstract public int Z; alanlarlar geçerli değil

    }

    class MyNormalClass : MyAbstractClass
    {
        public override void Bilgi()
        {
            base.Bilgi();
        }
        public override void X()
        {

        }

        

        public override int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


}
