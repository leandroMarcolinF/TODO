
using TODO.Models;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ToDoList> lists = new();
            bool keepRunning = true;
            
            while (keepRunning)
            {
                ShowListOptions();
                int response = GetUserResponseInt();

                switch (response)
                {
                    case 1:
                        CreateList(lists);
                        break;
                    case 2:
                        ShowLists(lists);
                        break;
                    case 3:
                        DeleteList(lists);
                        break;
                    case 4:
                        AccessListOptions(lists);
                        break;
                    case 0:
                        Console.WriteLine("Bye bye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unavailable option.");
                        break;
                }
                
                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
        }

        static void ShowListOptions()
        {
            Console.Clear();
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine("1 - Create a new list.");
            Console.WriteLine("2 - Show all the lists.");
            Console.WriteLine("3 - Delete a list.");
            Console.WriteLine("4 - Access a list.");
            Console.WriteLine("0 - Exit.");
        }

        static void CreateList(List<ToDoList> lists)
        {
            Console.Clear();
            Console.WriteLine("Insert the title:");
            string titleList = Console.ReadLine();

            lists.Add(new ToDoList(titleList));

            Console.WriteLine($"List '{titleList}' created.");
        }

        static void ShowLists(List<ToDoList> lists)
        {
            Console.Clear();

            foreach (ToDoList list in lists)
            {
                Console.WriteLine(list.Title);
            }
        }

        static void DeleteList(List<ToDoList> lists)
        {
            Console.Clear();
            Console.WriteLine("What list do you wish to delete:");

            ShowListsOptions(lists);

            int indexOptionSelected = GetUserResponseInt();

            if (lists.ElementAtOrDefault(indexOptionSelected) == null) {
                Console.WriteLine("This list does not exist.");
            } else {
                lists.RemoveAt(indexOptionSelected);
            }
        }

        static void AccessListOptions(List<ToDoList> lists)
        {
            bool keepRunningItems = true;
            int response;
            
            Console.WriteLine("What list do you wish to alter:");

            ShowListsOptions(lists);

            int listSelected = GetUserResponseInt();

            if (lists.ElementAtOrDefault(listSelected) == null) {
                Console.WriteLine("This list does not exist.");
                keepRunningItems = false;
            }

            while (keepRunningItems)
            {
                ShowItemOptions();
                response = GetUserResponseInt();

                switch (response)
                {
                    case 1:
                        CreateItem(lists, listSelected);
                        break;

                    case 2:
                        lists[listSelected].ShowItems();
                        break;

                    case 3:
                        CheckItem(lists, listSelected);
                        break;
                    
                    default:
                        keepRunningItems = false;
                        break;
                }

                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
        }

        static void ShowItemOptions()
        {
            Console.Clear();
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine("1 - Add item to the list.");
            Console.WriteLine("2 - Show all items.");
            Console.WriteLine("3 - Check item.");
            Console.WriteLine("0 - Exit.");
        }

        static void CreateItem(List<ToDoList> lists, int listSelected)
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

        static void CheckItem(List<ToDoList> lists, int listSelected)
        {
            Console.Clear();
            var items = lists[listSelected].Items;
            
            Console.WriteLine("What item do you wish to check?");
            
            for (int indexItem = 0; indexItem < items.Count; indexItem++)
            {
                if (items[indexItem].Check != true) {
                    Console.WriteLine($"{indexItem}. {items[indexItem].Title}");
                }
            }

            int itemSelected = GetUserResponseInt();

            items[itemSelected].Check = true;
        }

        static void ShowListsOptions(List<ToDoList> lists)
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