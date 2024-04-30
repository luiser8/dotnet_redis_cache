using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using NetCoreWithRedis.Services.Books;
using NetCoreWithRedis.Services.BusyBooks;
using NetCoreWithRedis.Services.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(options =>
            {
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            }).AddNewtonsoftJson()
            .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("mycors",
            builder =>
                {
                    builder
                        .WithOrigins("*")
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH");
                });
    });
builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBusyBooksService, BusyBooksService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseCors("mycors");
app.Run();
