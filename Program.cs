 using System;

class Program
{
    static void Main()
    {
        // Create a BinaryTree of Person objects
        BinaryTree<Person> personTree = new BinaryTree<Person>();

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a person");
            Console.WriteLine("2. Search for a person");
            Console.WriteLine("3. Remove a person");
            Console.WriteLine("4. Print Inorder Traversal");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());

                    personTree.Insert(new Person(name, age));
                    break;

                case "2":
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine();

                    Console.Write("Enter age to search: ");
                    int searchAge = int.Parse(Console.ReadLine());

                    Person searchPerson = new Person(searchName, searchAge);

                    if (personTree.Search(searchPerson, out var foundNode, out var parentNode))
                    {
                        Console.WriteLine($"Person found: {foundNode.Data.Name}, Age: {foundNode.Data.Age}");
                    }
                    else
                    {
                        Console.WriteLine("Person not found");
                    }
                    break;

                case "3":
                    Console.Write("Enter name to remove: ");
                    string removeName = Console.ReadLine();

                    Console.Write("Enter age to remove: ");
                    int removeAge = int.Parse(Console.ReadLine());

                    Person removePerson = new Person(removeName, removeAge);
                    personTree.Remove(removePerson);
                    break;

                case "4":
                    Console.WriteLine("Inorder Traversal:");
                    personTree.PrintInorder();
                    break;

                case "5":
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
