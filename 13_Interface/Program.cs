namespace _13_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Interfaceler referans türlü değişkenlerdir. Yani referanstır. Bir şeyi işaret/referans ederler.
            //Referans türlü değişkenlerin varsayılan değeri nulldır burada da null değer atadım.
            IMyInterface hesap = null;


            IA a = new ExampleClass();
            IB b = new ExampleClass();
            IC c = new ExampleClass();

            //Herbir interface referansı üzerinden yalnızca ilgili interface'in zorla uygulattığı membera erişebiliyoruz bu sayede gereksiz ihtiyacımız olmayan memberlara erişmekten kurutulmuş oluyoruz burda da soyutlamnın örneğini görmüş oluyoruz.
            Console.WriteLine(a.GetType());
            a.A();

        }
    }

    #region 
    //Interface/Arayüz/Şablon'larda bir sınıfta olması gereken memberları doğrudan sınıfa koymadan önce burada topluyoruz. Ancak bu toplma işlemi genelde birbirine yakın davranış gösteren member grupları şeklinde gerçekleşiyor.
    //Interfacele ise içerisinde tanımlanan member imzalarını kendisini uygulayan yani sözleşme yapıtğı sınıfa zorla uygulatır.
    //Interfacelerde kalıtımsal olarak herhangi bir davranış yoktur çünkü kendi normal memberı yoktur.
    interface IMyInterface
    {
        void KareAlaniHesapla();
        int W();
        int MyProperty { get; set; }
    }

    //Abstracta tanımlanan abstract memberlar ilgili class'a uygulatmanın yanı sıra bir de normal metodları kalıtımsal yolla aktarmak da amaçlar arasında vardır.
    abstract class MyAbstractClass
    {
       

        abstract public int X { get; set; }
        abstract protected void Y();
    }

    class MyClass : MyAbstractClass,IMyInterface
    {

        //Abstarct class'ın zoraki uygulattığı memberlar
        public override int X { get; set; }
        protected override void Y() { }



        int IMyInterface.MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        void IMyInterface.KareAlaniHesapla()
        {
            throw new NotImplementedException();
        }

        int IMyInterface.W()
        {
            throw new NotImplementedException();
        }



    }
    #endregion

    #region Bir Sınıf birden fazla interface ile sözleşme yapabilir.


    interface IA
    {
        void A();
    }
    interface IB
    {
        void B();
    }

    interface IC
    {
        void C();
    }

    //ExampleClass birden fazla Interface ile sözleşme gerçekleştiriyor ve içerisindeki imzaları uygulamak zorundadır.
    class ExampleClass : IA, IB, IC
    {
        //IA interface'i ile yaptığı sözleşmeye dair zorla uygulaması gereken A memberı
        public void A()
        {
        }
        //IB interface'i ile yaptığı sözleşmeye dair zorla uygulaması gereken B memberı

        public void B()
        {
        }
        //IC interface'i ile yaptığı sözleşmeye dair zorla uygulaması gereken C memberı

        public void C()
        {
        }
    }

    #endregion

    #region Bir interface'in başka bir interfaci kalıtım alması,class'ın derived class'ı implemente etmesi
    interface IBase
    {
        void Selamla();
    }
    interface IBase2
    {
        void Otur();
    }
    interface IDerived: IBase,IBase2 // IDerived interface'i IBase 'i miras alıyor haliyle Selamla memberının imzası IDerived interface'ine kalıtım yoluyla aktarılıyor. 
    {
        void Alkisla();
    }

    class M
    {

    }
    interface C
    {

    }

    class ImpClass : M, IDerived,C
    {
        public void Alkisla()
        {
            throw new NotImplementedException();
        }

        public void Otur()
        {
            throw new NotImplementedException();
        }

        public void Selamla()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

}
