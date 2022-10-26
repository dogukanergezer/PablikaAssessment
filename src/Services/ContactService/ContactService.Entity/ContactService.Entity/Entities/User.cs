using ContactService.Entity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Entity.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Contacts = new List<Contact>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
