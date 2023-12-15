using System;

namespace Popryzhenok.App.Models
{
    public class Transfer
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string? From { get; set; }

        public string? To { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
