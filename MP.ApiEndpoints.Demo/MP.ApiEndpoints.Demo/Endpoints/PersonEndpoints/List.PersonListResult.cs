using System;

namespace MP.ApiEndpoints.Demo.Endpoints.PersonEndpoints
{
    public class PersonListResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}