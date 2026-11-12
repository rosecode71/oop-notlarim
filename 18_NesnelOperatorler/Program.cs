#region NULL CONDITION OPERATORU : ?

//sol?.sağ ==> Eğer referans yani sol null ise hiçbir şey yapma eğer değilse sağa geç
//Person person = new();
////person.Branch = null;
//person.Branch.Department = new Department();
//person.Branch.Department.DepartmentName = "Ali";

//Console.WriteLine(person?.Branch?.Department?.DepartmentName);
//class Person 
//{ 
//    public String Name { get; set; }
//    public Branch Branch { get; set; }
//}
//class Branch
//{
//    public String BranchName { get; set; }
//    public Department Department { get; set; }
//}


//class Department
//{
//    public String DepartmentName { get; set; }
//}
#endregion

#region NULL COALESCING ASSIGNMENT OPERATORU ??
//Eğer bir değişkenin değeri null ise sağ taraftaki değer değişkene atanır eğer null değilse mevcut değerini korur.


//Değer türlü değişken örnek
//int? a = null;
//a ??= 15;     // a = a ?? 15;
//Console.WriteLine(a);


////Referans türlü dğeişken örnek
//string ad = null;
//ad ??= "Mustafa";
//Console.WriteLine(ad);



//Karakter k1 = null;

//k1 ??= new();
//k1.Name = null;

//k1.Name ??= "MustafaAI.";
//k1.Name ??= "Mustafa AI.";
//Console.WriteLine(k1.Name);




//class Karakter
//{
//    public string? Name { get; set; }

//}

#endregion

#region IS OPERATORU


Person p = new Person
{
    Name = "Mustafa",
    Age = 22
};


//if(p.Name == "Mustafa" && p.Age == 22)
//{
//    //..
//}


//And işlemi gerçekleştirir.
if(p is { Name : "Mustafa" , Age : 22 })
{
    Console.WriteLine("Adı Mustafa yaşı 22");
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Married { get; set; }
}
#endregion