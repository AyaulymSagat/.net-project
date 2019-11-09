using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Pasport
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

       [Display(Name = "Registration date")]
        public DateTime RegistationDate { get; set; }

       [Display(Name = "Skill")]
        public string Skill { get; set; }

    }
}
