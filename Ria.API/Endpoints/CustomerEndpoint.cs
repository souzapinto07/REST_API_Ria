using MediatR;
using Ria.API.Filters;
using Ria.Application.Customers.Commands;
using Ria.Domain.Customers.Entities;
using Ria.Domain.Customers.Repositories;

namespace Ria.API.Endpoints
{
    public static class CustomerEndpoint
    {
        public static RouteGroupBuilder MapCustomerEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("Customers", Customers).Produces<string>();

            group.MapPost("CreateCustomers", CreateCustomers).Produces<bool>().AddEndpointFilter<ValidatorFilter<CreateCustomersCommand>>();

            group.MapDelete("ClearCustomers", ClearCustomers);

            return group;
        }


        public static IResult Customers(ICustomerRepository customerRepository)
        {
            return TypedResults.Ok( customerRepository.Customers());
        }

        public static async Task<IResult> CreateCustomers(CreateCustomersCommand command, IMediator _mediator)
        {

            if (command.Customers == null || command.Customers.Count == 0)
            {
                return TypedResults.BadRequest("Customers list cannot be null or empty.");
            }

            return TypedResults.Ok(await _mediator.Send(command));
        }

        //Just for testing purposes
        public static IResult ClearCustomers(ICustomerRepository customerRepository)
        {
            customerRepository.ClearCustomers();
            return TypedResults.NoContent();
        }
    }
}
