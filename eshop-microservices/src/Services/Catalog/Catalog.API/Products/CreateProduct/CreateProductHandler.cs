
using Catalog.API.Models;


namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price):ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
           RuleFor(x=>x.Name).NotEmpty().WithMessage("Name should not be empty");
        }
    }
    public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from command object

            
            var product = new Product {
              Name=command.Name,
              Category=command.Category,
              Description=command.Description,
              ImageFile=command.ImageFile,
              Price=command.Price
            };

            //save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //return CreateProductResut result
            return new CreateProductResult(product.Id);
        }
    }
}
