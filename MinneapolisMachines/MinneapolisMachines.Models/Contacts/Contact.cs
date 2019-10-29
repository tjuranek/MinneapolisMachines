using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Models.Contacts
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        public string Name { get; set; }


        public string Email { get; set; }


        public int Phone { get; set; }


        [Required]
        public string Message { get; set; }
    }
}
