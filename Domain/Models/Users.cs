using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Roles { get; set; }
    }
}
