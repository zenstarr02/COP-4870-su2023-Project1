using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_1.Models
{
    public class Client
    {
  
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; } 
    public bool IsActive { get; set; } 

        public Client(int id, string name, string notes, DateTime openDate, DateTime closeDate, bool isActive)
        {
            Id = id;
            Name = name;
            Notes = notes;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsActive = isActive;
        }

        public Client(Client c)
        {
            Id = c.Id;
            Name = c.Name;
            Notes = c.Notes;
            OpenDate = c.OpenDate;
            CloseDate = c.CloseDate;
            IsActive = c.IsActive;
        }

        public Client() { }
        public Client(string name, int id) 
        { 
            Name = name;
            Id = id;
        
        }


        public override string ToString()
        {
            string x;
            if (IsActive) { x = "Active"; } else { x = "Inactive"; }

            return $"{Id}. {Name}\t{x}";
        }

        public void activate() { IsActive = true; }
        public void deactivate() { IsActive = false; }


    }
}
