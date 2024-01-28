using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataHolding.Models.Main
{
    public class EmployeeRecord
    {
        [Key]
        public int Id{ get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? District { get; set; }
        public string? Phone { get; set; }
        public DateTime? Dob { get; set; }
    }

}