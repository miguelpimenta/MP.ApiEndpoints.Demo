﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MP.ApiEndpoints.Demo.Endpoints.PersonEndpoints
{
    public class UpdatePersonResult
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}