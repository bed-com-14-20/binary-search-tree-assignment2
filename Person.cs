 using System;

public class Person : IComparable<Person>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    private string _id;


    // making sure that the id should be  6 characters long
    public string ID
    {
        get => _id;
        set
        {
            if (value.Length >= 6)
            {
                _id = value;
            }
            else
            {
                throw new ArgumentException("ID must be at least 6 characters long.");
            }
        }
    }
    // arg constructer
    public Person(string firstName, string lastName, int age, string id)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        ID = id; // validation
    }
    // comparing ids for 2 persons
    public int CompareTo(Person other)
    {
        return ID.CompareTo(other.ID);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Age: {Age}, ID: {ID}";
    }
}