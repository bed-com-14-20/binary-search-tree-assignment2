 class Program
{
    static void Main()
    {
        // Initialize BinaryTree of Persons
        BinaryTree<Person> personTree = new BinaryTree<Person>();
        // infirnite loop that 
        while (true)
        {
            // Display menu options
            Console.WriteLine("Select the following options for operations:");
            Console.WriteLine("1. Add a person");
            Console.WriteLine("2. Search for a person");
            Console.WriteLine("3. Print Inorder Traversal");
            Console.WriteLine("4. Print Postorder Traversal");
            Console.WriteLine("5. Remove a person");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPerson(personTree);
                    break;
                case "2":
                    SearchPerson(personTree);
                    break;
                case "3":
                    personTree.PrintInorder();
                    break;
                case "4":
                    personTree.PrintPostorder();
                    break;
                case "5":
                    RemovePerson(personTree);
                    break;
                case "6":
                    Console.WriteLine("Exiting the program.");
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
        Console.Write("Enter firstname: ");
        string name = Console.ReadLine();

        Console.Write("Enter lastname:  ");
        string lastName = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter unique ID: ");
        string uniqueId = Console.ReadLine();

        Person newPerson = new Person(name, lastName, age, uniqueId);

        if (personTree.Search(newPerson, out _, out _))
        {
            Console.WriteLine("Person with the same unique ID already exists.");
        }
        else
        {
            personTree.Insert(newPerson);
            Console.WriteLine("Person added successfully.");

            // Write the person details to a Notepad file
             WriteToNotepad(name, lastName, age, uniqueId);

        }
    }

    // Function to search for a person
    static void SearchPerson(BinaryTree<Person> personTree)
    {
        Console.Write("Enter unique ID to search: ");
        string searchId = Console.ReadLine();

        if (personTree.Search(new Person("", "", 0, searchId), out var foundNode, out _))
        {
            Console.WriteLine($"Person found: {foundNode.Data}");
        }
        else
        {
            Console.WriteLine("Person not found");
        }
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

    // Function to write to Notepad
    static void WriteToNotepad(string content)
    {
        string notepadPath = "COM314.txt";

        using (StreamWriter sw = new StreamWriter(notepadPath, true))
        {
            sw.WriteLine(content);
        }

        Console.WriteLine($"Person details written to {notepadPath}");
    }
    
    static void WriteToNotepad(string firstName, string lastName, int age, string uniqueId)
    {
        string notepadPath = "notepad.txt";

        // Format the entry with each detail on a new line
        string entry = $"{firstName}\n{lastName}\n{age}\n{uniqueId}";

        // Append the entry to the text file with an empty line separator
        File.AppendAllText(notepadPath, entry + Environment.NewLine + Environment.NewLine);

        Console.WriteLine($"Person details written to {notepadPath}");
    }
}