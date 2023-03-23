public static class ProductRepository
{
    public static List<Product> Products { get; set; } = new List<Product>();

    public static void Init(IConfiguration confiration)
    {
        var products = confiration.GetSection("Produtos").Get<List<Product>>();

        Products = products;
    }

    public static void add(Product product)
    {
        Products.Add(product);
    }
    public static Product Getby(string code)
    {
        try
        {
            return Products.First(p => p.Code == code);

        }
        catch
        {
            return null;
        }
    }

    public static void Remove(Product product)
    {
        Products.Remove(product);
    }
}