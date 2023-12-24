using System;

class Program
{
    static void Main()
    {
        // Instance BinaryTree of Persons
        BinaryTree<Person> personTree = new BinaryTree<Person>();
        // infirnite loop for main menue
        while (true)
        {
            // Display menu options
            Console.WriteLine("\n");
            Console.WriteLine("Select the following options for operations:");
            Console.WriteLine("1. Add a person");
            Console.WriteLine("2. Search for a person");
            Console.WriteLine("3. Print Inorder Traversal");
            Console.WriteLine("4. Print Postorder Traversal");
            Console.WriteLine("5. Remove a person");
            Console.WriteLine("6. Exit\n");

            Console.Write("Enter your choice (1-6):");
            string Selection = Console.ReadLine();

            switch (Selection)
            {
                case "1":
                    AddPerson(personTree); // calling add person method
                    break;

                case "2":
                    SearchPerson(personTree); // calling searchperson method
                    break;

                case "3":
                    personTree.PrintInorder(); // calling person print inoroder traversal
                    break;

                case "4":
                    personTree.PrintPostorder(); //  post order
                    break;

                case "5":
                    RemovePerson(personTree); // calling remove person method
                    break;

                case "6":
                    Console.WriteLine("Exiting the program."); // exit
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    // Function to add a person
    static void AddPerson(BinaryTree<Person> personTree)
    {
        // input firstname
        Console.Write("Enter firstname: ");
        string firstName = Console.ReadLine();

        // input lastsname
        Console.Write("Enter lastname: ");
        string lastName = Console.ReadLine();

        // input age
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());

        // input id
        Console.Write("Enter unique ID: ");
        string uniqueId = Console.ReadLine();

        // add person object 
        Person Add_person = new Person(firstName, lastName, age, uniqueId);

        // checking if theid already exist
        if (personTree.Search(Add_person, out _, out _))
        {
            Console.WriteLine("Person with the same unique ID already exists.");
        }
        else
        {
            personTree.Insert(Add_person);
            Console.WriteLine("Person added successfully.");

            // Writing person details to a Notepad file
             WriteToNotepad(firstName, lastName, age, uniqueId);

        }
    }


    // Function to write to Notepad file
     static void WriteToNotepad(string firstName, string lastName, int age, string uniqueId)
    {
        string file_Path = "COM314.txt";

        // Formatingg the entry with each detail on a new line
        string Entry_Order = $"{firstName}\n{lastName}\n{age}\n{uniqueId}";

        // entry to the text file with an empty line separator
        File.AppendAllText(file_Path, Entry_Order + Environment.NewLine + Environment.NewLine);

        Console.WriteLine($"Person details written to {file_Path}");
    }

    // Function to remove a person
    static void RemovePerson(BinaryTree<Person> personTree)
    {
        Console.Write("Enter unique ID to remove: ");
        string removeId = Console.ReadLine();

        if (personTree.Search(new Person("", "", 0, removeId), out var foundNodeToRemove, out _))
        {
            personTree.Remove(foundNodeToRemove.Data);
            Console.WriteLine($"Person with ID {removeId} removed successfully.");
        }
        else
        {
            Console.WriteLine("Person not found");
        }
    }

    
    // Function to search for a person
    static void SearchPerson(BinaryTree<Person> personTree)
    {
        Console.Write("Enter unique ID to search: ");
        string Search_Identity = Console.ReadLine();

        if (personTree.Search(new Person("", "", 0, Search_Identity), out var Available_Node, out _))
        {
            Console.WriteLine($"Person found: {Available_Node.Data}");
        }
        else
        {
            Console.WriteLine("Person not found");
        }
    }

}    

