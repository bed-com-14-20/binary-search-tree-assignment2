 using System;

public class Person : IComparable<Person>
{
    // gettter and setters for person details
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    private readonly string _id;

    
    public string Identity_number
    {
        get => _id;
    }

    // arg constructor
    public Person(string firstName, string lastName, int age, string id)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    // making sure that the id should be 6 characters long
        if (id.Length > 5)
        {
            _id = id;
        }
        else
        {
            throw new ArgumentException("ID must be at least 6 characters long.");
        }
    }

    // comparing ids for 2 persons
    public int CompareTo(Person other)
    {
        return Identity_number.CompareTo(other.Identity_number);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Age: {Age}, ID: {Identity_number}";
    }
}
