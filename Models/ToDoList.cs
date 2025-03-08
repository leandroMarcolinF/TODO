using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.Models
{
    public class ToDoList
    {
        private bool allListcheck = false;
        private string title;
        private string description = "";
        private List<Item> items;

        public ToDoList(string aTitle)
        {
            title = aTitle;
            items = new();
        }

        public bool AllListcheck
        {
            get { return allListcheck;}
            set {
                if (value == false) {
                    allListcheck = value;
                } else {
                    Console.WriteLine("You can not uncheck.");
                }
            }
        }

        public string Title
        {
            get { return title; }
            set {
                Console.WriteLine(value.Length);
                if (value.Length <= 20) {
                    title = value;
                } else {
                    Console.WriteLine("The title is longer than allowed.");
                }
            }
        }

        public void CreateItem(string titleItem, bool check = false)
        {
            items.Add(new Item(titleItem, check));
        }

        public void ShowItems()
        {
            foreach (Item item in items)
            {
                string checkSymbol = "";

                if (item.Check == false) {
                    checkSymbol = "( )";
                }

                if (item.Check == true) {
                    checkSymbol = "(X)";
                }

                Console.WriteLine($"{checkSymbol} {item.Title}");
            }
        }
    }
}