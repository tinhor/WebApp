using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Korisnici.Models
{
    public class WorkerCreateSession
    {
        [Display(Name = "email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ne smije biti prazan")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lozinka ne smije biti prazna")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}