using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOApplication.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string DueDate { get; set; }
        public string Importance { get; set; }
        public string Status { get; set; }
        public string UserEmail { get; set; }

        public Todo(string title,string category,string dueDate,string importance, string status, string userEmail)
        {
            this.Title = title;
            this.Category = category;
            this.DueDate = dueDate;
            this.Importance = importance;
            this.Status = status;
            this.UserEmail = userEmail;

        }
    }
}
