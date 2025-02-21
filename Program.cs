
namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string titleList = Console.ReadLine();

                List list = new List(titleList);

                Console.WriteLine(list.Title);
            }
        }
    }
}