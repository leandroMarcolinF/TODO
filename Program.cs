
namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("What do you wish to do?");
                Console.WriteLine("1 - Create a new list?");
                Console.WriteLine("0 - Exit.");

                int response = GetUserResponseInt();

                if (response == 1) {
                    Console.Clear();
                    Console.WriteLine("Insert the title:");
                    string titleList = Console.ReadLine();

                    List list = new List(titleList);

                    Console.WriteLine($"List {list.Title} created.");
                } else if (response == 0) {
                    keepRunning = false;
                } else {
                    Console.Clear();
                    Console.WriteLine("Unavailable option.");
                }
            }
        }

        static int GetUserResponseInt()
        {
            return Convert.ToInt16(Console.ReadLine());
        }
    }
}