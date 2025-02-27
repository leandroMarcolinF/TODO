
using TODO.Models;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            List<ToDoList> lists = new List<ToDoList>();
    
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("What do you wish to do?");
                Console.WriteLine("1 - Create a new list.");
                Console.WriteLine("2 - Show all the lists.");
                Console.WriteLine("3 - Delete a list.");
                Console.WriteLine("0 - Exit.");

                int response = GetUserResponseInt();

                if (response == 1) 
                {
                    Console.Clear();
                    Console.WriteLine("Insert the title:");
                    string titleList = Console.ReadLine();

                    lists.Add(new ToDoList(titleList));

                    Console.WriteLine($"List {titleList} created.");
                }
                else if (response == 2)
                {
                    Console.Clear();

                    foreach (ToDoList list in lists)
                    {
                        Console.WriteLine(list.Title);
                    }
                }
                else if (response == 3)
                {
                    Console.WriteLine("What list do you wish to delete:");

                    foreach (ToDoList list in lists)
                    {
                        
                    }

                    for (int indexList = 0; indexList < lists.Count; indexList++)
                    {
                        Console.WriteLine($"{indexList}. {lists[indexList].Title}");
                    }

                    lists.RemoveAt(GetUserResponseInt());
                }
                else if (response == 0) 
                {
                    keepRunning = false;
                } 
                else 
                {
                    Console.Clear();
                    Console.WriteLine("Unavailable option.");
                }

                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
        }

        static int GetUserResponseInt()
        {
            return Convert.ToInt16(Console.ReadLine());
        }
    }
}