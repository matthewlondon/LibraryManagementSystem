using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book : Media
    {
        public int maxPage { get; set; }
        public int currentPage { get; set; }
        public double progress { get; set; }
    }
}
