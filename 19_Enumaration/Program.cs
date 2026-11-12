
//Enumaration türünden değişken
using System.ComponentModel;
using System.Reflection;

DatabaseType databaseType = DatabaseType.PostgreSql;
Console.WriteLine(databaseType);

//String türünden değikende enumaration değer saklama
string dataBaseType = databaseType.ToString();
Console.WriteLine(dataBaseType);


//Metinsel değer olarak gelen verinin ilgili enumda var mı yok mu olduğunu öğrenmek varsa enumun türünden bir değişkende tutmak
string value = "Firebase";
DatabaseType result =(DatabaseType)Enum.Parse(typeof(DatabaseType), value);
Console.WriteLine(result);


//Elimizde bulunan sayısal değere karşılık gelen enumdaki değeri şu şekilde elde edebiliriz

DatabaseType value2 = (DatabaseType)3;
DatabaseType value3 = (DatabaseType)0;
DatabaseType value4 = (DatabaseType)11;


Console.WriteLine(value2);
Console.WriteLine(value3);
Console.WriteLine(value4);


PageStatus value5 = (PageStatus)1;
Console.WriteLine(value5); //Hata vermesini bekliyordum ama ilgili enumarationda en üste yer alanı dikkate aldı.


//Enumarationda bulunan metinsel değerin sayısal karşılığını şu şekilde elde edebiliriz.
int _MySql = (int)DatabaseType.MySql;
Console.WriteLine(_MySql);


//İlgili enumaritonun içindeki elemanların tümünü bir koleksiyon/dizi içerisinde tutup hepsine ulaşıp listeleyebiliriz.

var types = Enum.GetValues(typeof(PageStatus));

foreach(var type in types)
{
    Console.WriteLine($"{(int)type} : {type}");
}



//Enumaration içerisindeki metinsel ifadeler arayüzlerde daha anlaşılabilir olması için açıklamalar ekleyebiliriz.

DatabaseType database = DatabaseType.MongoDb;
Console.WriteLine(database.GetType());
Console.WriteLine(database.GetType().GetField(database.ToString()));
Console.WriteLine(database.GetType().GetField(database.ToString()).GetCustomAttribute<DescriptionAttribute>().Description);


//Enumarition içerisindeki tüm alanların Descriptionunu getirmek

database.GetType()
    .GetFields()
    .Select(field =>
    {
        var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
        return descriptionAttribute?.Description;
    })
    .Where(d => d != null)
    .ToList()
    .ForEach(d => Console.WriteLine(d));

//Flags


Permissions userPermissions = Permissions.Read;
Permissions adminPermissions = Permissions.Add | Permissions.Update | Permissions.Remove | Permissions.Read;


Console.WriteLine($"Kullanıcı İzinleri : {userPermissions} ");
Console.WriteLine($"Admin izinleri : {adminPermissions}");




[Flags]
enum Permissions
{
    None = 1,
    Add = 2,
    Remove = 4,
    Update = 8,
    Read = 16
}
enum DatabaseType
{
    [Description("1.MySql")]
    MySql,

    [Description("2.MsSql")]
    MsSql = 3,

    [Description("3.PostgreSql")]
    PostgreSql,

    [Description("4.Supabase")]
    Supabase = 10,

    [Description("5.Firebase")]
    Firebase,

    [Description("6.MongoDb")]
    MongoDb = 34,

    [Description("7.Oracle")]
    Oracle = 20
}

enum PageStatus
{
    Loading=1,
    Completed=0,
    Failed=4
}

