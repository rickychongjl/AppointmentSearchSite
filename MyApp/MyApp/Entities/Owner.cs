using System;
using System.Collections.Generic;

namespace MyApp.Entities
{
    public class Owner
    {
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredContact { get; set; }
        public bool IsOptInForNotifications { get; set; }


        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Pet> Pets { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}
