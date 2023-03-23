using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);

var app = builder.Build();
var configuration = app.Configuration;
ProductRepository.Init(configuration);


app.MapPost("/products", (ProductRequest productRequest, ApplicationDbContext context) =>
{
    var Category = context.Category.Where(s => s.Id == productRequest.CategoryId ).First();
    var product = new Product
    {
        Code = productRequest.Code,
        Name = productRequest.Name,
        Description = productRequest.Description,
        Category = Category,

    };
    if(productRequest.Tags != null)
    {
        product.Tags = new List<Tag>();
        foreach(var item in productRequest.Tags)
        {
            product.Tags.Add(new Tag { Name = item });
        }
    }
    

    context.Products.Add(product);
    context.SaveChanges();
    return Results.Created($"/product/{product.Code}", productRequest.Code);
});

//api.app.com/users?datastart={date}&dateend={date}
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) =>
{
    return dateStart + dateEnd;
});

//api.app.com/users?datastart={date}&dateend={date}
app.MapGet("/getproduct/{id}", ([FromRoute] int id, ApplicationDbContext context) =>
{
    var product =context.Products.Where(p => p.Id == id).First();

    if (product != null)
        return Results.Ok(product);

    return Results.NotFound();
});

app.MapGet("/getserverbyheader", (HttpRequest request) =>
{
    return request.Headers["server-code"].ToString();
});

app.MapPut("/editarServer", (Product server) =>
{
    var ProdutoSalvo = ProductRepository.Getby(server.Code);
    ProdutoSalvo.Name = server.Name;

    return Results.Ok();
});

app.MapDelete("removerServer/{codigo}", ([FromRoute] string codigo) =>
{
    var serverSalvo = ProductRepository.Getby(codigo);
    ProductRepository.Remove(serverSalvo);
    return Results.Ok();
});


app.Run();
