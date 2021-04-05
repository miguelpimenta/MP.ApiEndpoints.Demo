using System;

namespace MP.ApiEndpoints.Demo.Core.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}