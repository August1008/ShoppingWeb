﻿namespace ShoppingWeb.Api.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}
