using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO
{
    public class List
    {

        private bool check = false;
        private string title;
        private string content = "";

        public List(string aTitle)
        {
            title = aTitle;
        }

        public bool Check
        {
            get { return check;}
            set {
                if (value == false) {
                    check = value;
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
    }
}