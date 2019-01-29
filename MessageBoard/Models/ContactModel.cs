using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MessageBoard.Models
{
  public  class ContactModel
    {
        [Required(ErrorMessage = "Ener Name Please")]
        public string Name { get; set; }
        public string Email { get; set; }

        public string  Website{ get; set; }
        public string Comment { get; set; }

    }
}
