using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Location
    {
        public string TimeZone { get; set; } = null!;
        public string? WinTimeZone { get; set; }
    }
}
