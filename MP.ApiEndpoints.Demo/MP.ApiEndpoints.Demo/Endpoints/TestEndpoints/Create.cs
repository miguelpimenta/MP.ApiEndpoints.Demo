using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MP.ApiEndpoints.Demo.Core.Application.Contracts;
using MP.ApiEndpoints.Demo.Core.Domain.Entities;
using MP.ApiEndpoints.Demo.Endpoints.Base;

namespace MP.ApiEndpoints.Demo.Endpoints.TestEndpoints
{
    [Route(Routes.Test)]
    public class Create : CreateBase<CreatePersonRequest, CreatePersonResponse, Person>
    {
        public Create(
            IRepository<Person> repository) : base(repository)
        {
        }
    }

    public class CreatePersonRequest : RequestBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }

    public class CreatePersonResponse : ResponseBase
    {
        public Guid Id { get; set; }
    }
}