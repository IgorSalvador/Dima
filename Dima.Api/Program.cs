using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")  ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(type => type.FullName);
});
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet(
        "/v1/categories/{id}",
        async (long id, ICategoryHandler handler) =>
        {
            var request = new GetCategoryByIdRequest
            {
                Id = id
            };
            return await handler.GetByIdAsync(request);
        })
    .WithName("Categories: Get by Id")
    .WithDescription("Retorna uma categoria")
    .Produces<Response<Category?>>();

app.MapPost(
        "/v1/categories",
        async (CreateCategoryRequest request, ICategoryHandler handler) 
            => await handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithDescription("Cria uma nova categoria")
    .Produces<Response<Category?>>();

app.MapPut(
        "/v1/categories/{id}",
        async (long id, UpdateCategoryRequest request, ICategoryHandler handler) =>
        {
            request.Id = id;
            return await handler.UpdateAsync(request);       
        })
    .WithName("Categories: Update")
    .WithDescription("Atualiza uma categoria")
    .Produces<Response<Category?>>();

app.MapDelete(
    "/v1/categories/{id}",
    async (long id, ICategoryHandler handler) =>
    {
        var request = new DeleteCategoryRequest
        {
            Id = id
        };
        await handler.DeleteAsync(request);
    })
    .WithName("Categories: Delete")
    .WithDescription("Exclui uma categoria")
    .Produces<Response<Category?>>();

app.Run();