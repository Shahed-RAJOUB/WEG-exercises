﻿using System.ComponentModel.DataAnnotations;

namespace MyApp.DTOs
{
    public class RegisterDTO
    {
        [Required] public string FirstName{ get; set; }
        [Required] public string LastName{ get; set; }
        [Required] public string Email{ get; set; }
        [Required] public string City{ get; set; }
        [Required] public string Country{ get; set; }
        [Required] public string Zip{ get; set; }
        [Required] public string Birthday{ get; set; }
        [Required] public string Password{ get; set; }
    }
}