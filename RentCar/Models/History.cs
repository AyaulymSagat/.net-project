using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class History
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Display(Name = "Car")]
        [ForeignKey("Car")]
        public int CarId { get; set; }

        [Display(Name = "Descr")]
        public string Descr { get; set; }

    }
}
