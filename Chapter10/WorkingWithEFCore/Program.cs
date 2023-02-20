using Packt.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore;

WriteLine($"Using {ProjectContants.DatabaseProvider} database provider");

static void QueryingCategories()
{
    using (Northwind db = new())
    {
        WriteLine("Categories and how many products they habe:");
        // a query to get all categories and their related products
        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);
    }
}