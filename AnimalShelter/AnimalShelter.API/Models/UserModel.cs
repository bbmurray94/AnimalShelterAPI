﻿namespace AnimalShelter.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public int UserRoleId { get; set; }
        public UserRoleModel UserRole { get; set; }
    }
}
