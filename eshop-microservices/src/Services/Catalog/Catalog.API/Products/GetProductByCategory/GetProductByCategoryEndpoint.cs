﻿
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category,ISender sender) => {

                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            }
            ) 
            .WithDisplayName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("GetProductByCategory")
            .WithSummary("GetProductByCategory");
        }
    }
}
