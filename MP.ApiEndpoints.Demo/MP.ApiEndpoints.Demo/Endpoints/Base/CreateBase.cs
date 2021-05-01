using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MP.ApiEndpoints.Demo.Core.Application.Contracts;
using MP.ApiEndpoints.Demo.Core.Domain.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace MP.ApiEndpoints.Demo.Endpoints.Base
{
    [Consumes("Application/json")]
    [Produces("Application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public abstract class CreateBase<TRequest, TResponse, TEntity> : BaseAsyncEndpoint
        .WithRequest<TRequest>
        .WithResponse<TResponse>
        where TRequest : RequestBase
        where TResponse : ResponseBase
        where TEntity : AuditableEntity
    {
        
        private readonly IRepository<TEntity> _repository;

        protected CreateBase(
            IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create",
            Description = "Create",
            Tags = new[] { "Create" })
        ]
        public override async Task<ActionResult<TResponse>> HandleAsync(
            TRequest request,
            CancellationToken cancellationToken = default)
        {
            var entityToCreate = request.Adapt<TEntity>();
            
            await _repository
                .CreateAsync(entityToCreate, cancellationToken)
                .ConfigureAwait(false);
            
            var result = entityToCreate.Adapt<TResponse>();
            
            return Ok(result);
        }
    }

    public abstract class RequestBase
    {
    }

    public abstract class ResponseBase
    {
    }
}