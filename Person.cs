 using System;

public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int CompareTo(Person other)
    {
        return Age.CompareTo(other.Age);
    }
}