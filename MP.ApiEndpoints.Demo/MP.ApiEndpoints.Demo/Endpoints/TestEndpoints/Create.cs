using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MP.ApiEndpoints.Demo.Core.Application.Contracts;
using MP.ApiEndpoints.Demo.Core.Domain.Entities;
using MP.ApiEndpoints.Demo.Endpoints.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace MP.ApiEndpoints.Demo.Endpoints.TestEndpoints
{
    public class Create : CreateBase<CreatePersonCommand, CreatePersonResult, Person>
    {
        public Create(
            IRepository<Person> repository) : base(repository)
        {
        }

        [HttpPost("/test")]
        [SwaggerOperation(
            Summary = "Create Test",
            Description = "Create Test",
            OperationId = "Test.Create",
            Tags = new[] { "Test" })
        ]
        public override async Task<ActionResult<CreatePersonResult>> HandleAsync(
            CreatePersonCommand request,
            CancellationToken cancellationToken = default)
        {
            CreatePersonResult result = await DoTheWork(request, cancellationToken)
                .ConfigureAwait(false);
            return Ok(result);
        }
    }

    public class CreatePersonCommand : RequestBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }

    public class CreatePersonResult : ResponseBase
    {
        public Guid Id { get; set; }
    }
}