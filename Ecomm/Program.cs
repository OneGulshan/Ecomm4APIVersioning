using Ecomm.Data;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc().AddXmlSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddApiVersioning(a=>a.ApiVersionReader=new MediaTypeApiVersionReader());
// If Swagger not Found use this proccess
builder.Services.AddSwaggerGen(c => // This is a swagger swasbuckel // Install Swashbuckle.AspNetCore package, AddSwaggerGen service me SwaggerDoc ka use kar Documentation teyar ki gai hai yahan
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecomm2", Version = "v1" }); // this is a Swager Title with its version information <- Swagger file isi ke hissab se banti hai jo ki SwaggerEndpoint me defined hai
});

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => // Here used Swagger swasbuckle as a middelware here with its UI
    {
        c.RouteTemplate = "/swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Ecomm2 v1")); // this is SwaggerEndpoint yahi hamari UI generate karta hai
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
