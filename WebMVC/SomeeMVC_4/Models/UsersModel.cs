using System;

namespace SomeeMVC_4.Models
{
    public class UsersModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}