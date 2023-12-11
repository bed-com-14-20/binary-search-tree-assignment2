 class Program
{
    static void Main()
    {
        // Create a BinaryTree of Person objects
        BinaryTree<Person> personTree = new BinaryTree<Person>();

        // Insert some persons into the tree
        personTree.Insert(new Person("John", 30));
        personTree.Insert(new Person("Jane", 25));
        personTree.Insert(new Person("Bob", 35));

        // Print the inorder traversal of the tree
        Console.WriteLine("Inorder Traversal:");
        personTree.PrintInorder();

        // Search for a person in the tree
        Person searchPerson = new Person("Jane", 25);
        if (personTree.Search(searchPerson, out var foundNode, out var parentNode))
        {
            Console.WriteLine($"Person found: {foundNode.Data.Name}, Age: {foundNode.Data.Age}");
        }
        else
        {
            Console.WriteLine("Person not found");
        }

        // Remove a person from the tree
        Person removePerson = new Person("John", 30);
        personTree.Remove(removePerson);

        // Print the inorder traversal again after removal
        Console.WriteLine("\nInorder Traversal after removal:");
        personTree.PrintInorder();
    }
}