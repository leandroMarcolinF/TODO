
using TODO.Models;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            int response;
            List<ToDoList> lists = new List<ToDoList>();
    
            while (keepRunning)
            {
                showOptions();
                response = GetUserResponseInt();

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
                else if (response == 4)
                {
                    accessListOptions(lists);
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
            Console.WriteLine("4 - Access a list.");
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
            Console.Clear();
            Console.WriteLine("What list do you wish to delete:");

            showListsOptions(lists);

            int indexOptionSelected = GetUserResponseInt();

            if (lists.ElementAtOrDefault(indexOptionSelected) == null) {
                Console.WriteLine("This list does not exist.");
            } else {
                lists.RemoveAt(indexOptionSelected);
            }
        }

        static void accessListOptions(List<ToDoList> lists)
        {
            bool keepRunningItems = true;
            int response;
            
            Console.WriteLine("What list do you wish to alter:");

            showListsOptions(lists);

            int listSelected = GetUserResponseInt();

            if (lists.ElementAtOrDefault(listSelected) == null) {
                Console.WriteLine("This list does not exist.");
                keepRunningItems = false;
            }

            while (keepRunningItems)
            {
                Console.Clear();
                Console.WriteLine("What do you wish to do?");
                Console.WriteLine("1 - Add item to the list.");
                Console.WriteLine("2 - Show all items.");
                Console.WriteLine("3 - Check item.");
                Console.WriteLine("0 - Exit.");
                
                response = GetUserResponseInt();

                if (response == 1) 
                {
                    createItem(lists, listSelected);
                } 
                else if (response == 2)
                {
                    lists[listSelected].ShowItems();
                }
                else if (response == 3)
                {
                    Console.Clear();
                    var items = lists[listSelected].Items;
                    
                    Console.WriteLine("What item do you wish to check?");
                    
                    for (int indexItem = 0; indexItem < items.Count; indexItem++)
                    {
                        if (items[indexItem].Check != true) {
                            1Console.WriteLine($"{indexItem}. {items[indexItem].Title}");
                        }
                    }

                    int itemSelected = GetUserResponseInt();

                    items[itemSelected].Check = true;
                }
                else
                {
                    keepRunningItems = false;
                }

                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
        }

        static void createItem(List<ToDoList> lists, int listSelected)
        {
            Console.Clear();

            if (lists.ElementAtOrDefault(listSelected) == null) {
                Console.WriteLine("This list does not exist.");
            } else {
                Console.WriteLine("Insert item's title:");
                string title = Console.ReadLine();
                lists[listSelected].CreateItem(title);
            }
        }

        static void showListsOptions(List<ToDoList> lists)
        {
            for (int indexList = 0; indexList < lists.Count; indexList++)
            {
                Console.WriteLine($"{indexList}. {lists[indexList].Title}");
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