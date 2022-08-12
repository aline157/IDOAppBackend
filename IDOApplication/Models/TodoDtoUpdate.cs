using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDOApplication.Models
{
    public class TodoDtoUpdate
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string DueDate { get; set; }
        public string Importance { get; set; }
    }
}
