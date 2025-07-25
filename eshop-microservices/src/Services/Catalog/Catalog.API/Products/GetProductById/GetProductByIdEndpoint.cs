﻿
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById
{

    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}",async (Guid Id,ISender sender)=>
            {
                var result = await sender.Send(new GetProductByIdQuery(Id));

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            }
           )
           .WithName("GetProductById")
           .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("This function return product")
           .WithDescription("Just hit the url");
        }
    }
}
