using DefiSeeker.Presentation;
using DefiSeeker.Application;
using DefiSeeker.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger();
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddBlockFrostClient();


var app = builder.Build();

app.MapEndpoints();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "DefiSeeker API";
        config.Path = "/swagger";
        config.DocExpansion = "list";
    });
}


app.Run();

