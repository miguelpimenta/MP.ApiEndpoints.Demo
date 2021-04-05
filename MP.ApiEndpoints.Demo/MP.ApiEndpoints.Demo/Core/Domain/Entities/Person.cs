using System;
using MP.ApiEndpoints.Demo.Core.Domain.Common;

namespace MP.ApiEndpoints.Demo.Core.Domain.Entities
{
    public class Person : AuditableEntity
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}