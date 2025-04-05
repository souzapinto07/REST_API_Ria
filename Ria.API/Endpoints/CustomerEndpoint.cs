using MediatR;
using Ria.API.Filters;
using Ria.Application.Customers.Commands;
using Ria.Domain.Customers.Entities;

namespace Ria.API.Endpoints
{
    public static class CustomerEndpoint
    {
        public static RouteGroupBuilder MapCustomerEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("Customers", Customers)/*.RequireAuthorization()*/.Produces<string>();

            group.MapPost("CreateCustomers", CreateCustomers)/*.RequireAuthorization()*/.Produces<bool>().AddEndpointFilter<ValidatorFilter<CreateCustomersCommand>>();

            return group;
        }


        public static async Task<IResult> Customers()
        {
            return TypedResults.Ok("We will do it");
        }

        public static async Task<IResult> CreateCustomers(CreateCustomersCommand command, IMediator _mediator)
        {
            return TypedResults.Ok(await _mediator.Send(command));
        }
    }
}
