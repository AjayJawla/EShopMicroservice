
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price):ICommand<UpdateProdcutResult>;

    public record UpdateProdcutResult(bool IsSuccess);
    public class UpdateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<UpdateProductCommand, UpdateProdcutResult>
    {
        public async Task<UpdateProdcutResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
           

            var product=await session.LoadAsync<Product>(command.Id,cancellationToken);

            if(product is null)
            {
                throw new ProductNoFoundException(command.Id);
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProdcutResult(true);


        }
    }
}
