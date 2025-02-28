
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
                showOptions();
                int response = GetUserResponseInt();

                if (response == 1) 
                {
                    createList(lists);
                }
                else if (response == 2)
                {
                    showLists(lists);
                }
                else if (response == 3)
                {
                    deleteList(lists);
                }
                else if (response == 0) 
                {
                    Console.WriteLine("Bye bye.");
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

        static void showOptions()
        {
            Console.Clear();
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine("1 - Create a new list.");
            Console.WriteLine("2 - Show all the lists.");
            Console.WriteLine("3 - Delete a list.");
            Console.WriteLine("0 - Exit.");
        }

        static void createList(List<ToDoList> lists)
        {
            Console.Clear();
            Console.WriteLine("Insert the title:");
            string titleList = Console.ReadLine();

            lists.Add(new ToDoList(titleList));

            Console.WriteLine($"List {titleList} created.");
        }

        static void showLists(List<ToDoList> lists)
        {
            Console.Clear();

            foreach (ToDoList list in lists)
            {
                Console.WriteLine(list.Title);
            }
        }

        static void deleteList(List<ToDoList> lists)
        {
            Console.WriteLine("What list do you wish to delete:");

            for (int indexList = 0; indexList < lists.Count; indexList++)
            {
                Console.WriteLine($"{indexList}. {lists[indexList].Title}");
            }

            int indexOptionSelected = GetUserResponseInt();

            if (lists.ElementAtOrDefault(indexOptionSelected) == null) {
                Console.WriteLine("This list does not exist.");
            } else {
                lists.RemoveAt(indexOptionSelected);
            }
        }

        static int GetUserResponseInt()
        {
            string response = Console.ReadLine();

            if (response == "") 
            {
                return 0;
            } else {
                return Convert.ToInt16(response);
            }
        }
    }
}