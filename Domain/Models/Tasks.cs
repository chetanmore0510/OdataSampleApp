using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            InverseTask1Task = new HashSet<Tasks>();
        }

        public int TaskId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsAllDay { get; set; }
        public string? RecurrenceRule { get; set; }
        public int? RecurrenceId { get; set; }
        public string? RecurrenceException { get; set; }
        public string? StartTimezone { get; set; }
        public string? EndTimezone { get; set; }
        public int? Task1TaskId { get; set; }

        public virtual Tasks? Task1Task { get; set; }
        public virtual ICollection<Tasks> InverseTask1Task { get; set; }
    }
}
