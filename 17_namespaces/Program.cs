

#region Hata Durumu
//using Entity;
//using Entity2;

//Entity.Product p1 = new();

//e.Order o1 = new e.Order();
//e.Order o2 = new();

//Order o3 = new Order();
#endregion

#region Namespace'lere alias yani takma ad verme
//using e1 = Entity;
//using e2 = Entity;

//using static Entity.Customer;
//using static System.Console;

//X();
//Y();
//WriteLine("Bu bir static metoddur.");


//e2.Customer c2 = new();
#endregion


#region Global Keywordü
//Customer c = new();
//Order o = new();
//Customer.X();
#endregion


#region global::


//global::Entity2.Order o = new();

using e = Entity2;
e::Order o = new();

#endregion

namespace Entity
{

    class Customer
    {
        public static void X()
        {

        }
        public static void Y()
        {

        }
    }

    class Order
    {

    }
}

namespace Entity2
{

    class Order
    {
        public static void X()
        {

        }
    }
}