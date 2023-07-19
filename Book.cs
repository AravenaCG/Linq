using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq
{
    public class Book
    {
        public string? Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? Status { get; set; }
        public string[]? Authors { get; set; }
        public string[]? Categories { get; set; }
    }
}