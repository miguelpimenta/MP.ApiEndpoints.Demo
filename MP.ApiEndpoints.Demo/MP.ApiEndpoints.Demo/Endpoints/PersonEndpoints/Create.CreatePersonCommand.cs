using System;
using System.ComponentModel.DataAnnotations;

namespace MP.ApiEndpoints.Demo.Endpoints.PersonEndpoints
{
    public class CreatePersonCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}