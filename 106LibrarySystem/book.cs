using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase
{
    public class Book
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public int availability { get; set; }

        public string language { get; set; }

        public int pageNum { get; set; }

        public int date { get; set; }

        public string ImagePath { get; set; }

        public string DisplayAvailability
        {
            get
            {
                return availability > 0 ? "Available" : "Unavailable";
            }
        }

        public string AvailabilityColor
        {
            get
            {
                return availability > 0 ? "Green" : "Red";
            }
        }

    }

}
