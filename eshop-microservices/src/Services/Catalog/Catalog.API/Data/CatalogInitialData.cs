using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session=store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreConfiguredProducts());

            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>() { 
            new Product()
            { 
                Id=new Guid(),
                Name="IPhoneX",
                Description="Apple 10",
                ImageFile="product-1.png",
                Price=960.00M,
                Category=new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id=new Guid(),
                Name="Samsung",
                Description="S23 Ultra",
                ImageFile="product-2.png",
                Price=960.00M,
                Category=new List<string> { "Smart Phone" }
            }


        };
    }
}
