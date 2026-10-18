using System;

class Person
{
    private string name { get; set; }
    private string address { get; set; }
    private double salary { get; set; }

    public Person(string n, string a, double s)
    {
        name = n;
        address = a;
        salary = s;
    }

    public string GetName()
    {
        return name;
    }
    
    public string GetAddress()
    {
        return address;
    }

    public double GetSalary()
    {
        return salary;
    }

    public void SetName(string n)
    {
        name = n;
    }

    public void SetAddress(string a)
    {
        address = a;
    }

    public void SetSalary(double s)
    {
        salary = s;
    }

    public static Person inputPersonInfo(string n, string a, string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            throw new Exception("Bạn cần nhập lương");
        else if (!double.TryParse(s, out double s1))
            throw new Exception("Bạn cần nhập số");
        else if (s1 <= 0)
            throw new Exception("Lương phải lớn hơn 0");
        else
            return new Person(n, a, s1);
    }

    public static void displayPersonInfo(Person person)
    {
        Console.WriteLine("Thông tin bạn đã nhập");
        Console.WriteLine($"Tên: {person.GetName()}");
        Console.WriteLine($"Địa chỉ: {person.GetAddress()}");
        Console.WriteLine($"Lương: {person.GetSalary()}");
        Console.WriteLine("");
    }

    public static Person[] sortBySalary(Person[] persons)
    {
        try
        {
            int n = persons.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (persons[j].GetSalary() > persons[j+1].GetSalary())
                    {
                        var Tam = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j+1] = Tam;
                    }
                }
            }
            return persons;
        }
        catch
        {
            throw new Exception("Không thể sắp xếp danh sách");
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Person[] p = new Person[3];
        for (int i = 0; i < p.Length; i++)
        {
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            string address = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.Write("Nhập lương: ");
                    string salary = Console.ReadLine();
                    p[i] = Person.inputPersonInfo(name, address, salary);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("");
                }
            }
        }
        p = Person.sortBySalary(p);
        foreach (Person person in p)
        {
            Person.displayPersonInfo(person);
        }
        Console.ReadKey();
    }
}