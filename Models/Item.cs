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