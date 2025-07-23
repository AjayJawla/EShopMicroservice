namespace Catalog.API.Exceptions
{
    public class ProductNoFoundException:NotFoundException
    {
        public ProductNoFoundException(Guid Id):base("Product",Id)
        {
                
        }
    }
}
