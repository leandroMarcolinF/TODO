using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.Models
{
    public class Item
    {
        private string title;
        private bool check;
        private DateTime dateTime;

        public Item(string aTitle, bool aCheck = false)
        {
            UpdateTitle(aTitle);
            check = aCheck;
            dateTime = DateTime.Now;
        }

        public string Title
        {
            get { return title; }
            set {
                if (value.Length <= 20) {
                    title = value;
                }
            }
        }

        public bool Check
        {
            get { return check; }
            set {
                if (check == true) {
                    throw new Exception("You can not uncheck an item.");
                }

                check = value;
            }
        }

        private void UpdateTitle(string newTitle)
        {
            ValidateTitle(newTitle);

            title = newTitle;
        }

        private static void ValidateTitle(string title)
        {
            if (title.Length > 30) {
                throw new Exception("The item's title is too long.");
            }
        }
    }
}