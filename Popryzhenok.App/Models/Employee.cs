using System;

namespace Popryzhenok.App.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Passport { get; set; }

        public string? BankNumber { get; set; }

        public bool? IsFamily { get; set; }

        public bool? IsHealth { get; set; }
    }
}
