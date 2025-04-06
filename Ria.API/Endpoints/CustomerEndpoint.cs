using MediatR;
using Ria.API.Filters;
using Ria.Application.Customers.Commands;
using Ria.Application.Customers.Contracts.Response;
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

            return group;
        }


        public static async Task<IResult> Customers(ICustomerRepository customerRepository)
        {
            //TODO AutoMapper
           // List<CustomerResponseDTO> cuistomerDTO = new List<CustomerResponseDTO>();
            return TypedResults.Ok(await customerRepository.GetCustomers());
        }

        public static async Task<IResult> CreateCustomers(CreateCustomersCommand command, IMediator _mediator)
        {

            if (command.Customers == null || command.Customers.Count == 0)
            {
                return TypedResults.BadRequest("Customers list cannot be null or empty.");
            }

            return TypedResults.Ok(await _mediator.Send(command));
        }
    }
}
