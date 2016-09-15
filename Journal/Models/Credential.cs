using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JournalInfo.Models
{

    public class Login
    {

        public int id { get; set; }

        [Required]
        public string login { get; set; }

        [Required]
        public string Password { get; set; }

    }
}