﻿namespace TelRehAPI.Models.DTO
{
    public class CreatePersonRequestDto
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

    }
}
